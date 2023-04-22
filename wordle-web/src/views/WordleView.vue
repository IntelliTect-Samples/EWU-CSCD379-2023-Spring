<template>
  <GameBoard :game="game" />
  <div class="mt-10"><KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" /></div>
  <v-container>
    <div>Your guess: [{{ game.currentGuess.text }}]</div>
    <div>Secret word: [{{ game.secretWord.toUpperCase() }}]</div>
  </v-container>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import type { Letter } from '@/scripts/letter'
import GameBoard from '@/components/GameBoard.vue'
import KeyBoard from '@/components/KeyBoard.vue'
import { onMounted, onUnmounted, reactive } from 'vue'

const game = reactive(new WordleGame())

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function addChar(letter: Letter) {
  game.currentGuess.push(letter.char)
}

function keyPress(event: KeyboardEvent) {
  if (event.key.length === 1) {
    game.currentGuess.push(event.key.toUpperCase())
  } else if (event.key === 'Backspace') {
    game.currentGuess.pop()
  } else if (event.key === 'Enter') {
    checkGuess()
  }
}

function checkGuess() {
  game.submitGuess()
}
</script>
