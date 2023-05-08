<template>
  <div style="display: flex; justify-content: space-between">
    <h1>Wordle Mind Bender</h1>
    <div class="d-flex justify-end mb-6">
      <v-btn @click="showDialog = !showDialog">User: {{ name || 'guest' }}</v-btn>
    </div>
  </div>

  <GameBoard :game="game" @letterClick="addChar" />

  <div style="padding-top: 3em">
    <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" :result="result" />
  </div>

  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>

  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>

  <template>
    <v-dialog v-model="showDialog" width="400px" persistent>
      <v-card title="Name:">
        <v-text-field label="UserName" @input="updateName($event.target.value)"></v-text-field>
        <v-btn @click="showDialog = false">Confirm Name</v-btn>
      </v-card>
    </v-dialog>
  </template>
  <template>
    <v-dialog v-model="endScreen" width="400px" persistent>
      <v-card title="Score:">
        <v-row>
          <v-col> Name: </v-col>
          <v-col> Attempts: </v-col>
          <v-col> Time: </v-col>
        </v-row>
        <v-row>
          <v-col>
            <v-btn @click="showDialog = !showDialog">{{ name }}</v-btn>
          </v-col>
          <v-col>
            {{ game.finalGuesses }}
          </v-col>
          <v-col>
            {{ game.finalTime }}
          </v-col>
        </v-row>
        <v-btn @click="handleSubmit">Send to Leaderboard</v-btn>
      </v-card>
    </v-dialog>
  </template>
  <v-btn
    :onclick="
      () => {
        game.restartGame()
      }
    "
    >Restart Game</v-btn
  >
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import Axios from 'axios'

const guess = ref('')
const result = ref()
const game = reactive(new WordleGame())
const name = ref(localStorage.getItem('name')?.replace('"', '').replace('"', '') || '')
const showDialog = ref<boolean>(false)
let endScreen = ref(false)
const overlay = ref(true)

function updateName(newName: string) {
  game.changeName(newName)
  name.value = game.displayName
}
function handleSubmit() {
  submitToLeaderboard()
  endScreen.value = false
  game.restartGame()
}

async function submitToLeaderboard() {
  overlay.value = true
  await Axios.post('api/AddPlayer', { name: game.displayName, attempts: game.finalGuesses })
    .then((res) => console.log(res))
    .catch((err) => console.log(err))
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
  game.submitGuess()
  if (game.status != 0) {
    endScreen.value = true
  }
  guess.value = ''
}

function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
}

function keyPress(event: KeyboardEvent) {
  console.log(event.key)
  if (!showDialog.value) {
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
}
</script>
