<template>
  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>

  <div class="text-h4 text-center">
    <span v-if="isWordOfTheDay"
      > Wordle of the Day
      </span>
    <span v-else>Wordle Redux</span>
  </div>

  <v-col class="text-right">
  <h1>Time: {{ min }} : {{ sec }}</h1>
  <setUsername/> 
  </v-col>

  <div class="text-h4 text-center mt-10" v-if="game.status == WordleGameStatus.Lost">Better Luck Next Time</div>
  <div class="text-h4 text-center mt-10" v-if="game.status == WordleGameStatus.Won">You win!</div>

  <GameBoard :game="game" @letterClick="addChar" />

  <p>Guess: {{ guess }}</p>

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />
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
      @click="startGame"
      @keyup.enter="checkGuess"
      color="secondary"
      :size="display.xs ? 'small' : display.sm ? undefined : 'large'"
      v-if="game.status !== WordleGameStatus.Active"
    >
      New Game
    </v-btn>
  </v-row>

  <!-- <h2>{{ guess }}</h2> -->
  <h3>{{ game.secretWord }}</h3>

  <ValidWordList :items="game.validWords" @change="select" />
</template>

<script setup lang="ts">
import { WordleGame, WordleGameStatus } from '@/scripts/wordleGame'
import { ref, reactive } from 'vue';
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import { watch, onMounted, onUnmounted } from 'vue'
import ValidWordList from '../components/ValidWordList.vue'
import clicking_button from '@/assets/clicking_button_sound.mp3'
import guess_button from '@/assets/guess_button_sound.mp3'
import Axios from 'axios'
import setUsername from '@/components/SetUsername.vue'
import {WordsService} from '@/scripts/wordsService'
import { useRoute } from 'vue-router'
import { inject } from 'vue'
import { Services } from '@/scripts/services'
import { useDisplay } from 'vuetify'
import type { SignInService } from '@/scripts/signInService'


const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>
const signInService = inject(Services.SignInService) as SignInService

const guess = ref('')
const game = reactive(new WordleGame())
const guessSound = new Audio(guess_button)
const clickSound = new Audio(clicking_button)
const timer = ref(0)
const sec = ref(0)
const min = ref(0)
const overlay = ref(true)
const isWordOfTheDay = ref(false)
const wordOfTheDayDate = ref<Date | null>(null)
const route = useRoute()
const pat = ref<string>(route.path)

var todayword = ref<todayWord[]>([])

interface todayWord {
  word: string
  date: Date
}



console.log(game.secretWord)

onMounted(async () => {
  startGame()
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

watch(
  () => signInService.token,
  (value) => {
    console.log(`Signed in user: ${value.userName}`)
  }
)

function startGame() {
  //should restart game here
  if(pat.value == '/worldoftheday'){
    isWordOfTheDay.value = true
  } else {
    isWordOfTheDay.value = false
  }
  
  overlay.value = true
  let apiPath = 'word'
  if (isWordOfTheDay.value) {
    apiPath = `word/wordOfTheDay?offsetInHours=${new Date().getTimezoneOffset() / -60} `
    if(route.query.date){
      apiPath += `&date=${route.query.date}`
    }
    Axios.get(apiPath)
    .then((response) => {
      todayword.value = [response.data]
      game.restartGame(todayword.value[0].word)
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
  } else {
  apiPath = 'word'
  
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

  timer.value = 0
  sec.value = 0
  let check = setInterval(() => {
    if(game.status == WordleGameStatus.Won || game.status == WordleGameStatus.Lost){
      clearInterval(check)
      if(pat.value == '/worldoftheday'){
        Axios.post(`Player/AddGameResult?Name=${localStorage.getItem('username')}&WasGameWon=${true}&Attempts=${game.guessNum}&TimeInSecounds=${timer.value}&WordPlayed=${game.secretWord}&WordOfTheDayDate=${todayword.value[0].date}`)
        .then((response): void => {
          console.log(response.data)
      }) 
          .catch((error) => {
          console.log(error)
      })}
      else{
        Axios.post(`Player/AddPlayer?newName=${localStorage.getItem('username')}&playTime=${timer.value}&guesses=${game.guessNum}`)
        .then((response): void => {
          console.log(response.data)
        }) 
          .catch((error) => {
          console.log(error)
        })}
    } else {
      timer.value += 1
      sec.value += 1
    }
  }, 1000)
}

watch(
  guess,
  (newGuess, oldGuess) => {
    UpdateSelect(newGuess)
    if (newGuess.length > 5) {
      guess.value = oldGuess || ''
    }
  },
  { flush: 'post' }
)
watch(
  sec, 
  (newVal) => {
    if (sec.value > 59) {
      sec.value = 0
      min.value += 1
    }
  }
)
watch(
  () => route.path,
  (newPath, oldPath) => {
    if (newPath !== pat.value) {
      pat.value = newPath;
      startGame();
    }
  }
)




function checkGuess() {
  if(game.status == WordleGameStatus.Won || game.status == WordleGameStatus.Lost){
    return
  }
  guessSound.play()
  game.submitGuess()
  guess.value = ''
}

function select(validguess: string) {
  guess.value = validguess
}

function UpdateSelect(g: string) {
  const temp = g.split('')
  for (let i = 0; i < 5; i++) {
    game.guess.pop()
  }
  for (let i = 0; i < temp.length; i++) {
    game.guess.push(temp[i])
  }
}

function addChar(letter: Letter) {
  

  if(game.status == WordleGameStatus.Won || game.status == WordleGameStatus.Lost){
    return
  }
  clickSound.play()
  game.guess.push(letter.char)
  guess.value += letter.char
}

function keyPress(event: KeyboardEvent) {
  console.log(event.key)
  if(game.status == WordleGameStatus.Won || game.status == WordleGameStatus.Lost){
    return
  }
  if (event.key === 'Enter') {
    checkGuess()
  } else if (event.key === 'Backspace') {
    clickSound.play()
    guess.value = guess.value.slice(0, -1)
    game.guess.pop()
    console.log('Back')
  } else if (event.key.length === 1 && event.key !== ' ') {
    clickSound.play()
    guess.value += event.key.toLowerCase()
    game.guess.push(event.key.toLowerCase())
  }
  //event.preventDefault()
}
</script>
