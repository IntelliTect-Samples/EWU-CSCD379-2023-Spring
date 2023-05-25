<template>
  <v-row class="justify-center"
    ><h1>{{ titleRef }}</h1></v-row
  >
  <v-container>
    <GameBoard :game="game" @letterClick="addChar" />
  </v-container>
  <v-container>
    <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />
    <v-row class="justify-center">
      <v-col cols="auto">
        <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>
      </v-col>
      <v-col cols="auto"> </v-col>
    </v-row>
  </v-container>
  <h2>{{ timer }}</h2>
  <h3>{{ game.secretWord }}</h3>

  <v-container id="list">
    <ValidWords @fillGuess="autoComplete" :game="game"></ValidWords>
  </v-container>

  <v-btn @click="testApi">API</v-btn>
  <NameCardDialog :playerName="game.currentPlayer" @enterChar="setName"></NameCardDialog>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import ValidWords from '../components/ValidWords.vue'
import type { Letter } from '@/scripts/letter'
import NameCardDialog from '@/components/NameCardDialog.vue'
import { useRoute } from 'vue-router'
import Axios from 'axios'
import { WordsService } from '@/scripts/wordsService'

const titleRef = ref('Wordle')
const guess = ref('')
const game = reactive(new WordleGame())
const route = useRoute()
const timer = ref(0)
let tracker = setInterval(myTimer, 1000)

console.log(game.secretWord)
onMounted(async () => {
  window.addEventListener('keyup', keyPress)
  await newGame()
  //console.log(game.secretWord)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function newGame() {
  let apiPath = 'word'
  if (route.path == '/wordoftheday') {
    apiPath = `word/wordoftheday?offsetInHours=${new Date().getTimezoneOffset() / -60}`
    titleRef.value = 'Word Of The Day'
    if (route.query.date) {
      apiPath += `&date=${route.query.date}`
    }
  } else {
    titleRef.value = 'Wordle'
  }
  Axios.get(apiPath)
    .then((response) => {
      game.restartGame(response.data)
      console.log(game.secretWord)
    })
    .catch((error) => {
      console.log(error)
      game.restartGame(WordsService.getRandomWord())
      console.log(game.secretWord)
    })
  clearInterval(tracker)
  tracker = setInterval(myTimer, 1000)
}

function myTimer() {
  timer.value = timer.value + 1
}
function autoComplete(fill: string) {
  while (game.guess.text !== '') {
    game.guess.pop()
  }
  for (let i = 0; i < fill.length; i++) {
    game.guess.push(fill.charAt(i))
  }
}
function checkGuess() {
  if (game.submitGuess(route.path, timer.value)) {
    console.log(timer.value)
    clearInterval(tracker)
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

function testApi() {
  game.postPlayerToApi('Dan', 4, 20)
}
function setName(name: string) {
  game.setPlayerName(name)
}
</script>
