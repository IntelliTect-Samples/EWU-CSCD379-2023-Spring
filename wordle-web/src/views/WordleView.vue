<template>
  <main>
    <br />
    <h1>Wordle Mind Bender</h1>
    <br />
    <v-text-field v-model="guess" label="Guess" variant="solo"></v-text-field>

    <br />

    <v-btn @click="checkGuess">Check</v-btn>
    <div>
      <v-row v-for="word in guesses">
        <v-col v-for="letter in word" :key="letter.letter">
          <v-card :color="letter.color">
            <v-card-title>{{ letter.letter }}</v-card-title>
          </v-card>
        </v-col>
      </v-row>
    </div>
    <div>
      <br />
      <h2>Guess: {{ guess }}</h2>
      <br />
      <h3>Secret Word: {{ secretWord }}</h3>
    </div>
  </main>
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
