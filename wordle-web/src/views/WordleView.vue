<template>
  <br />

  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>

  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import { WordleGame, WordleGameStatus } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import { useCookies } from 'vue3-cookies'
import axios from 'axios'

const { cookies } = useCookies()
const playerName = ref(cookies.get('playerName'))
const guess = ref('')
const game = reactive(new WordleGame())

onMounted(async () => {
  window.addEventListener('keyup', keyPress)
  await game.restartGame()
  console.log(game.secretWord)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function checkGuess() {
  console.log('Submitting game')
  submitGame()
  game.submitGuess()
  guess.value = ''
  if (game.status === WordleGameStatus.Won) {
    console.log('You won!')
  }
}

function submitGame() {
  const GameCount = 1
  const AverageAttempts = parseFloat((Math.random() * 4 + 1).toFixed(2))

  const player = {
    Name: playerName.value,
    GameCount: GameCount,
    AverageAttempts: AverageAttempts
  }

  console.log('Submitting game')
  console.log(player)

  axios
    .post('https://wordle-assignment3.azurewebsites.net/leaderboard', player)
    .then((response) => {
      console.log(response.data)
    })
    .catch((error) => {
      console.log(error)
    })
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
