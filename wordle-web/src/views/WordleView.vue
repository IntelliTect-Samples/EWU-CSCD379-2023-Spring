<template>
  <div>
    <Navbar></Navbar>
    <v-label>Current Guess: {{ guess }}</v-label>
    <v-label>Selected Word: {{ selectedWord }}</v-label>
    <GameBoard :game = "game" @letter-click="addChar"></GameBoard>
    
    <div class="ma-5">
      <v-row class="justify-center">
        <ValidWordList class="ml-2" :validWords="validWords"  @word-selected="handleWordSelected" />

        <v-btn size="small" class="ml-2" @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>
      </v-row>
    </div>
    <VirtualKeyboard :guessedLetters="game.guessedLetters" @letterClick="addChar" @enterClick="checkGuess" @backspaceClick="removeChar"/>

    </div>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '@/components/GameBoard.vue'
import VirtualKeyboard from '@/components/VirtualKeyboard.vue'
import type { Letter } from '@/scripts/letter'
import { ValidationStatus, WordsService } from '@/scripts/wordsService'

import Navbar from '@/components/NavbarItem.vue'
import ValidWordList from '@/components/ValidWordList.vue'

const guess = ref('')
const game = reactive(new WordleGame())
console.log(game.secretWord)

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

const validWords = ref<string[]>()
const selectedWord = ref('')

function handleWordSelected(word: string) {
  for (let letter of word) {
    game.guess.push(letter)
    guess.value = game.guess.text
  }
}

function checkGuess() {
  const validCheck = WordsService.validateWord(guess.value)
    if (validCheck != ValidationStatus.Valid) {
      for (let letter of guess.value) {
        game.guess.pop()
      }
      alert(validCheck)
      return
    }
  game.submitGuess()
  validWords.value = game.getValidWords()
  guess.value = game.guess.text
}

function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value = game.guess.text
}

function removeChar() {
  game.guess.pop()
  guess.value = game.guess.text
}

function keyPress(event: KeyboardEvent) {
  if (event.key === 'Enter') {
    checkGuess()
  } else if (event.key === 'Backspace') {
    game.guess.pop()
    guess.value = game.guess.text
  } else if (event.key.length === 1 && event.key !== ' ') {
    game.guess.push(event.key.toLowerCase())
    guess.value = game.guess.text
  }
}
</script>