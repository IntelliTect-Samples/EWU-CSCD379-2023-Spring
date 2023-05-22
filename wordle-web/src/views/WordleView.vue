<template>
  <h1 class="text-center">{{ gameName }}</h1>

  <div class="text-right">
    <v-dialog v-model="dialog" persistent transition="dialog-bottom-transition">
      <template v-slot:activator="{ props }">
        <v-btn v-bind="props" @click="stopKeyboard()">
          {{ playerName }}
        </v-btn>
      </template>
      <template v-slot:default>
        <v-card>
          <v-toolbar title="login"></v-toolbar>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field v-model="playerName" label="PlayerName"></v-text-field>
                </v-col>
              </v-row>
            </v-container>
          </v-card-text>
          <v-spacer></v-spacer>
          <v-card-actions class="justify-end">
            <v-btn variant="text" @click=";(dialog = false), startKeyboard()">Close</v-btn>
            <v-btn variant="text" @click=";(dialog = false), startKeyboard()">Submit</v-btn>
          </v-card-actions>
        </v-card>
      </template>
    </v-dialog>
  </div>

  <GameBoard class="ma-8 p-10" :game="game" @letterClick="addChar" />
  <KeyBoard
    class="ma-2 p-10"
    @keyPress="keyPress"
    @letterClick="addChar"
    :guessedLetters="game.guessedLetters"
  />
  <HintDialog
    class="text-center"
    :game="game"
    @letterClick="addChar"
    :guessedLetters="game.guessedLetters"
  />

  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>

  <div class="d-flex align-center flex-column">
    <div class="text-subtitle-2">Time: {{count}}</div>
    </div>

</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, type Ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import HintDialog from '../components/HintDialog.vue'
import Axios from 'axios'
import { useRoute } from 'vue-router'

localStorage.startTime = Date.now()

const guess = ref('')
const game = reactive(new WordleGame())
const overlay = ref(true)
var dialog = ref(true)

let timerInterval: any = null
let count: Ref<number> = ref(0)

const route = useRoute()

onMounted(async () => {
  if (!dialog.value) {
    window.addEventListener('keyup', keyPress)
  }
})

function startKeyboard(): void {
  timerInterval = setInterval(() => {
    console.log(count)
    count.value++
  }, 1000)
  window.addEventListener('keyup', keyPress)
}
function stopKeyboard(): void {
  clearInterval(timerInterval)

  window.removeEventListener('keyup', keyPress)
}

onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function addWord() {
  overlay.value = true
  Axios.post('word/AddWordFromBody', {
    text: 'strin',
    isCommon: true,
    isUsed: false
  })
    .then((response) => {
      overlay.value = false
      console.log(response.data)
    })
    .catch((error) => {
      console.log(error)
    })
}

let gameName = 'Wordle Mind Bender'
let apiPath = 'word'
let offset = 0
if (route.path == `/wordoftheday`) {
  gameName = 'Wordle Of The Day'
  apiPath = `word/GetWordOfDay?offset=${offset}`
} else if (route.path == '/pastwordoftheday') {
  gameName = 'Wordle Of The Day'
  offset = localStorage.offset
  apiPath = `word/GetWordOfDay?offset=${offset}`
}

Axios.get(apiPath)
  .then((response) => {
    game.restartGame(response.data)
    console.log(game.secretWord)
    setTimeout(() => {
      overlay.value = false
    }, 502)
  })
  .catch((error) => {
    console.log(error)
  })

function checkGuess() {
  localStorage.name = playerName.value
  if (game.submitGuess(count.value)) {
    clearInterval(timerInterval)
  }

  guess.value = ''
}

function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
}

function keyPress(event: KeyboardEvent | string) {
  let x = 0
  if (typeof event === 'string') {
    if (event === 'Enter') {
      checkGuess()
    } else if (event === 'Backspace') {
      guess.value = guess.value.slice(0, -1)
      game.guess.pop()
      console.log('Back')
    }
  } else {
    console.log(event.key)
    if (event.key === 'Enter') {
      checkGuess()
    } else if (event.key === 'Backspace') {
      guess.value = guess.value.slice(0, -1)
      game.guess.pop()
      console.log('Back')
    } else if (event.key.length === 1 && event.key !== ' ') {
      guess.value += event.key.toLowerCase()
      game.guess.push(event.key.toLowerCase())
    }
  }
}

//import { ref } from 'vue'
const playerName = ref('Guest')
</script>
