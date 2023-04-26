<template>
  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />
  <WordList :game="game"></WordList>
  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>

  <h3>Current secret word: {{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import * as tone from '@/components/audio/click.mp3'
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import { WordsService } from '@/scripts/wordsService'
import WordList from '@/components/WordList.vue'

var audio = new Audio(tone.default)
audio.volume = 0.4
const guess = ref('')
const game = reactive(new WordleGame())
console.log(game.secretWord)

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function checkGuess() {
  if (game.guess.text.length === 5) {
    game.submitGuess()
    guess.value = ''
  }
}

function addChar(letter: Letter) {
  if (game.guess.text.length < 5) {
    audio.play()
    game.guess.push(letter.char)
    game.validWordList = WordsService.validWords(game.guess.text)
  }
}

function keyPress(event: KeyboardEvent) {
  if (event.key === 'Enter') {
    checkGuess()
  } else if (event.key === 'Backspace') {
    guess.value = guess.value.slice(0, -1)
    game.guess.pop()
  }

  if (game.guess.text.length < 5 && event.key.length === 1 && event.key !== ' ') {
    guess.value += event.key.toLowerCase()
    game.guess.push(event.key.toLowerCase())
    game.validWordList = WordsService.validWords(game.guess.text)
  }
}
</script>
