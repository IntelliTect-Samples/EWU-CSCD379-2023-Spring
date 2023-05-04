<template>
  <GetName @overlay="onOverlay" />

  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <WordSelect :validWords="validWords" v-model="selection" @selectWord="addWord" />

  <p>{{ selection }}</p>
</template>

<script setup lang="ts">
import KeyBoard from '@/components/KeyBoard.vue'
import GameBoard from '@/components/GameBoard.vue'
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import GetName from '../components/GetName.vue'
import type { Letter } from '@/scripts/letter'
import WordSelect from '@/components/WordSelect.vue'
import { WordsService } from '@/scripts/wordsService'

const guess = ref('')
const game = reactive(new WordleGame())
let validWords = ref(['?????'])
let guesses: string[] = []
const selection = ref(null)
const input = ref(true)

onMounted(async () => {
  window.addEventListener('keyup', keyPress)
  await game.restartGame()
  console.log(game.secretWord)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function checkGuess() {
  game.submitGuess()
  guesses.push(guess.value)
  validWords.value = WordsService.validWords(guesses, game.secretWord)
  guess.value = ''
}

function addWord(word: string) {
  for (let i = 0; i < 5; i++) {
    removeChar()
  }
  for (let i = 0; i < word.length; i++) {
    guess.value += word[i]
    game.guess.push(word[i])
  }
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
