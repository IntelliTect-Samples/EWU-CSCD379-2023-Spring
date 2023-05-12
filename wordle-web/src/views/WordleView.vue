<template>
  <GameScore :username="game.username" :gameState="gameState" :game="game" />

  <UserName @sendUsername="setUsername" @setKeyboard="toggleKeyboard" />
  <h1>Wordle Mind Bender</h1>

  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted, watch } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import UserName from '@/components/UserName.vue'
import GameScore from '@/components/GameScore.vue'

const guess = ref('')
const game = reactive(new WordleGame())
const gameState = ref(game.status)

onMounted(async () => {
  await game.restartGame()
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

function setUsername(name: string) {
  game.username = name
}

function toggleKeyboard(input: boolean) {
  if (input) {
    window.addEventListener('keyup', keyPress)
  } else {
    window.removeEventListener('keyup', keyPress)
  }
}
</script>
