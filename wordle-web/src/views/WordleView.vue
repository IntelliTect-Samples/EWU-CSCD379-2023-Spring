<template>
  <v-overlay :model-value="overlay" class="align-center justify-center">
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>

  <h1>Wordle Mind Bender</h1>
  <h1>{{ game.timer }}</h1>

  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <v-row class="justify-center pa-3">
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
    Better Luck Next Time
  </div>
  <div class="text-h4 text-center mt-10" v-if="game.status == WordleGameStatus.Won">You Won!</div>
</template>

<script setup lang="ts">
import { WordleGame, WordleGameStatus } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import { Letter } from '@/scripts/letter'
import Axios from 'axios'
import { WordsService } from '@/scripts/wordsService'

const guess = ref('')
const game = reactive(new WordleGame())
const overlay = ref(true)

// Start a new game
newGame()

onMounted(async () => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

// Not being used just yet, possible relocation
// function addPlayer() {
//   overlay.value = true
//   Axios.post('https://wordlemindbender.azurewebsites.net/Player/AddPlayerFromBody', {
//     name: 'Jacob',
//     gameCount: 5,
//     averageAttempts: 5,
//     averageSecondsPerGame: 600
//   })
//     .then((response) => {
//       setTimeout(() => {
//         overlay.value = false
//       }, 502)
//       console.log(response.data)
//     })
//     .catch((error) => {
//       console.log(error)
//     })
// }

function newGame() {
  overlay.value = true
  Axios.get('word')
    .then((response) => {
      game.restartGame(response.data)
      setTimeout(() => {
        overlay.value = false
      }, 500)
    })
    .catch((error) => {
      console.log(error)
      game.restartGame(WordsService.getRandomWord())
      console.log(game.secretWord)
      overlay.value = false
    })
}

function checkGuess() {
  if (guess.value.length < 5) return
  if (guess.value.length > 5) guess.value = guess.value.slice(0, 5)
  game.submitGuess()
  guess.value = ''
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
