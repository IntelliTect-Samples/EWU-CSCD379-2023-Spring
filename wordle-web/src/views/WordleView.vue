<template>
  <v-container>
    <h1>Wordle Mind Bender</h1>

    <GameBoard :game="game" @letterClick="addChar" />

    <KeyBoard
      :game="game"
      :guessedLetters="game.guessedLetters"
      @letter-click="addChar($event)"
      @backspace="backspace"
      @check-guess="checkGuess"
    />
    <AvailableWordsButton
      :wordle-game="game"
      :key="game.guesses.length"
      @guessChanged="setGuess"
    />
    <h3>{{ game.secretWord }}</h3>
  </v-container>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import { Letter } from '@/scripts/letter'
import AvailableWordsButton from '@/components/AvailableWordsButton.vue'

const guess = ref('')
const game = reactive(new WordleGame())
console.log(game.secretWord)

function checkGuess() {
  game.submitGuess()
  guess.value = ''
}

function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
}

function backspace() {
  game.guess.pop()
  guess.value = guess.value.slice(0, -1)
}

function setGuess(value: string) {
  for (let i = 0; i < value.length; i++) {
    addChar(new Letter(value[i]))
  }
}
</script>
