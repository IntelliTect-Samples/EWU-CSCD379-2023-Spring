<template>
  <div class="d-flex justify-end mb-6">
    <v-btn @click="nameDialog = !nameDialog">{{ displayName }}</v-btn>
  </div>
  <h1>Wordle Mind Bender</h1>

  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>

  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>

  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>

  <template>
    <v-dialog v-model="nameDialog" width="500px" persistent>
      <v-card height="200px" width="500px" title="Name:">
        <v-text-field label="UserName" @input="nameUpdater($event.target.value)"></v-text-field>
        <v-btn @click="nameDialog = false">Confirm Name</v-btn>
      </v-card>
    </v-dialog>
  </template>
  <template>
    <v-dialog v-model="endScreen" width="500px" persistent>
      <v-card height="200px" width="500px" title="Score:">
        <v-row>
          <v-col> Name: </v-col>
          <v-col> Attempts: </v-col>
          <v-col> Time: </v-col>
        </v-row>
        <v-row>
          <v-col>
            <v-btn @click="nameDialog = !nameDialog">{{ displayName }}</v-btn>
          </v-col>
          <v-col>
            {{ game.finalGuesses }}
          </v-col>
          <v-col>
            {{ game.finalTime }}
          </v-col>
        </v-row>
        <v-btn @click="handleSubmit">Send to Leaderboard</v-btn>
      </v-card>
    </v-dialog>
  </template>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import Axios from 'axios'

const guess = ref('')
const game = reactive(new WordleGame())

const overlay = ref(true)
let nameDialog = ref(false)
let endScreen = ref(false)
let displayName = ref(game.displayName)
let curStatus = game.status

onMounted(async () => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function nameUpdater(newName: string) {
  console.log(newName)
  let str = newName
  game.changeName(str)
  displayName.value = game.displayName
}

function handleSubmit() {
  submitToLeaderboard()
  endScreen.value = false
  game.restartGame('defal')
}

async function submitToLeaderboard() {
  console.log('PlayerInfo')
  console.log(game.displayName)
  console.log(game.finalGuesses)
  console.log(game.finalTime)
  overlay.value = true
  await Axios.post(
    'Leaderboard/InsertScore?name='
      .concat(game.displayName)
      .concat('&numAttempts=')
      .concat(String(game.finalGuesses))
      .concat('&seconds=')
      .concat(String(game.finalTime)),
    {
      //for some reason, these aren't working correctly, will investigate later
      /*name: game.displayName,
      numAttempts: game.finalGuesses,
      seconds: game.finalTime*/
    }
  )
    .then((response) => {
      overlay.value = false
      console.log(response.data)
    })
    .catch((error) => {
      console.log(error)
    })
}

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

Axios.get('word')
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
  game.submitGuess()
  //if(){
  //  endScreen.value = true
  //}
  if (game.status != 0) {
    endScreen.value = true
  }
  guess.value = ''
}

function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
}

function keyPress(event: KeyboardEvent) {
  console.log(event.key)
  if (!nameDialog.value) {
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
</script>
