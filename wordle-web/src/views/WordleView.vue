<template>
  <v-container>
    <GameBoard :game="game" @letterClick="addChar" />
    <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />
    <v-row class="justify-center">
      <v-col cols="auto">
        <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>
      </v-col>
    </v-row>
    <PossibleWords
      @guessClick="checkGuess"
      @wordSelection="selectWord"
      :game="game"
      :guess="guess"
    />
  </v-container>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import PossibleWords from '@/components/PossibleWords.vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'

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
  game.submitGuess()
  guess.value = ''
}

function addChar(letter: Letter) {
  if (guess.value.length < 5) {
    game.guess.push(letter.char)
    guess.value += letter.char
  }
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

function selectWord(selected: string) {
  game.guess.clear()
  guess.value = ''
  for (let letter of selected) {
    game.guess.push(letter)
    guess.value += letter
  }
}
</script>
