<template>
  <div class="text-right">
    <GetName @overlay="onOverlay" />
  </div>

  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard :guessedLetters="game.guessedLetters" @letterClick="addChar" />

  <WordSelect :validWords="validWords" v-model="selection" @selectWord="addWord" />

  <v-btn
    @click="newGame"
    @keyup.enter="checkGuess"
    color="secondary"
    size="x-large"
    v-if="game.status !== WordleGameStatus.Active"
  >
    New Game
  </v-btn>

  <p>{{ selection }}</p>
</template>

<script setup lang="ts">
import { WordleGame, WordleGameStatus } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import GetName from '../components/GetName.vue'
import type { Letter } from '@/scripts/letter'
import WordSelect from '@/components/WordSelect.vue'
import { WordsService } from '@/scripts/wordsService'
import Axios from 'axios'

const guess = ref('')
const game = reactive(new WordleGame())
let validWords = ref(['?????'])
let guesses: string[] = []
const selection = ref(null)
const input = ref(true)

newGame()

onMounted(async () => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function addWord() {
  input.value = false
  Axios.post('word/AddWordFromBody', {
    text: 'tests',
    isCommon: true,
    isUsed: false
  })
    .then((response) => {
      input.value = true
      console.log(response.data)
    })
    .catch((error) => {
      console.log(error)
    })
}

function newGame() {
  input.value = true
  Axios.get('word')
    .then((response) => {
      game.restartGame(response.data)
      console.log(game.secretWord)
      setTimeout(() => {
        input.value = true
      }, 502)
    })
    .catch((error) => {
      console.log(error)
      game.restartGame(WordsService.getRandomWord())
      console.log(game.secretWord)
      input.value = true
    })
}

function checkGuess(word?: string) {
  if (typeof word === 'string') {
    game.guess.set(word)
  }
  game.submitGuess()
  guesses.push(guess.value)
  validWords.value = WordsService.validWords(guesses, game.secretWord)
  guess.value = ''
}

function addChar(letter: Letter) {
  if (letter.char === 'Submit') {
    checkGuess()
  } else if (letter.char === '←') {
    removeChar()
  } else {
    guess.value += letter.char
    game.guess.push(letter.char)
  }
}

function removeChar() {
  guess.value = guess.value.slice(0, -1)
  game.guess.pop()
}

function keyPress(event: KeyboardEvent) {
  console.log(event.key)
  if (input.value) {
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
}

function onOverlay(name: string) {
  input.value = !input.value
  
}
</script>
