<template>
  <v-row align="center">
    <h1>Wordle Mind Bender</h1>
    <div>
      <v-btn @click="updateNameDialog" prepend-icon="mdi-account-circle">{{
        currentPlayerName
      }}</v-btn>
      <v-chip>{{ game.elapsedTime }}s</v-chip>
      <v-chip>{{ game.status }}</v-chip>
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

  <v-dialog :model-value="game.status === 1" persistent max-width="400">
    <v-card>
      <v-card-title class="text-h5">Congratulations!</v-card-title>
      <v-card-text>
        <p>Player: {{ currentPlayerName }}</p>
        <p>Final Score: {{ game.finalScore }}</p>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="primary" @click="submitScore">Submit Score</v-btn>
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
  try {
    user.score = game.finalScore
    console.log('Submitting score for player' + ' ' + user.name + ' with score ' + game.finalScore)
    console.log(user)

    user = await PlayerService.AddOrUpdatePlayerScore(user) //broken
    console.log(user)
  } catch (error) {
    console.error('Error in submitScore:', error)
  }
}

async function handleUsernameSubmitted(name: string) {
  if (user.playerId == 0) {
    console.log('Username submitted:', name)
    currentPlayerName.value = name

    window.addEventListener('keydown', keyPress)

    console.log('Adding new player' + ' ' + name)
    user = await PlayerService.AddNewPlayer(name)
    console.log(user)
  } else {
    console.log('Username update submitted:', name)
    currentPlayerName.value = name
    console.log('Updating player' + ' ' + user.name + ' to ' + name)
    user = await PlayerService.UpdatePlayerName(name, user.playerId)
    console.log(user) // THIS IS BROKEN :(
  }
}

// Word Related Functions //
Axios.get('word')
  .then((response) => {
    game.restartGame(response.data)
    console.log(game.secretWord)
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
