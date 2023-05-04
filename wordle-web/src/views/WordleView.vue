<template>
  <GameBoard :game="game" @letterClick="addChar" class="text-center" margin="10%" />

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <WordSelect :validWords="validWords" v-model="selection" @selectWord="addWord" />

  <p>{{ selection }}</p>
</template>

<script setup lang="ts">
import KeyBoard from '@/components/KeyBoard.vue'
import GameBoard from '@/components/GameBoard.vue'
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, watch, onMounted, onUnmounted } from 'vue'
import type { Letter } from '@/scripts/letter'
import WordSelect from '@/components/WordSelect.vue'
import { WordsService } from '@/scripts/wordsService'

const guess = ref('')
const game = reactive(new WordleGame())
console.log(game.secretWord)
let validWords = ref(['?????'])
let guesses: string[] = []
const selection = ref(null)

onMounted(() => {
  window.addEventListener('keyup', keyPress)
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
  if (event.key === 'Enter') {
    checkGuess()
  } else if (event.key === 'Backspace') {
    removeChar()
    console.log('Back')
  } else if (event.key.length === 1 && event.key !== ' ') {
    guess.value += event.key.toLowerCase()
    game.guess.push(event.key.toLowerCase())
  }
}
</script>
