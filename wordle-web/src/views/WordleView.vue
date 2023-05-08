<template>
  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>

  <div class="text-h4 text-center">Wordle Mind Bender</div>
  <div class="d-flex justify-end">
    <div class="text-h4 text-center">Time Passed: {{ duration }}</div>
    <ActiveUser />
  </div>
  <h1 class="justify">Wordle Mind Bender</h1>
  <GameBoard :game="game" @letterClick="addChar" />

  <GameKeyboard :guessedLetters="game.guessedLetters" @letterClick="addChar" />

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

  <v-row class="justify-center" v-if="game.status == WordleGameStatus.Active">
    <v-col xs="11" sm="9" md="6" lg="4">
      <WordleSolver :game="game" @wordClick="(value: string) => checkGuess(value)"></WordleSolver>
    </v-col>
  </v-row>

  <ScoreDialog v-model="showScoreDialog" :game-result="lastGameResult" />
</template>

<script setup lang="ts">
import { WordleGame, WordleGameStatus } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import type { Letter } from '@/scripts/letter'
import type { PlayerResult } from '@/scripts/wordleGame'
import Axios from 'axios'
import GameBoard from '../components/GameBoard.vue'
import GameKeyboard from '../components/GameKeyboard.vue'

import { WordsService } from '@/scripts/wordsService'
import { Player } from '@/scripts/playerService'
import ActiveUser from '@/components/CurrentUser.vue'
import ScoreDialog from '@/components/ScoreDialog.vue'
import { watch } from 'vue'
import { formatTime } from '@/scripts/timer'
import { computed } from 'vue'

const guess = ref('')
const game = reactive(new WordleGame())
const overlay = ref(true)

game.onGameEnd = onGameEnd
restartGame()
const time = ref(0)
const duration = computed(() => formatTime(time.value))
const showScoreDialog = ref(false)
const lastGameResult = ref<PlayerResult>()
watch(showScoreDialog, (value) => {
  if (!value) {
    restartGame()
  }
})
let interval: any
// Start a new game
newGame()

onMounted(async () => {
  window.addEventListener('keyup', keyPress)
  interval = setInterval(() => {
    time.value = Date.now() - game.startTime
  }, 1000)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
  clearInterval(interval)
})

function addWord() {
  overlay.value = true
  Axios.post('word/AddWordFromBody', {
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
      game.restartGame(WordsService.getRandomWord())
      console.log(game.secretWord)
      overlay.value = false
    })
}

function checkGuess(word?: string) {
  if (typeof word === 'string') {
    game.guess.set(word)
  }
  game.submitGuess()
  guess.value = ''
}

function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
}

function keyPress(event: KeyboardEvent) {
  console.log(event.key)
  if (Player.TypingName.value) {
    return
  }
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
async function restartGame() {
  Axios.get('word')
    .then((response) => {
      game.restartGame(response.data)
      console.log(game.secretWord)
    })
    .catch((error) => {
      console.log(error)
    })
}
function onGameEnd(result: PlayerResult) {
  console.log('result', result)
  lastGameResult.value = result
  showScoreDialog.value = true
}
</script>
