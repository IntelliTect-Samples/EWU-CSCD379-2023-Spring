<template>
  <h1>WORDLE</h1>
  <v-container>
    <GameBoard :game="game" @letterClick="addChar" />
  </v-container>
  <v-container>
    <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />
  </v-container>

  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>

  <h3>{{ game.secretWord }}</h3>
  <v-btn @click="showList">{{ WordsService.validWords(game.guess.text).length }}</v-btn>

  <v-container id="list" hidden>
    <ValidWords @fillGuess="autoComplete" :items="WordsService.validWords(game.guess.text)"/>
  </v-container>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { WordsService } from '@/scripts/wordsService'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import ValidWords from '../components/ValidWords.vue'
import type { Letter } from '@/scripts/letter'
const guess = ref('')
const game = reactive(new WordleGame())
console.log(game.secretWord)
onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})
function autoComplete(fill: string){
  while(game.guess.text !== ''){
    game.guess.pop()
  }
  for(let i = 0; i < fill.length; i++){
    game.guess.push(fill.charAt(i))
  }
}
function showList() {
  document.getElementById("list")!.hidden = !(document.getElementById("list")!.hidden)
}
function checkGuess() {
  game.submitGuess()
  guess.value = ''
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
</script>