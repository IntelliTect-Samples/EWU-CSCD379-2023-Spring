<template>
  <ActiveUser />

  <h1 class="justify">Wordle Mind Bender</h1>
  <GameBoard :game="game" @letterClick="addChar" />
  <div class="d-flex justify-end">
    <div>Time: {{ duration }}</div>
  </div>

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>

  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>

  <ScoreDialog v-model="showScoreDialog" :game-result="lastGameResult" />
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import type { GameResult } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import Axios from 'axios'
import { Player } from '@/scripts/userService'
import ActiveUser from '@/components/currentUser.vue'
import ScoreDialog from '@/components/ScoreDialog.vue'
import { watch } from 'vue'
import { formatTime } from '@/scripts/time'
import { computed } from 'vue'

const guess = ref('')
const game = reactive(new WordleGame())
game.onGameEnd = onGameEnd
restartGame()

const time = ref(0)
const duration = computed(() => formatTime(time.value))
const showScoreDialog = ref(false)
const lastGameResult = ref<GameResult>()
watch(showScoreDialog, (value) => {
  if (!value) {
    restartGame()
  }
})

let interval: any

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

function checkGuess() {
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
  Axios.get('/word')
    .then((response) => {
      game.restartGame(response.data)
      console.log(game.secretWord)
    })
    .catch((error) => {
      console.log(error)
    })
}

function onGameEnd(result: GameResult) {
  console.log('result', result)
  lastGameResult.value = result
  showScoreDialog.value = true
}
</script>
