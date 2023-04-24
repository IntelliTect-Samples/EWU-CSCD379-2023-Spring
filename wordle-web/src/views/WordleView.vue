<template>
  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>

  <v-btn @click="showBigDialog = !showBigDialog"
    >Possible Guesses: {{ game.possibleWords.length }}</v-btn
  >
  <v-btn @click="showDialog = !showDialog"
    >Possible Guesses (with current guess): {{ game.possibleGuess.length }}</v-btn
  >

  <template>
    <v-dialog v-model="showBigDialog">
      <v-card>
        <v-hover>
          <div v-if="game.possibleWords.length < 300">
            <div v-for="word in game.possibleWords" :key="word">
              <v-btn @click=";[setGuess(word), (showBigDialog = !showBigDialog)]">{{
                word
              }}</v-btn>
            </div>
          </div>
          <v-btn v-else @click="showBigDialog = !showBigDialog"
            >Try to get the possible words bellow 300</v-btn
          >
          <v-btn @click="showBigDialog = !showBigDialog">Close Guesses</v-btn>
        </v-hover>
      </v-card>
    </v-dialog>
  </template>

  <template>
    <v-dialog v-model="showDialog">
      <v-card>
        <v-hover>
          <div v-if="game.possibleGuess.length < 300">
            <div v-for="word in game.possibleGuess" :key="word">
              <v-btn @click=";[setGuess(word), (showDialog = !showDialog)]">{{
                word
              }}</v-btn>
            </div>
          </div>
          <v-btn v-else @click="showBigDialog = !showBigDialog"
            >Try to get the possible words bellow 300</v-btn
          >
          <v-btn @click="showDialog = !showDialog">Close Guesses</v-btn>
        </v-hover>
      </v-card>
    </v-dialog>
  </template>
  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import type { Word } from '@/scripts/word'

const guess = ref('')
const game = reactive(new WordleGame())
console.log(game.secretWord)
let showDialog = ref(false)
let showBigDialog = ref(false)

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function setGuess(str: String) {
  let word = str.split('')
  console.log(word)
  for (let i = 0; i < 5; i++) {
    game.guess.pop()
  }
  for (let i = 0; i < word.length; i++) {
    game.guess.push(word[i])
  }
}

function checkGuess() {
  game.submitGuess()
  guess.value = ''
}

function showPossibleWords() {
  game.showPossibleWords()
}

function showGuessWords() {
  game.showWorkingWords()
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

    game.showWorkingWords()
  }
}
</script>
