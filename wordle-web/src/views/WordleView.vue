<template>

    <div class="d-flex flex-column align-center flex-grow-0 pa-4 mt-8 scale">
    <GameBoard :game="game" @letterClick="addChar" />
    <h2 class="my-1 text-overline">{{ guess || 'Enter a Guess' }}</h2>
    <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" @enter="checkGuess" @delete="deleteClick"/>

  </div>
  <h3>{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'

const guess = ref('')
const game = reactive(new WordleGame())

console.log(game.secretWord)

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function checkGuess() {
  game.submitGuess()
  guess.value = ''
}

function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
}

function deleteClick(){
  guess.value = guess.value.slice(0, -1)
    game.guess.pop()
}

function keyPress(event: KeyboardEvent) {
  console.log(event.key)
  if (event.key === 'Enter') {
    checkGuess()
  } else if (event.key === 'Backspace') {
    guess.value = guess.value.slice(0, -1)
    game.guess.pop()
    console.log('Back')
  } else if (event.key.length === 1 && event.key !== ' ') {
    guess.value += event.key.toLowerCase()
    game.guess.push(event.key.toLowerCase())
  }
}
</script>

<style scoped>
.scale {
  transform: scale(.7,.7);
}
@media screen and (min-width: 400px){
  .scale{
    transform: scale(.8,.8);
  }
}

@media screen and (min-width: 560px){
  .scale{
    transform: scale(1,1);
  }
}


</style>