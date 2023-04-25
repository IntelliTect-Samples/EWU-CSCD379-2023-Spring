<template>
  <main class="align-center">
    <br />
    <h1>The Good Word</h1>
    <br />

    <div>
      <GameBoard :game="game" @letterClick="addChar" />
      <br />
    </div>

    <div>
      <v-responsive class="mx-auto" max-width="300">
        <v-select
          v-model="guess"
          :items="validGuesses"
          :label="'Valid Guesses: ' + validGuesses.length"
          @update:model-value="inputFromValidGuesses"
        >
          <v-hover></v-hover>
        </v-select>
      </v-responsive>
    </div>

    <v-divider></v-divider>

    <br />

    <div>
      <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />
      <v-row dense class="justify-center" cols="auto">
        <v-col cols="auto">
          <v-btn
            @click="checkGuess"
            class="elevation-10"
            style="background-image: var(--btn-gradient)"
          >
            Check
          </v-btn>
        </v-col>
        <v-col cols="auto">
          <v-btn
            @click="toggleText"
            class="elevation-10"
            style="background-image: var(--btn-gradient)"
            >{{ buttonText }}</v-btn
          >
        </v-col>
      </v-row>
    </div>
  </main>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import { watch, onMounted, onUnmounted } from 'vue'
import { WordsService } from '@/scripts/wordsService'

let validGuesses = new Array<string>()
let validWord = ''
// TODO: Possible refactor 'buttonText' to prevent hardcoding.
let buttonText = ref('Display correct word')
const guess = ref('')
const game = reactive(new WordleGame())

console.log(game.secretWord)

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

watch(
  guess,
  (newGuess, oldGuess) => {
    if (newGuess.length > 5) {
      guess.value = oldGuess || ''
    }
  },
  { flush: 'post' }
)

// TODO: Possible refactor 'buttonText' to prevent hardcoding.
function toggleText() {
  buttonText.value =
    buttonText.value === `${game.secretWord}` ? 'Display correct word' : `${game.secretWord}`
}

function checkGuess() {
  // TODO: Add a UI effect to show that the guess is not of right length.
  if (game.guess.text.length !== game.secretWord.length) {
    console.log('Guess is not of the right length')
    return
  }

  game.submitGuess()
  guess.value = ''
  getValidGuesses()
}

function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
  getValidGuesses()
}

function keyPress(event: KeyboardEvent) {
  console.log(event.key)
  if (event.key === 'Enter') {
    checkGuess()
  } else if (event.key === 'Backspace') {
    guess.value = guess.value.slice(0, -1)
    console.log(validWord)
    getValidGuesses()
    game.guess.pop()
    console.log('Back')
  } else if (event.key.length === 1 && event.key !== ' ') {
    guess.value += event.key.toLowerCase()
    console.log(validWord)
    getValidGuesses()
    game.guess.push(event.key.toLowerCase())
  }
  //event.preventDefault()
}

function getValidGuesses() {
  validGuesses = WordsService.validWords(guess.value)
}

function inputFromValidGuesses() {
  const index = game.guess.text.length
  for (let i = index; i < 5; i++) {
    game.guess.push(guess.value[i])
  }
}
</script>
