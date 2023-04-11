<template>
  <div >
      <h1>Wordle Game</h1>
      <v-text-field v-model="guess" label="Label"></v-text-field>

      <v-btn @click="checkGuess">Check</v-btn>

      <h2> 
        {{  guess }}
      </h2>
      <h3>{{  secretWord }}</h3>


  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';

const guess = ref('')
const wordList = ["apple", "banana", "peach", "crypt", "zesty", "color", "piano", "jello", "juice", "pizza"]
const secretWord = wordList[Math.floor(Math.random() * wordList.length)]
console.log(secretWord)

function checkGuess() {
  console.log(guess.value)
  //check length of user input
  if (guess.value.length !== secretWord.length) {
    console.log('wrong length!')
    guess.value = ''
    return
  }

  //check if the letters are valid
  
  //check if the lettes are in the right place

  //
}

//initialize the secret word
//initialize the guess
</script>