<template>
  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>
  <v-overlay :model-value="namePromptOverlay" class="align-center justify-center" persistent>
    <v-sheet width="300" class="mx-auto">
      <v-form @submit.prevent>
        <v-text-field v-model="userName" label="Username"></v-text-field>
        <v-btn type="submit" block class="mt-2" @click="setUsername">Submit</v-btn>
      </v-form>
    </v-sheet>
  </v-overlay>

  <v-container class="d-flex flex-row-reverse mr-2 pt-1">
    <v-btn @click="changeUsername" class="ml-1"> {{ userName }} </v-btn>
    <v-btn class="ml-1">GameTime: {{ count }}</v-btn>
    <v-btn @click="deleteUserLocal"> Reset Username </v-btn>
  </v-container>

  <div class="text-h4 text-center">Wordle Mind Bender</div>

  <GameBoard :game="game" @letterClick="addChar" />

  <GameKeyboard :guessedLetters="game.guessedLetters" @letterClick="addChar" />

  <v-row class="justify-center">
    <v-btn
      @click="checkGuess()"
      @keyup.enter="checkGuess()"
      color="primary"
      size="x-large"
      v-if="game.status == WordleGameStatus.Active"
    >
      Check
    </v-btn>

    <v-btn
      @click="newGame"
      @keyup.enter="checkGuess"
      color="secondary"
      size="x-large"
      v-if="game.status !== WordleGameStatus.Active"
    >
      New Game
    </v-btn>
  </v-row>

  <div class="text-h4 text-center mt-10" v-if="game.status == WordleGameStatus.Lost">
    Better Luck Next Time
  </div>
  <div class="text-h4 text-center mt-10" v-if="game.status == WordleGameStatus.Won">You Won!</div>

  <v-row class="justify-center" v-if="game.status == WordleGameStatus.Active">
    <v-col cols="3">
      <WordleSolver :game="game" @wordClick="(value: string) => checkGuess(value)"></WordleSolver>
    </v-col>
  </v-row>
  <v-row class="justify-center mt-10">
    <v-btn @click="addWord()" style="tonal" size="x-small">Add Word Test</v-btn>
  </v-row>
  <!-- <h2>{{ guess }}</h2> -->
  <!-- <h3>{{ game.secretWord }}</h3> -->
</template>

<script setup lang="ts">
import { WordleGame, WordleGameStatus } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import type { Letter } from '@/scripts/letter'
import Axios from 'axios'
import GameBoard from '../components/GameBoard.vue'
import GameKeyboard from '../components/GameKeyboard.vue'
import WordleSolver from '../components/WordleSolver.vue'
import { WordsService } from '@/scripts/wordsService'
import { useStorage } from '@vueuse/core'

const guess = ref('')
const game = reactive(new WordleGame())
const namePromptOverlay = ref(false)
const overlay = ref(true)
const localUserName = useStorage('localUser', 'Guest')
const userName = ref(localUserName.value)
const attempts = ref()
const gameCount = ref(0)
let count = ref(0)

// Start a new game
newGame()

onMounted(async () => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function promptUser() {
  if (game.status == WordleGameStatus.Won) {
    namePromptOverlay.value = true
  }
}

function deleteUserLocal() {
  localStorage.clear()
  userName.value = 'Guest'
}

function changeUsername() {
  namePromptOverlay.value = true
}

function setUsername() {
  namePromptOverlay.value = false
  localUserName.value = userName.value
  if (game.status == WordleGameStatus.Won) {
    Axios.post('/player', {
      name: userName.value.trim(),
      attempts: attempts.value,
      secondsInGame: count.value,
      gameCount: gameCount.value
    })
      .then((response) => {
        console.log(response.data)
      })
      .catch((error) => {
        console.log(error)
      })
    attempts.value = 0
    gameCount.value = 0
  }
}

function addWord() {
  overlay.value = true
  Axios.post('/word', {
    text: 'tests',
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

function newGame() {
  overlay.value = true
  attempts.value = 0
  gameCount.value = 0
  Axios.get('/word')
    .then((response) => {
      game.restartGame(response.data)
      console.log(game.secretWord)
      setTimeout(() => {
        overlay.value = false
      }, 502)
    })
    .catch((error) => {
      console.log(error)
      game.restartGame(WordsService.getRandomWord())
      console.log(game.secretWord)
      overlay.value = false
    })
  count.value = -1
  let startTimer = setInterval(() => {
    if (game.status == WordleGameStatus.Active) {
      count.value++
    } else {
      clearInterval(startTimer)
    }
  }, 1000)
}

function checkGuess(word?: string) {
  if (typeof word === 'string') {
    game.guess.set(word)
  }
  game.submitGuess()

  if (game.status == WordleGameStatus.Won) {
    gameCount.value = 1
  }

  attempts.value++
  promptUser()
  guess.value = ''
}

function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
}

function keyPress(event: KeyboardEvent) {
  if (namePromptOverlay.value === false) {
    if (event.key === 'Enter') {
      checkGuess()
    } else if (event.key === 'Backspace') {
      guess.value = guess.value.slice(0, -1)
      game.guess.pop()
    } else if (event.key.length === 1 && event.key !== ' ') {
      guess.value += event.key.toLowerCase()
      game.guess.push(event.key.toLowerCase())
    }
  }
}
</script>
