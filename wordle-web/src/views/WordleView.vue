<template>
  <v-overlay :model-value="overlay" class="align-center justify-center">
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>

  <h1>Wordle Mind Bender</h1>

  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>
  <h3>{{ game.secretWord }}</h3>

  <v-btn @click="addPlayer()" style="tonal" size="x-small">Add Player Test</v-btn>
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

onMounted(async () => {
  window.addEventListener('keyup', keyPress)
  await game.restartGame()
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function addPlayer() {
  overlay.value = true
  Axios.post('https://wordlemindbender.azurewebsites.net/Player/AddPlayerFromBody', {
    name: 'Jacob',
    gameCount: 5,
    averageAttempts: 5,
    averageSecondsPerGame: 600
  })
    .then((response) => {
      setTimeout(() => {
        overlay.value = false
      }, 502)
      console.log(response.data)
    })
    .catch((error) => {
      console.log(error)
    })
}

function checkGuess() {
  if (guess.value.length < 5) return
  if (guess.value.length > 5) guess.value = guess.value.slice(0, 5)
  game.submitGuess()
  if (game.status === 1) {
    alert('You Win!')
    game.restartGame()
  }
  guess.value = ''
}

function addChar(letter: Letter) {
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
    console.log('Back')
  } else if (event.key.length === 1 && event.key !== ' ') {
    guess.value += event.key.toLowerCase()
    game.guess.push(event.key.toLowerCase())
  }
}
</script>
