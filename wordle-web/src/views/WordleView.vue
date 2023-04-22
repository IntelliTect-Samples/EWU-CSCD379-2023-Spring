<template>
  <h1>Wordle Mind Bender</h1>

  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <WordSelect :validWords = validWords />

  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>

  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import KeyBoard from '@/components/KeyBoard.vue'
import GameBoard from '@/components/GameBoard.vue'
import HeaderBar from '@/components/HeaderBar.vue'
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, watch, onMounted, onUnmounted } from 'vue'
import type { Letter } from '@/scripts/letter'
import WordSelect from '../components/WordSelect.vue'
import { WordsService } from '../scripts/wordsService'

const guess = ref('')
const game = reactive(new WordleGame())
console.log(game.secretWord)
let validWords:Array<string> = ['these', 'are', 'valid', 'words']

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function checkGuess() {
  game.submitGuess()
  guess.value = ''
}

function addChar(letter: Letter) {
  guess.value += letter.char
  game.guess.push(letter.char)
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
    validWords = WordsService.validWords(guess.value)
  }
}
</script>
