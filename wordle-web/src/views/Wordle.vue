<template>
  <h1>Wordle Redux?</h1>
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
  <div>
    <v-btn :color="letter.color">A</v-btn>
    <v-btn :color="letter.color">B</v-btn>
    <v-btn :color="letter.color">C</v-btn>
    <v-btn :color="letter.color">D</v-btn>
    <v-btn :color="letter.color">E</v-btn>
    <v-btn :color="letter.color">F</v-btn>
    <v-btn :color="letter.color">G</v-btn>
    <v-btn :color="letter.color">H</v-btn> 
    <v-btn :color="letter.color">I</v-btn> 
    <v-btn :color="letter.color">J</v-btn> 
    <v-btn :color="letter.color">K</v-btn> 
    <v-btn :color="letter.color">L</v-btn> 
    <v-btn :color="letter.color">M</v-btn> 
    <v-btn :color="letter.color">N</v-btn> 
    <v-btn :color="letter.color">O</v-btn> 
    <v-btn :color="letter.color">P</v-btn> 
    <v-btn :color="letter.color">Q</v-btn> 
    <v-btn :color="letter.color">R</v-btn> 
    <v-btn :color="letter.color">S</v-btn> 
    <v-btn :color="letter.color">T</v-btn> 
    <v-btn :color="letter.color">U</v-btn> 
    <v-btn :color="letter.color">V</v-btn> 
    <v-btn :color="letter.color">W</v-btn> 
    <v-btn :color="letter.color">X</v-btn> 
    <v-btn :color="letter.color">Y</v-btn> 
    <v-btn :color="letter.color">Z</v-btn>      
  </div>
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

//<h3>{{ game.secretWord }}</h3>
</script>
