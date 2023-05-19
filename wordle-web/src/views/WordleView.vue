<template>
  <div class="text-center">
    <h1>The Good Word</h1>
    <br />

    <GameBoard :game="game" @letterClick="addChar" />
    <br />

    <div>
      <v-responsive class="mx-auto" max-width="300">
        <v-select
          v-model="guess"
          :items="validGuesses"
          :label="'Valid Guesses: ' + validGuesses.length"
          @update:model-value="inputFromValidGuesses"
        >
          <v-hover></v-hover>
        </v-select>
      </v-responsive>
    </div>

    <v-divider></v-divider>
    <br />

    <GameKeyboard
      :guessedLetters="game.guessedLetters"
      @letterClick="addChar"
      @backspaceClick="removeLastChar"
      @enterClick="checkGuess"
    />
  </div>

  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>

  <ScoreDialog v-model="showScoreDialog" :game-result="lastGameResult" />
</template>

<script setup lang="ts">
import { WordleGame, WordleGameStatus } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted, inject, type Ref } from 'vue'
import type { Letter } from '@/scripts/letter'
import Axios from 'axios'
import { WordsService } from '@/scripts/Services/wordsService'
import GameBoard from '../components/GameBoard.vue'
import GameKeyboard from '../components/GameKeyboard.vue'
import { useDisplay } from 'vuetify'
import { Services } from '@/scripts/Services/services'
import type { PlayerService } from '@/scripts/Services/playerService'
import { GameResult } from '@/scripts/gameResult'
import { watch } from 'vue'
import ScoreDialog from '@/components/ScoreDialog.vue'

let validGuesses = new Array<string>()
let username = ref(localStorage.getItem('username') || 'Guest')
let timer = ref(0)

const guess = ref('')
const overlay = ref(true)
const game = reactive(new WordleGame())
const showScoreDialog = ref(false)
const lastGameResult: Ref<GameResult> = ref({} as GameResult)

// Add this to make testing work because useDisplay() throws an error when testing
// Wrap useDisplay in a function so that it doesn't get called during testing.
const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>
const playerService = inject(Services.PlayerService) as PlayerService

onMounted(async () => {
  // Start a new game
  newGame()
  window.addEventListener('keyup', keyUp)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyUp)
})

function newGame() {
  overlay.value = true
  Axios.get('Word')
    .then((response) => {
      game.startNewGame(response.data)
      console.log(game.secretWord)
      setTimeout(() => {
        overlay.value = false
      }, 502)
    })
    .catch((error) => {
      console.log(error)
      game.startNewGame(WordsService.getRandomWord())
      console.log(game.secretWord)
      overlay.value = false
    })
}

function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
  getValidGuesses()
}

function removeLastChar() {
  guess.value = guess.value.slice(0, -1)
  getValidGuesses()
  game.guess.pop()
}

function checkGuess() {
  // TODO: Add a UI effect to show that the guess is not of right length.
  if (game.guess.text.length !== game.secretWord.length) {
    console.log('Guess is not of the right length')
    return
  }

  game.submitGuess()
  guess.value = ''
  getValidGuesses()
  if (game.status !== WordleGameStatus.Active) {
    sendGameResult()
  }
}

// function checkGuess(word?: string) {
//   if (typeof word === 'string') {
//     game.guess.set(word)
//   }
//
//   if (game.guess.text.length !== game.secretWord.length) {
//     console.log('Guess is not of the right length')
//     return
//   }
//
//   game.submitGuess()
//   guess.value = ''
//   getValidGuesses()
//
//   if (game.status !== WordleGameStatus.Active) {
//     sendGameResult()
//   }
// }

function getValidGuesses() {
  validGuesses = WordsService.validWords(guess.value)
}

function inputFromValidGuesses() {
  const index = game.guess.text.length

  for (let i = 0; i < index; i++) {
    game.guess.pop()
  }

  for (let i = 0; i < 5; i++) {
    game.guess.push(guess.value[i])
  }
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
