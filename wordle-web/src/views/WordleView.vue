<template>
  <main>
    <br />
    <h1>Wordle Mind Bender</h1>
    <br />
      <v-text-field v-model="guess" label="Guess" variant="solo" @input="getValidGuesses" bg-color="blue-grey-darken-4"></v-text-field>
      
      <v-select v-model="guess" :items="validGuesses" :label="'Valid Guesses: ' + validGuesses.length" bg-color="blue-grey-darken-4" >
        <v-hover></v-hover>
      </v-select>
    <br />

    <v-btn @click="checkGuess">Check</v-btn>
    <div>
      <v-row v-for="word in game.guesses" :key="word.text">
        <v-col v-for="letter in word.letters" :key="letter.char">
          <v-card :color="letter.color">
            <v-card-title>{{ letter.char }}</v-card-title>
          </v-card>
        </v-col>
      </v-row>
    </div>
    <div>
      <br />
      <h2>Guess: {{ guess }}</h2>
      <br />
      <h3>Secret Word: {{ game.secretWord }}</h3>
    </div>
  </main>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive } from 'vue'
import { WordsService } from '@/scripts/wordsService'

let validGuesses = WordsService.validWords('')
const guess = ref('')
const game = reactive(new WordleGame())
console.log(game.secretWord)

function checkGuess() {
  game.submitGuess(guess.value)
}

function getValidGuesses() {
  validGuesses = WordsService.validWords(guess.value)
}
</script>
