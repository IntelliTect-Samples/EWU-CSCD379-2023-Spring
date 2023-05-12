<template>
  <br />

  <div class="playerName">
    <v-btn v-if="game.nameSaved" @click="editName">{{ playerName }}</v-btn>
    <input v-else type="text" v-model="playerName" @keyup.enter="saveName" />
  </div>

  <GameBoard :game="game" @letterClick="addChar" />

  <KeyBoard :game="game" @letterClick="addChar" :guessedLetters="game.guessedLetters" />

  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>

  <v-dialog v-model="dialog" persistent max-width="500px">
    <v-card>
      <v-card-title>
        <span class="headline">Enter Your Name</span>
      </v-card-title>
      <v-card-text>
        <v-text-field v-model="playerName" label="Name" placeholder="Guest"></v-text-field>
      </v-card-text>
      <v-card-actions>
        <v-btn color="primary" @click="saveName">Save</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>

  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import { WordleGame, WordleGameStatus } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import axios from 'axios'

const dialog = ref(true)
const playerName = ref('Guest')

const guess = ref('')
const game = reactive(new WordleGame())

onMounted(async () => {
  window.addEventListener('keyup', keyPress)
  await game.restartGame()
  console.log(game.secretWord)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function checkGuess() {
  console.log('Submitting game')
  submitGame()
  game.submitGuess()
  guess.value = ''
  if (game.status === WordleGameStatus.Won) {
    console.log('You won!')
  }
}

function saveName() {
  if (playerName.value !== '') {
    dialog.value = false
    game.nameSaved = true
  }
}

function editName() {
  game.nameSaved = false
  dialog.value = true
}

function submitGame() {
  const GameCount = 1
  const AverageAttempts = parseFloat((Math.random() * 4 + 1).toFixed(2))

  const player = {
    Name: playerName.value,
    GameCount: GameCount,
    AverageAttempts: AverageAttempts
  }

  console.log('Submitting game')
  console.log(player)

  axios
    .post('https://wordle-assignment3.azurewebsites.net/leaderboard', player)
    .then((response) => {
      console.log(response.data)
    })
    .catch((error) => {
      console.log(error)
    })
}

function addChar(letter: Letter) {
  if (game.nameSaved) {
    game.guess.push(letter.char, game.nameSaved)
    guess.value += letter.char
  }
}

function keyPress(event: KeyboardEvent) {
  if (game.nameSaved) {
    console.log(event.key)
    if (event.key === 'Enter') {
      checkGuess()
    } else if (event.key === 'Backspace') {
      guess.value = guess.value.slice(0, -1)
      game.guess.pop(game.nameSaved)
      console.log('Back')
    } else if (event.key.length === 1 && event.key !== ' ') {
      guess.value += event.key.toLowerCase()
      game.guess.push(event.key.toLowerCase(), game.nameSaved)
    }
  }
}
</script>

<style scoped>
.playerName {
  align-self: flex-start;
  text-align: right;
  z-index: 1;
  margin-top: -70px;
  padding: 0 20px;
  margin-bottom: 100px;
}
</style>
