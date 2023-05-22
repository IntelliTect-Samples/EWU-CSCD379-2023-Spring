<template>
  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>

  <div class="text-h4 text-center">Wordle Mind Bender</div>

  <GameBoard :game="game" @letterClick="addChar" />

  <GameKeyboard :guessedLetters="game.guessedLetters" @letterClick="addChar" />

  <v-row class="justify-center">
    <v-btn
      @click="checkGuess"
      @keyup.enter="checkGuess"
      color="primary"
      :size="display.xs ? 'small' : display.sm ? undefined : 'large'"
      v-if="game.status == WordleGameStatus.Active"
    >
      Check
    </v-btn>
    <v-btn
      @click="newGame"
      @keyup.enter="checkGuess"
      color="secondary"
      :size="display.xs ? 'small' : display.sm ? undefined : 'large'"
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
import { ref, reactive, onMounted, onUnmounted, inject, type Ref } from 'vue'
import type { Letter } from '@/scripts/letter'
import Axios from 'axios'
import GameBoard from '../components/GameBoard.vue'
import GameKeyboard from '../components/GameKeyboard.vue'
import WordleSolver from '../components/WordleSolver.vue'
import { WordsService } from '@/scripts/wordsService'
import { useDisplay } from 'vuetify'
import { Player } from '@/scripts/player'
import { Services } from '@/scripts/services'
import type { PlayerService } from '@/scripts/playerService'
import { GameResult } from '@/scripts/gameResult'
import ScoreDialog from '@/components/ScoreDialog.vue'
import { watch } from 'vue'
import { useRoute } from 'vue-router'

const guess = ref('')
const game = reactive(new WordleGame())
const overlay = ref(true)
const showScoreDialog = ref(false)
const lastGameResult: Ref<GameResult> = ref({} as GameResult)
const route = useRoute()

// Add this to make testing work because useDisplay() throws an error when testing
// Wrap useDisplay in a function so that it doesn't get called during testing.
const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>
const playerService = inject(Services.PlayerService) as PlayerService

onMounted(async () => {
  // Start a new game
  await newGame()
  window.addEventListener('keyup', keyUp)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyUp)
})

function newGame() {
  overlay.value = true
  let apiPath = 'word'
  if (route.path == '/wordoftheday') {
    apiPath = `word/wordoftheday?offsetInHours=${new Date().getTimezoneOffset() / -60}`
    if (route.query.date) {
      apiPath += `&date=${route.query.date}`
    }
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
  if (game.status !== WordleGameStatus.Active) {
    sendGameResult()
  }
  guess.value = ''
}

function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
}

function keyUp(event: KeyboardEvent) {
  if (
    document.activeElement?.tagName !== 'INPUT' &&
    document.activeElement?.tagName !== 'TEXTAREA'
  ) {
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

// Watch showScoreDialog and when it changes to true, call newGame()
watch(showScoreDialog, (value) => {
  if (!value) {
    newGame()
  }
})

function sendGameResult() {
  const gameResult = new GameResult()
  gameResult.playerId = playerService.player.playerId
  gameResult.attempts = game.guesses.filter((f) => f.isFilled).length
  gameResult.durationInSeconds = Math.round(game.duration() / 1000)
  gameResult.wasGameWon = game.status == WordleGameStatus.Won
  gameResult.wordPlayed = game.secretWord

  console.log(gameResult)

  lastGameResult.value = gameResult
  showScoreDialog.value = true

  Axios.post('/Player/AddGameResult', gameResult).then((response) => {
    console.log(response.data)
  })
  // if (this.onGameEnd) {
  //   this.onGameEnd(response.data as GameResult)
  // }
}
</script>
