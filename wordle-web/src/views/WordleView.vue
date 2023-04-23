<template>
  <GameBoard :game="game" />
  <div>
    <WordsList :game="game" />
  </div>
  <div>
    <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" :game="game" />
  </div>
  <div>Your guess: [{{ game.currentGuess.text }}]</div>
  <div>Secret word: [{{ game.secretWord.toUpperCase() }}]</div>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import type { Letter } from '@/scripts/letter'
import GameBoard from '@/components/GameBoard.vue'
import KeyBoard from '@/components/KeyBoard.vue'
import WordsList from '@/components/WordsList.vue'
import { onMounted, onUnmounted, reactive } from 'vue'
import { WordsService } from '@/scripts/wordsService'

const game = reactive(new WordleGame())

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function addChar(letter: Letter) {
  game.currentGuess.push(letter.char)
}

function keyPress(event: KeyboardEvent) {
  if (event.key.length === 1) {
    game.currentGuess.push(event.key.toUpperCase())
  } else if (event.key === 'Backspace') {
    game.currentGuess.pop()
  } else if (event.key === 'Enter') {
    checkGuess()
  }
}

function checkGuess() {
  if (WordsService.isValidWord(game.currentGuess.text.toLowerCase())) {
    game.submitGuess()
  } else {
    alert('Invalid word')
  }
}
</script>
