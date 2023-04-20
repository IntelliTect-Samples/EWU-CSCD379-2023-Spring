<template>
  <h1>A play on wordle</h1>
  <div>
    <v-container>
      <GameBoard :game="game" @letterClick="addChar"/>
  </v-container>

  <KeyBoard @letterClick="addChar"/>
  </div>


  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import KeyBoard from '@/components/KeyBoard.vue'
import GameBoard from '@/components/GameBoard.vue'
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, watch, onMounted, onUnmounted } from 'vue'
import KeyBoard from '@/components/KeyBoard.vue'
import GameBoard from '@/components/GameBoard.vue'
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

watch(
  guess,
  (newGuess, oldGuess) => {
    if (newGuess.length > 5) {
      guess.value = oldGuess || ''
    }
  },
  { flush: 'post' }
)

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
  }
  //event.preventDefault()
}
</script>
