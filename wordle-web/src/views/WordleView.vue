<template>
  <ThemeChoice/>
  <h1>A play on wordle</h1>
  <div>
    <v-container>
      <GameBoard :game="game" @letterClick="addChar"/>
  </v-container>
  </div>

  <v-container>
    <KeyBoard @letterClick="addChar"/>
  </v-container>

  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive } from 'vue'

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
  game.submitGuess(guess.value)
}
</script>
