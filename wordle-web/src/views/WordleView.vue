<template>
  <GameScore :gameState="gameState" />
  <v-chip @click="restartGame">Restart</v-chip>
  <UserName @disableKeyboard="setKeyboard(false)" @enableKeyboard="setKeyboard(true)" />
  <h1>Wordle Mind Bender</h1>

  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>

  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import UserName from '@/components/UserName.vue'
import GameScore from '@/components/GameScore.vue'

const guess = ref('')
const game = reactive(new WordleGame())
const gameState = ref(game.status)
let keyInput: boolean = true

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
  guess.value = ''
  gameState.value = game.status
}

function addChar(letter: Letter) {
  if (keyInput == false) return
  game.guess.push(letter.char)
  guess.value += letter.char
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

function restartGame() {
  game.restartGame()
  guess.value = ''
  game.status = 0
  gameState.value = game.status
}

function setKeyboard(input: boolean) {
  if (input) {
    window.addEventListener('keyup', keyPress)
  } else {
    window.removeEventListener('keyup', keyPress)
  }
}
</script>
