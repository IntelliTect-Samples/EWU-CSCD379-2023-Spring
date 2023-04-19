<template>
  <div>
    <v-row v-for="word in game.guesses" :key="word.text">
      <v-col v-for="letter in word.letters" :key="letter.char">
        <v-btn :color="letter.color">
          {{ letter.char.toUpperCase() }}
        </v-btn>
      </v-col>
    </v-row>
  </div>

  <v-text-field
    v-model="guess"
    class="mt-5"
    @input="guess = guess.toUpperCase()"
    label="Guess"
    variant="solo"
  ></v-text-field>

  <v-btn color="primary" @click="checkGuess">Submit</v-btn>
  <v-container>
    <div>Your guess: [{{ guess.toUpperCase() }}]</div>
    <div>Secret word: [{{ game.secretWord.toUpperCase() }}]</div>
  </v-container>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { reactive, ref } from 'vue'

const guess = ref('')
const game = reactive(new WordleGame())

console.log(game.secretWord)

function checkGuess() {
  game.submitGuess(guess.value)
}
</script>
