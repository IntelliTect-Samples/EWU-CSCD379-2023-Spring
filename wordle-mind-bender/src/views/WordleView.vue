<template>
  <main>
    <GameBoard :game="game" @letterClick="addChar" />

    <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

    <v-row dense class="justify-center" cols="auto">
      <v-col cols="auto">
        <AvailableWords></AvailableWords>
      </v-col>
      <v-col cols="auto">
        <v-btn
          @click="checkGuess"
          color="teal"
          style="background-image: var(--btn-gradient)"
          class="elevation-7"
        >
          Check
        </v-btn>
      </v-col>
      <v-col cols="auto">
        <v-btn
          @click="deleteChar"
          color="teal"
          style="background-image: var(--btn-gradient)"
          class="elevation-7"
        >
          <v-icon icon="mdi-backspace"></v-icon>
        </v-btn>
      </v-col>
      <v-col cols="auto">
        <v-btn
          color="teal"
          style="background-image: var(--btn-gradient)"
          variant="tonal"
          class="elevation-7"
        >
          {{ game.secretWord }}
        </v-btn>
      </v-col>
    </v-row>
  </main>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import AvailableWords from '../components/AvailableWords.vue'

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
  if (guess.value.length == game.secretWord.length) {
    game.submitGuess()
    guess.value = ''
  }
}

function deleteChar() {
  game.guess.pop()
  guess.value = guess.value.slice(0, -1)
}

function addChar(letter: Letter) {
  if (guess.value.length < game.secretWord.length) {
    game.guess.push(letter.char)
    guess.value += letter.char
  }
}

function keyPress(event: KeyboardEvent) {
  console.log(event.key)
  if (event.key === 'Enter') {
    checkGuess()
  } else if (event.key === 'Backspace') {
    guess.value = guess.value.slice(0, -1)
    game.guess.pop()
    console.log('Back')
  } else if (
    event.key.length === 1 &&
    event.key !== ' ' &&
    guess.value.length < game.secretWord.length
  ) {
    guess.value += event.key.toLowerCase()
    game.guess.push(event.key.toLowerCase())
  }
}
</script>

<style></style>
