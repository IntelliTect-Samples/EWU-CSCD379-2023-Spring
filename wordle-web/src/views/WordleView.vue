<template>
  <br />
  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <v-container fluid>
    <v-row>
      <v-col>
        <v-btn
          @click="checkGuess"
          @keyup.enter="checkGuess"
          color="grey"
          style="background: linear-gradient(to right, #e1e1e1, #747474)"
        >
          Enter
        </v-btn>
      </v-col>
      <v-col class="text-center">
        <LetterButton :letter="new Letter('?')" @click="letterClick(new Letter('?'))" />
      </v-col>
      <v-col class="text-right">
        <v-btn
          @click="backSpace"
          @keyup.enter="backSpace"
          color="grey"
          style="background: linear-gradient(to right, #e1e1e1, #747474)"
        >
          <v-icon>mdi-backspace</v-icon>
        </v-btn>
      </v-col>
    </v-row>
  </v-container>

  <ValidWords :game="game" />

  <h2 class="text-center">{{ guess }}</h2>
  <h3 class="text-center">{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import { Letter } from '@/scripts/letter'
import LetterButton from '@/components/LetterButton.vue'
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import ValidWords from '../components/ValidWords.vue'

const guess = ref('')
const game = reactive(new WordleGame())
console.log(game.secretWord)

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function checkGuess() {
  game.submitGuess()
  guess.value = ''
}

function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
}

const emits = defineEmits<{
  (event: 'letterClick', value: Letter): void
}>()

function letterClick(letter: Letter) {
  emits('letterClick', letter)
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

function backSpace() {
  guess.value = guess.value.slice(0, -1)
  game.guess.pop()
  console.log('Back')
}
</script>
