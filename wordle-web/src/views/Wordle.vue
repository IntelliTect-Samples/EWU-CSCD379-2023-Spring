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

  <v-text-field v-model="guess" @input="guess = guess.toUpperCase()" label="Guess" variant="solo"></v-text-field>

  <v-btn @click="checkGuess">Submit</v-btn>

  <h3> Your guess: [{{ guess.toUpperCase() }}]</h3>
  <h3> Secret word: [{{ game.secretWord.toUpperCase() }}]</h3>
</template>

<script setup lang="ts">
  import { WordleGame } from '@/scripts/wordleGame'
  import { reactive } from 'vue';
  import { ref } from 'vue';

  const guess = ref('')
  const game = reactive(new WordleGame())

  console.log(game.secretWord)

  function checkGuess() {
    game.submitGuess(guess.value)
  }
  

</script>

<style scoped>
.v-text-field {
  margin-top: 2rem;
}
</style>