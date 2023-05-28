<template>
  <main class="px-4 mt-4">
    <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
      <v-progress-circular color="primary" indeterminate size="64" />
    </v-overlay>

    <h1 class="wurdleFont">Wurdle play ground</h1>
    <h1 class="wurdleFont">Timer: {{ timer }}</h1>

    <GameBoard :game="game" @letterClick="addChar" />

    <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

    <v-row class="justify-center pa-3 mt-0">
      <v-btn variant="plain" disabled>{{ game.secretWord }}</v-btn>
    </v-row>

    <v-row class="justify-center">
      <v-btn
        @click="checkGuess"
        @keyup.enter="checkGuess"
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
      Oh noo you lost...
    </div>
    <div class="text-h4 text-center mt-10" v-if="game.status == WordleGameStatus.Won">
      You did it! You Won!
    </div>
  </main>
</template>

<script setup lang="ts">
import { WordleGame, WordleGameStatus } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted, inject } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/GameKeyboard.vue'
import { Letter } from '@/scripts/letter'
import Axios from 'axios'
import { WordsService } from '@/scripts/wordsService'
import type { VueCookies } from 'vue-cookies'
const guess = ref('')
const game = reactive(new WordleGame())
const $cookies = inject<VueCookies>('$cookies')
const overlay = ref(true)
let timer = ref(0)
// Start a new game
newGame()
onMounted(async () => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})
function submitGame() {
  const username = $cookies?.get('username')
  Axios.post('https://wurdle.azurewebsites.net/Player/AddPlayerFromBody', {
    name: username,
    numberOfAttempts: game.guesses.indexOf(game.guess),
    elapsedSeconds: timer.value
  }).catch((error) => {
    console.log(error)
  })
}
function newGame() {
  overlay.value = true
  Axios.get('https://wurdle.azurewebsites.net/Word')
    .then((response) => {
      game.restartGame(response.data)
      setTimeout(() => {
        overlay.value = false
      }, 200)
    })
    .catch((error) => {
      console.log(error)
      game.restartGame(WordsService.getRandomWord())
      console.log(game.secretWord)
      overlay.value = false
    })
  timer.value = 0
  let startTimer = setInterval(() => {
    if (game.status == WordleGameStatus.Active) {
      timer.value++
    } else {
      clearInterval(startTimer)
    }
  }, 1000)
}
function checkGuess() {
  if (guess.value.length < 5) return
  if (guess.value.length > 5) guess.value = guess.value.slice(0, 5)
  game.submitGuess()
  guess.value = ''
  if (game.status !== WordleGameStatus.Active) {
    submitGame()
  }
}
function addChar(letter: Letter) {
  if (game.status !== WordleGameStatus.Active) return
  game.guess.push(letter.char)
  guess.value += letter.char
}
function keyPress(event: KeyboardEvent) {
  console.log(event.key)
  if (event.key === 'Enter') {
    checkGuess()
  } else if (event.key === 'Backspace') {
    guess.value = guess.value.slice(0, -1)
    game.guess.pop()
  } else if (event.key.length === 1 && event.key !== ' ') {
    guess.value += event.key.toLowerCase()
    addChar(new Letter(event.key.toLowerCase()))
  }
}
</script>
