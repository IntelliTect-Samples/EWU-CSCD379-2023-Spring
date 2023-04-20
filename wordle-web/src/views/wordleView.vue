<template>
  <h1>WORDLE</h1>
  <v-text-field clearable label="Word Guess" variant="outlined" ></v-text-field>

  <v-btn tonal @click="checkGuess">Submit</v-btn>
  <div>
    <v-row v-for="word in game.guesses" :key="word.text">
      <v-col v-for="letter in word.letters" :key="letter.char">
        <LetterButton :letter="letter"> </LetterButton>
      </v-col>
    </v-row>
  </div>
  
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import LetterButton from '@/components/LetterButton.vue';
import { ref, reactive } from 'vue'
import { onMounted } from 'vue';
import { onUnmounted } from 'vue';

//const guess = ref('')
const game = reactive(new WordleGame())
console.log(game.secretWord)

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function keyPress( e: KeyboardEvent){
  if(e.key.length === 1){
    game.currentGuess.push(e.key)
  }

  if(e.key ==="Enter"){
    checkGuess()
  }

  if(e.key === "Backspace"){
    game.currentGuess.pop()
  }
}
function checkGuess() {
  game.submitGuess()
}
</script>
