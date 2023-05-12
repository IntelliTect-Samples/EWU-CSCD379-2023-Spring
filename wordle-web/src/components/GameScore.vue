<template>
  <div>
    <v-dialog v-model="startDialog" width="auto" persistent>
      <v-btn @click="startGame"> Start Game! </v-btn>
    </v-dialog>
    <v-dialog v-model="dialog" width="auto">
      <v-card>
        <v-card-title>
          {{ dialogTitle }}
        </v-card-title>
        <v-card-text>
          You {{ gameState === WordleGameStatus.Won ? 'won' : 'lost' }} in {{ timer }} seconds.
        </v-card-text>
        <v-card-actions>
          <v-btn @click="dialog = false"> Done </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <v-chip v-if="timerVisible">
      <v-progress-circular indeterminate color="green" :size="20"></v-progress-circular>
      Time: {{ timer }}
    </v-chip>
  </div>
</template>

<script setup lang="ts">
import { ref, watch, defineProps } from 'vue'
import { WordleGame, WordleGameStatus } from '@/scripts/wordleGame'
import Axios from 'axios'

const startDialog = ref(true)
const dialog = ref(false)
const dialogTitle = ref('Game Over')
const timerVisible = ref(false)
const timer = ref(0)
let timerInterval: any

const props = defineProps({
  gameState: {
    type: Number,
    required: true
  },
  game: WordleGame,
  username: String
})

watch(
  () => props.gameState,
  (newStatus) => {
    if (newStatus === WordleGameStatus.Won) {
      dialogTitle.value = 'You Won!'
      dialog.value = true
      clearInterval(timerInterval)
    } else if (newStatus === WordleGameStatus.Lost) {
      dialogTitle.value = 'Game Over'
      dialog.value = true
      clearInterval(timerInterval)
    }
    Axios.post('Leaderboard/AddNewScore', null, {
      params: {
        name: props.username,
        attempts: props.game?.attempts
      }
    })
      .then((response) => {
        console.log(response)
      })
      .catch((error) => {
        console.log(error)
      })
  }
)

function startGame() {
  startDialog.value = false
  dialog.value = false
  dialogTitle.value = 'Game Over'
  timerVisible.value = true
  timer.value = 0
  clearInterval(timerInterval)
  timerInterval = setInterval(() => {
    timer.value += 1
  }, 1000)
}
</script>
