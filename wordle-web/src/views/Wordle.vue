<template>
  <div >
      {{ count }}
      <h1>Wordle Game</h1>
      <v-text-field v-model="guess" label="Label"></v-text-field>

      <h2> 
        {{  guess }}
      </h2>

      <v-btn @click="checkGuess">Check</v-btn>

  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
function checkGuess() {console.log(guess.value)}
const guess = ref('')
const count = ref(1)
setInterval(() => { count.value++}, 1000 )
</script>