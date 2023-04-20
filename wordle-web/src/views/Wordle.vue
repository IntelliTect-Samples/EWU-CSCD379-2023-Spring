<template>
  <h1>Wordle Redux?</h1>
  <v-text-field v-model="guess" label="Guess" variant="solo"></v-text-field>

  <v-btn @click="checkGuess">Check</v-btn>
  <div>
    <v-row v-for="word in game.guesses" :key="word.text">
      <v-col v-for="letter in word.letters" :key="letter.char">
        <LetterButton :letter="letter"></LetterButton>
        <v-btn :color="letter.color">
          {{ letter.char }}
        </v-btn>
      </v-col>
    </v-row>
  </div>

  <h3>{{ game.secretWord }}</h3>
</template>
<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'

const guess = ref('')
const game = reactive(new WordleGame())
console.log(game.secretWord)

onMounted() => {
  window.addEventListener('keyup', keyPress)
}
onUnmounted() => {
  window.removeEventListener('keyup', keyPress)
}

function keyPress(e KeyboardEvent) {
  if (e.key.length == 1) {
    guess.value += e.key
  }

  if(e.key === 'Enter') {
    this.checkGuess()
  }

  if(e.key === 'Backspace') {
    game.currentGuess.pop()
  }
}

function checkGuess() {
  game.submitGuess()
}

//<h3>{{ game.secretWord }}</h3>
</script>
