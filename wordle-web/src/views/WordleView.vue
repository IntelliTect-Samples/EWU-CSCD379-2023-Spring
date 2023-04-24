<template>
  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>

  <v-card>
    Possible Words: {{ WordsService.validWords(guess).length }}
    <v-select
      no-data-text="Please enter at least one letter"
      label="select"
      :items="WordsService.validWords(guess)"
      v-model="selected"
      @update:model-value="selectWord(selected)"
      onchange="selectWord(this.value)"
    >
    </v-select>
  </v-card>

  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import { WordsService } from '@/scripts/wordsService'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'

const guess = ref('')
const selected = ref('')
const game = reactive(new WordleGame())
const selectElement = document.querySelector('select')
console.log(game.secretWord)

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function selectWord(selected: string) {
  game.guess.clear()
  guess.value = ''
  for (let letter of selected) {
    game.guess.push(letter)
    guess.value += letter
  }
}

function checkGuess() {
  game.submitGuess()
  guess.value = ''
}

function addChar(letter: Letter) {
  if (guess.value.length < 5) {
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
  } else if (event.key.length === 1 && event.key !== ' ') {
    guess.value += event.key.toLowerCase()
    game.guess.push(event.key.toLowerCase())
  }
}
</script>
