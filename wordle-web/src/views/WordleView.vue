<template>
  <div class="align-center">
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
      <KeyBoard
        @letterClick="addChar"
        @backspaceClick="removeLastChar"
        @enterClick="checkGuess"
        :guessedLetters="game.guessedLetters"
      />
      <v-row dense class="justify-center" cols="auto">
        <v-col cols="auto">
          <v-btn
            @click="toggleText"
            class="elevation-10"
            style="background-image: var(--btn-gradient)"
            >{{ buttonText }}</v-btn
          >
        </v-col>
        <v-col cols="auto">
          <v-btn
            @click="addWord()"
            class="elevation-10"
            style="background-image: var(--btn-gradient)"
            >Add Strin</v-btn
          >
        </v-col>
      </v-row>
    </div>
  </div>

  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted, watch } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import Axios from 'axios'
import { WordsService } from '@/scripts/wordsService'

let validGuesses = new Array<string>()
let buttonText = ref('Display correct word')
const guess = ref('')
const game = reactive(new WordleGame())
const overlay = ref(true)

onMounted(async () => {
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

function toggleText() {
  buttonText.value =
    buttonText.value === `${game.secretWord}` ? 'Display correct word' : `${game.secretWord}`
}

function addWord() {
  overlay.value = true
  Axios.post('word/AddWordFromBody', {
    text: 'strin',
    isCommon: true,
    isUsed: false
  })
    .then((response) => {
      overlay.value = false
      console.log(response.data)
    })
    .catch((error) => {
      console.log(error)
    })
}

Axios.get('word')
  .then((response) => {
    game.restartGame(response.data)
    console.log(game.secretWord)
    setTimeout(() => {
      overlay.value = false
    }, 502)
  })
  .catch((error) => {
    console.log(error)
  })

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

function removeLastChar() {
  guess.value = guess.value.slice(0, -1)
  getValidGuesses()
  game.guess.pop()
}

function keyPress(event: KeyboardEvent) {
  console.log(event.key)
  if (event.key === 'Enter') {
    checkGuess()
  } else if (event.key === 'Backspace') {
    removeLastChar()
  } else if (event.key.length === 1 && event.key !== ' ') {
    guess.value += event.key.toLowerCase()
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
