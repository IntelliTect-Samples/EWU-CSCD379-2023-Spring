<template>
  <h1>Wordle Redux</h1>

  <GameBoard :game="game" @letterClick="addChar" />

  <p>Guess: {{ guess }}</p>

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />
  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>

  <!-- <h2>{{ guess }}</h2> -->
  <h3>{{ game.secretWord }}</h3>

  <ValidWordList :items="game.validWords" @change="select" />
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import { watch, onMounted, onUnmounted } from 'vue'
import ValidWordList from '../components/ValidWordList.vue'
import clicking_button from '@/assets/clicking_button_sound.mp3'
import guess_button from '@/assets/guess_button_sound.mp3'

const guess = ref('')
const game = reactive(new WordleGame())
const guessSound = new Audio(guess_button)
const clickSound = new Audio(clicking_button)

console.log(game.secretWord)

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

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

function checkGuess() {
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
  clickSound.play()
  game.guess.push(letter.char)
  guess.value += letter.char
}

function keyPress(event: KeyboardEvent) {
  console.log(event.key)
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
