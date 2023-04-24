<template>
  <div class="d-flex flex-column align-center">
    <GameBoard :game="game" @letterClick="addChar" />
    <AvailableWords :game="game" class="my-2" />
    <KeyBoard
      @letterClick="addChar"
      :guessedLetters="game.guessedLetters"
      @enter="checkGuess"
      @delete="deleteClick"
    />
  </div>
  <h3>{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import AvailableWords from '../components/AvailableWords.vue'

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
  game.guess.push(letter.char)
  guess.value += letter.char
}

function deleteClick() {
  guess.value = guess.value.slice(0, -1)
  game.guess.pop()
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
</script>
