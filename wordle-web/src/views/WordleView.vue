<template>
  <h1>Wordle Mind Bender</h1>

  <GameBoard :game="game" @letterClick="addChar" />

  <div style="padding-top: 3em">
    <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" :result="result" />
  </div>
  {{ dialog() }}
  <v-dialog v-model="showDialog"
    ><v-card>
      <v-card-text> Enter Name Below </v-card-text>
      <v-text-field v-model="name" label="First name"></v-text-field>
      <v-card-actions>
        <v-btn
          :onclick="
            () => {
              setName()
              result = false
            }
          "
          >Submit</v-btn
        >
      </v-card-actions>
    </v-card></v-dialog
  >

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

const guess = ref('')
const result = ref()
const game = reactive(new WordleGame())
const name = ref(localStorage.getItem('name') || '')
const showDialog = ref<boolean>(false)

const dialog = () => {
  if (result.value === true && localStorage.getItem('name') === null) {
    return (showDialog.value = true)
  } else {
    return (showDialog.value = false)
  }
}

const setName = () => {
  localStorage.setItem('name', JSON.stringify(name.value))
}

onMounted(async () => {
  window.addEventListener('keyup', keyPress)
  await game.restartGame()
  console.log(game.secretWord)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function checkGuess() {
  const res = game.submitGuess()
  result.value = res
  guess.value = ''
}

function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
}

function keyPress(event: KeyboardEvent) {
  if (result.value) return
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
