<template>
  <div>
    <v-row justify="end">
      <v-col cols="auto">
        <v-card class="text-left">
          <v-list>
            <v-list-item>
              <v-btn v-model="username" @click="updateUsernameDialog(true)" elevation="0">
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
    <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
      <v-progress-circular color="primary" indeterminate size="64" />
    </v-overlay>

    <GameBoard :game="game" @letterClick="addChar" />
    <br />

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

    <GameKeyboard
      :guessedLetters="game.guessedLetters"
      @letterClick="addChar"
      @backspaceClick="removeLastChar"
      @enterClick="checkGuess"
    />

    <v-divider></v-divider>
    <br />

    <div>
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
        <v-btn @Click="newGame()">Play Again?</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>

  <v-dialog class="w-25 align-center" v-model="gameWon" persistent>
    <v-card class="align-center">
      <v-card-title class="text-h4 text-center mt-10"> You Won! </v-card-title>
      <v-card-actions>
        <v-btn @Click="newGame()">Play Again?</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>

  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>
</template>

<script setup lang="ts">
import { WordleGame, WordleGameStatus } from '@/scripts/wordleGame'
import { ref, reactive, onMounted, onUnmounted, inject, type Ref } from 'vue'
import type { Letter } from '@/scripts/letter'
import Axios from 'axios'
import { WordsService } from '@/scripts/Services/wordsService'
import { eventBus } from '@/scripts/eventBus'
import UsernameDialog from '@/components/UsernameDialog.vue'
import GameBoard from '../components/GameBoard.vue'
import GameKeyboard from '../components/GameKeyboard.vue'
import { useDisplay } from 'vuetify'
import { Services } from '@/scripts/Services/services'
import type { PlayerService } from '@/scripts/Services/playerService'
import { GameResult } from '@/scripts/gameResult'
import { watch } from 'vue'

let validGuesses = new Array<string>()

let buttonText = ref('Display correct word')
let username = ref(localStorage.getItem('username') || 'Guest')
let timer = ref(0)
const guess = ref('')
const overlay = ref(true)
const game = reactive(new WordleGame())
const gameWon = ref(false)
const gameLost = ref(false)
const showScoreDialog = ref(false)
const lastGameResult: Ref<GameResult> = ref({} as GameResult)

// Add this to make testing work because useDisplay() throws an error when testing
// Wrap useDisplay in a function so that it doesn't get called during testing.
const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>
const playerService = inject(Services.PlayerService) as PlayerService

onMounted(async () => {
  // Start a new game
  await newGame()
  window.addEventListener('keyup', keyUp)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyUp)
})

function newGame() {
  overlay.value = true
  Axios.get('Word')
    .then((response) => {
      game.startNewGame(response.data)
      console.log(game.secretWord)
      setTimeout(() => {
        overlay.value = false
      }, 502)
    })
    .catch((error) => {
      console.log(error)
      game.startNewGame(WordsService.getRandomWord())
      console.log(game.secretWord)
      overlay.value = false
    })

  // Reset Win/Lose dialogs.
  gameWon.value = false
  gameLost.value = false
}

/** Emits boolean value used in 'UsernameDialog.vue' to open or close the Username Dialog. */
function updateUsernameDialog(newValue: boolean) {
  eventBus.emit('updateUsernameDialog', newValue)
}

/** When 'UsernameDialog.vue' emits a change to the username, this function updates the username value. */
function updateNameValue(newValue: string) {
  username.value = newValue
}

function toggleSecretWordText() {
  buttonText.value =
    buttonText.value === `${game.secretWord}` ? 'Display correct word' : `${game.secretWord}`
}

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

// function checkGuess(word?: string) {
//   if (typeof word === 'string') {
//     game.guess.set(word)
//   }
//   game.submitGuess()
//   if (game.status !== WordleGameStatus.Active) {
//     sendGameResult()
//   }
//   guess.value = ''
// }

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

function keyUp(event: KeyboardEvent) {
  if (
    document.activeElement?.tagName !== 'INPUT' &&
    document.activeElement?.tagName !== 'TEXTAREA'
  ) {
    if (event.key === 'Enter') {
      checkGuess()
    } else if (event.key === 'Backspace') {
      guess.value = guess.value.slice(0, -1)
      game.guess.pop()
    } else if (event.key.length === 1 && event.key !== ' ') {
      guess.value += event.key.toLowerCase()
      game.guess.push(event.key.toLowerCase())
    }
  }
}

// Watch showScoreDialog and when it changes to true, call newGame()
watch(showScoreDialog, (value) => {
  if (!value) {
    newGame()
  }
})

function sendGameResult() {
  const gameResult = new GameResult()
  gameResult.playerId = playerService.player.playerId
  gameResult.attempts = game.guesses.filter((f) => f.isFilled).length
  gameResult.durationInSeconds = Math.round(game.duration() / 1000)
  gameResult.wasGameWon = game.status == WordleGameStatus.Won
  gameResult.wordPlayed = game.secretWord

  console.log(gameResult)

  lastGameResult.value = gameResult
  showScoreDialog.value = true

  Axios.post('/Player/AddGameResult', gameResult).then((response) => {
    console.log(response.data)
  })
  // if (this.onGameEnd) {
  //   this.onGameEnd(response.data as GameResult)
  // }
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
