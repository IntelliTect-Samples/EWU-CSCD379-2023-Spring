<template>
  <div>
    <v-row v-for="word in game.guesses" :key="word.text">
      <v-col v-for="letter in word.letters" :key="letter.char">
        <LetterButton :letter="letter"></LetterButton>
      </v-col>
    </v-row>
  </div>

  <v-btn color="primary" class="mt-5" @click="checkGuess">Submit</v-btn>
  <v-container>
    <div>Your guess: [{{ game.currentGuess.text }}]</div>
    <div>Secret word: [{{ game.secretWord.toUpperCase() }}]</div>
  </v-container>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import LetterButton from '@/components/LetterButton.vue'
import { onMounted, onUnmounted, reactive } from 'vue'

const game = reactive(new WordleGame())

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

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
