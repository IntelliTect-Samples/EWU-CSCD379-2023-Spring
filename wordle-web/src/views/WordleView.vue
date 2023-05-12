<template>
  <v-row align="center">
    <h1>Wordle Mind Bender</h1>
    <div>
      <v-btn @click="updateNameDialog" prepend-icon="mdi-account-circle">{{
        currentPlayerName
      }}</v-btn>
      <v-chip prepend-icon="mdi-clock">{{ game.elapsedTime }}s</v-chip>
    </div>
  </v-row>

  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>

  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>

  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>

  <v-btn @click="addWord()">Add strin</v-btn>

  <UsernameDialog
    v-model:dialogOpen="newPlayer"
    @username-submitted="handleUsernameSubmitted"
    @update-input="handleUpdateInput"
  ></UsernameDialog>

  <v-dialog :model-value="game.status === 1" max-width="400">
    <v-card>
      <v-card-title class="text-h5">Congratulations, {{ currentPlayerName }}</v-card-title>
      <v-card-text>
        <p>You Scored {{ game.finalScore }} in {{ game.elapsedTime }} seconds!</p>
        <p>Attempts: {{ game.attempts }}</p>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="primary" @click="submitScore"> Submit Score </v-btn>
        <v-btn to="/Leaderboard/0">Leaderboard</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import Axios from 'axios'

import UsernameDialog from '../components/UsernameDialog.vue'
import { PlayerService } from '@/scripts/playerService'
import { Player } from '@/scripts/player'

const guess = ref('')
const game = reactive(new WordleGame())

const overlay = ref(true)
const newPlayer = ref(true)
const currentPlayerName = ref('')

let user = new Player(0, 'Guest', 0, 0, 0)

onMounted(() => {
  window.addEventListener('keydown', keyPress)
  currentPlayerName.value = user.name
})

onUnmounted(() => {
  window.removeEventListener('keydown', keyPress)
})

// Player Related Functions //
async function updateNameDialog() {
  newPlayer.value = true
}

function handleUpdateInput(inputValue: string) {
  currentPlayerName.value = inputValue
}

async function submitScore() {
  user.score = game.finalScore
  console.log('Submitting score for player' + ' ' + user.name + ' with score ' + game.finalScore)
  const response = await PlayerService.AddOrUpdatePlayerScore(user)
  console.log(response)
  game.restartGame()
}

async function handleUsernameSubmitted(name: string) {
  if (user.playerId == 0) {
    currentPlayerName.value = name
    window.addEventListener('keydown', keyPress)
    user = await PlayerService.AddNewPlayer(name)
  } else {
    currentPlayerName.value = name
    user = await PlayerService.UpdatePlayerName(name, user.playerId)
  }
}

// Word Related Functions //
Axios.get('word')
  .then((response) => {
    game.restartGame(response.data)
    setTimeout(() => {
      overlay.value = false
    }, 502)
  })
  .catch((error) => {
    console.log(error)
  })

function addWord() {
  overlay.value = true
  Axios.post('word/AddWordFromBody', {
    text: 'strin',
    isCommon: true,
    isUsed: false
  })
    .then((response) => {
      overlay.value = false
      console.log(response.data)
    })
    .catch((error) => {
      console.log(error)
    })
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
