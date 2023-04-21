<template>
  <h1>Wordle Mind Bender</h1>

  <v-btn @click="checkGuess">Check</v-btn>
  <br />
  <div>
    <v-row v-for="word in game.guesses" :key="word.text">
      <v-col v-for="letter in word.letters" :key="letter.char">
        <LetterButton :letter="letter"></LetterButton>
      </v-col>
    </v-row>
  </div>

  <h3>{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'

const game = reactive(new WordleGame())
console.log(game.secretWord)

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function keyPress(e: KeyboardEvent) {
  if (e.key.length === 1) {
    game.currentGuess.push(e.key)
  }
  // Submit on enter
  if (e.key === 'Enter') {
    checkGuess()
  }
  // Clear on backspace
  if (e.key === 'Backspace') {
    game.currentGuess.pop()
  }
}

function checkGuess() {
  game.submitGuess()
}
</script>
