<template>
  <h1>Wordle Mind Bender</h1>
  <v-text-field v-model="guess" label="Guess" variant="solo"></v-text-field>

  <v-btn @click="checkGuess">Check</v-btn>
  <div>
    <v-row v-for="word in game.guesses" :key="word.text">
      <v-col v-for="letter in word.letters" :key="letter.char">
        <v-btn :color="letter.color">
          {{ letter.char }}
        </v-btn>
      </v-col>
    </v-row>
  </div>

  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive } from 'vue'

const guess = ref('')
const game = reactive(new WordleGame())
console.log(game.secretWord)

function checkGuess() {
  game.submitGuess(guess.value)
}
</script>
