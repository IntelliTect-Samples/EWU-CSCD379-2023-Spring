<template>
  <v-col class="px-16 py-10 my-10" align="center">
    <v-row>
      <v-col> Clip name </v-col>
      <v-col> Points: {{ points }} </v-col>
    </v-row>
    <v-container class="px-4 py-10 my-10" style="max-width: 1000px">
      <iframe
        width="100%"
        height="500"
        src="https://www.youtube.com/embed/_nEOGOC9FPk?controls=0&rel=0&autoplay=1"
        allowfullscreen="true"
      ></iframe>
      <!-- 
        Actual WIK clips 
        https://www.youtube.com/watch?v=_nEOGOC9FPk // kill
        https://www.youtube.com/watch?v=5G2A7WKsCRg // doesnt
        https://www.youtube.com/watch?v=7XjUpd99s18 // faust wins if we wanna do WHO will it kill
        https://twitter.com/EVO/status/1419024349692973061
      -->
    </v-container>

    <v-row class="px-16" style="max-width: 600px">
      <v-btn @click="guessSide(-1)" class="my-8">leftist</v-btn>
      <v-col>
        <h3>{{ points }}</h3>
        <v-text-field class="px-8"></v-text-field>
        <v-text-field label="Example" v-model="example" :rules="exampleRules"></v-text-field>
      </v-col>
      <v-btn @click="guessSide(1)" class="my-8">rightist</v-btn>
    </v-row>

    <v-row class="center px-16" style="max-width: 300px">
      <v-btn @click="submit">SubmitSubmit</v-btn>
    </v-row>
  </v-col>
  <!--
  <v-container>
    <GameBoard :game="game" @letterClick="addChar" />
  </v-container>
  <v-container>
    <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />
    <v-row class="justify-center">
      <v-col cols="auto">
        <input />
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
  -->
</template>

<script lang="ts">
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

const titleRef = ref('')
const guess = ref('')
const game = reactive(new WordleGame())
const route = useRoute()
const timer = ref(0)
let sideGuess = 0
let points = 0
let tracker = setInterval(myTimer, 1000)
let value = 0

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

function guessSide(side: number) {
  sideGuess = side
  //enable submit button
}
function submit() {
  // if betValue > points
  // betValue = points
  // easiest way i can think of to get around """cheating"""
  // if guessSide == correctSide
  // points += betValue
  // else
  // points -= betValue
}
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
    titleRef.value = 'Clip Of The Day'
    if (route.query.date) {
      apiPath += `&date=${route.query.date}`
    }
  } else {
    titleRef.value = 'Will It Kill?'
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
function checkGuess() {
  if (game.submitGuess(route.path, timer.value)) {
    console.log(timer.value)
    clearInterval(tracker)
  }
  guess.value = ''
}
/*
function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
}

function testApi() {
  game.postPlayerToApi('Dan', 4, 20)
}
function setName(name: string) {
  game.setPlayerName(name)
}*/
</script>
