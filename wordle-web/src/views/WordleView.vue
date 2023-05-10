<template>
  <h1>Wordle Redux</h1> 
  <v-col class="text-right">
  <h1>Time: {{ min }} : {{ sec }}</h1>
  <setUsername/> 
  </v-col>

  <div class="text-h4 text-center mt-10" v-if="game.status == WordleGameStatus.Lost">Better Luck Next Time</div>
  <div class="text-h4 text-center mt-10" v-if="game.status == WordleGameStatus.Won">You Won!</div>

  <GameBoard :game="game" @letterClick="addChar" />

  <p>Guess: {{ guess }}</p>

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />
  <v-row class="justify-center">
    <v-btn @click="checkGuess" @keyup.enter="checkGuess" color="primary" > Check </v-btn>
  </v-row>

  <!-- <h2>{{ guess }}</h2> -->
  <h3>{{ game.secretWord }}</h3>

  <ValidWordList :items="game.validWords" @change="select" />
</template>

<script setup lang="ts">
import { WordleGame, WordleGameStatus,  } from '@/scripts/wordleGame'
import { ref, reactive, computed } from 'vue';
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import { watch, onMounted, onUnmounted } from 'vue'
import ValidWordList from '../components/ValidWordList.vue'
import clicking_button from '@/assets/clicking_button_sound.mp3'
import guess_button from '@/assets/guess_button_sound.mp3'
import Axios from 'axios'
import setUsername from '@/components/SetUsername.vue'
import username from '@/components/SetUsername.vue'

const guess = ref('')
const game = reactive(new WordleGame())
const guessSound = new Audio(guess_button)
const clickSound = new Audio(clicking_button)
const timer = ref(0)
const sec = ref(0)
const min = ref(0)
startGame()
const overlay = ref(true)


console.log(game.secretWord)

onMounted(async () => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})


function startGame() {
  //should restart game here
  timer.value = 0
  sec.value = 0
  let check = setInterval(() => {
    if(game.status == WordleGameStatus.Won || game.status == WordleGameStatus.Lost){
      clearInterval(check)
      overlay.value = true
      Axios.post(username.value, timer.value, <any>game.numberOfGuesses)
        .then((response) => {
        overlay.value = false
        console.log(response.data)
      })
      
        .catch((error) => {
        console.log(error)
      })
    } else {
      timer.value += 1
      sec.value += 1
    }
  }, 1000)
}


/*
function addWord() {
  overlay.value = true
  Axios.post('word/AddWordFromBody', {
    text: 'strin',
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
  })
*/
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
