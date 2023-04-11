<template>
  <div >
      <h1>Wordle Game</h1>
      <v-text-field v-model="guess" label="Label"></v-text-field>

      <v-btn @click="checkGuess">Check</v-btn>

      <h2> 
        {{  guess }}
      </h2>


  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';

const guess = ref('')
function checkGuess() {console.log(guess.value)}

</script>