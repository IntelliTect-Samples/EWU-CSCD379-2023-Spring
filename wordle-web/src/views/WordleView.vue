<template>
    <div>
      <h1>
        Wordle But Better
      </h1>
    </div>
    <div>{{game.secretWord}}</div>
  <GameBoard :game="game" />
  <div>
    <InGameWordList :game="game" />
  </div>
  <div>
    <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" :game="game" />
  </div>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import type { Letter } from '@/scripts/letter'
import GameBoard from '@/components/GameBoard.vue'
import KeyBoard from '@/components/KeyBoard.vue'
import InGameWordList from '@/components/InGameWordList.vue'
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
    alert('Not a world possible in word list')
  }
}
</script>
