<template>
  <div>
    <v-row justify="end">
      <v-col cols="auto">
        <v-card class="text-left">
          <v-list>
            <v-list-item>
              <v-btn v-model="username" @click="updateDialogValue(true)" elevation="0">
                Username: {{ username }}
              </v-btn>
            </v-list-item>
            <v-list-item> Elapsed Time: {{ timer }} seconds </v-list-item>
          </v-list>
        </v-card>
      </v-col>
    </v-row>
  </div>
  <div class="align-center">
    <h1>The Good Word</h1>
    <br />

    <div>
      <GameBoard :game="game" @letterClick="addChar" />
      <br />
    </div>

    <div>
      <v-responsive class="mx-auto" max-width="300">
        <v-select
          v-model="guess"
          :items="validGuesses"
          :label="'Valid Guesses: ' + validGuesses.length"
          @update:model-value="inputFromValidGuesses"
        >
          <v-hover></v-hover>
        </v-select>
      </v-responsive>
    </div>

    <v-divider></v-divider>
    <br />

    <div>
      <KeyBoard
        @letterClick="addChar"
        @backspaceClick="removeLastChar"
        @enterClick="checkGuess"
        :guessedLetters="game.guessedLetters"
        v-if="game.status === WordleGameStatus.Active"
      />
      <v-row dense class="justify-center" cols="auto">
        <v-col cols="auto">
          <v-btn
            @click="toggleSecretWordText"
            class="elevation-10"
            style="background-image: var(--btn-gradient)"
            >{{ buttonText }}</v-btn
          >
        </v-col>
        <!-------------------------------------------------------------------------------->
        <!-- NOTE: Disabled because unused. Respective API end-points is also disabled. -->
        <!--       (Disabled group set => Set 1)                                        -->
        <!-------------------------------------------------------------------------------->
        <!-- <v-col cols="auto">-->
        <!--   <v-btn-->
        <!--     @click="addWordToDatabase()"-->
        <!--     class="elevation-10"-->
        <!--     style="background-image: var(&#45;&#45;btn-gradient)"-->
        <!--   >Add Strin</v-btn-->
        <!--   >-->
        <!-- </v-col>-->
      </v-row>
    </div>
  </div>

  <UsernameDialog @updateNameValue="updateNameValue" />

  <v-dialog class="w-25 align-center" v-model="gameLost" persistent>
    <v-card class="align-center">
      <v-card-title class="text-h4 text-center mt-10"> Better Luck Next Time... </v-card-title>
      <v-card-actions>
        <v-btn @Click="newGames()">Play Again?</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>

  <v-dialog class="w-25 align-center" v-model="gameWon" persistent>
    <v-card class="align-center">
      <v-card-title class="text-h4 text-center mt-10"> You Won! </v-card-title>
      <v-card-actions>
        <v-btn @Click="newGames()">Play Again?</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>

  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>
</template>

<script setup lang="ts">
import { WordleGame, WordleGameStatus } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted } from 'vue'
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
import type { Letter } from '@/scripts/letter'
import Axios from 'axios'
import { WordsService } from '@/scripts/wordsService'
import { eventBus } from '@/scripts/eventBus'
import UsernameDialog from '@/components/UsernameDialog.vue'

let validGuesses = new Array<string>()

let buttonText = ref('Display correct word')
let username = ref(localStorage.getItem('username') || 'Guest')
let timer = ref(0)
const guess = ref('')
const overlay = ref(true)
const game = reactive(new WordleGame())
const gameWon = ref(false)
const gameLost = ref(false)

onMounted(async () => {
  window.addEventListener('keyup', keyPress)
  await newGames()
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

async function newGames() {
  /* Perform axios call to get new word and start game. */
  await Axios.get('word')
    .then((response) => {
      game.startNewGame(response.data)
      console.log('Secret word: ' + game.secretWord)
      setTimeout(() => {
        overlay.value = false
      }, 502)
    })
    .catch((error) => {
      console.log('Axios error: ' + error)
    })

  // Reset Win/Lose dialogs.
  gameWon.value = false
  gameLost.value = false

  /* Start timer. */
  timer.value = 0
  let startTimer = setInterval(() => {
    if (game.status === WordleGameStatus.Active) {
      timer.value++
    } else {
      clearInterval(startTimer)
    }
  }, 1000)
}

/** Emits boolean value used in 'UsernameDialog.vue' to open or close the Username Dialog. */
function updateDialogValue(newValue: boolean) {
  eventBus.emit('updateDialogValue', newValue)
}

/** When 'UsernameDialog.vue' emits a change to the username, this function updates the username value. */
function updateNameValue(newValue: string) {
  username.value = newValue
}

function toggleSecretWordText() {
  buttonText.value =
    buttonText.value === `${game.secretWord}` ? 'Display correct word' : `${game.secretWord}`
}

// TODO: Update method to add word from body, instead of attempting add hardcoded word in method.
// NOTE: Disabled because unused. Respective API end-point is also disabled.
//       (Disabled group set => Set 1)
// function addWordToDatabase() {
//   overlay.value = true
//   Axios.post('word/AddWordFromBody', {
//     text: 'strin',
//     isCommon: true,
//     isUsed: false
//   })
//     .then((response) => {
//       overlay.value = false
//       console.log(response.data)
//     })
//     .catch((error) => {
//       console.log(error)
//     })
// }

function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
  getValidGuesses()
}

function removeLastChar() {
  guess.value = guess.value.slice(0, -1)
  getValidGuesses()
  game.guess.pop()
}

function checkGuess() {
  // TODO: Add a UI effect to show that the guess is not of right length.
  if (game.guess.word.length !== game.secretWord.length) {
    console.log('Guess is not of the right length')
    return
  }

  game.submitGuess()
  guess.value = ''
  getValidGuesses()
  if (game.status !== WordleGameStatus.Active) {
    submitPlayerResults()
    if (game.status === WordleGameStatus.Won) {
      gameWon.value = true
    } else {
      gameLost.value = true
    }
  }
}

function getValidGuesses() {
  validGuesses = WordsService.validWords(guess.value)
}

function inputFromValidGuesses() {
  const index = game.guess.word.length

  for (let i = 0; i < index; i++) {
    game.guess.pop()
  }

  for (let i = 0; i < 5; i++) {
    game.guess.push(guess.value[i])
  }
}

function keyPress(event: KeyboardEvent) {
  console.log(event.key)
  if (event.key === 'Enter') {
    checkGuess()
  } else if (event.key === 'Backspace') {
    removeLastChar()
  } else if (event.key.length === 1 && event.key !== ' ') {
    guess.value += event.key.toLowerCase()
    getValidGuesses()
    game.guess.push(event.key.toLowerCase())
  }
  //event.preventDefault()
}

function submitPlayerResults() {
  console.log(username.value)
  console.log(game.guessAttempts)
  console.log(timer.value)

  Axios.post('leaderboard/AddNewPlayer', {
    name: username.value,
    attempts: game.guessAttempts,
    timeInSeconds: timer.value
  })
    .then((response) => console.log(response))
    .catch((error) => console.log(error))
}
</script>
