<template>
  <h1>Wordle Mind Bender</h1>
  <h2>{{ subtitle }}</h2>
  <GameBoard :game="game" @letterClick="addChar" />
  <br />
  <KeyBoard @letterClick="addChar" />
  <br />

  <v-btn size="large" @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>

  <v-btn @click="restartGame" @keyup.enter="restartGame"> Restart </v-btn>

  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import { WordsService } from '../scripts/wordsService'
import { watch, onMounted, onUnmounted } from 'vue'

const guess = ref('')
const subtitle = ref('')
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

function checkGuess() {
  if (guess.value.length !== game.secretWord.length) {
    subtitle.value = 'Guess is Incorrect Length'
    game.clearCurrentGuess()
  } else if (!WordsService.isValidWord(guess.value)) {
    subtitle.value = 'Guess is not a Valid Word'
    game.clearCurrentGuess()
  } else {
    game.submitGuess()
    if (game.endGame()) {
      subtitle.value = 'You Win!'
      game.restartGame()
    } else {
      if (game.continue === false) {
        subtitle.value = 'You Failed! The word was: ' + game.secretWord
        game.restartGame()
      }
    }
  }
  guess.value = ''
}

function restartGame() {
  game.restartGame()
  subtitle.value = 'Game was Reset'
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
  //event.preventDefault()
}
</script>
