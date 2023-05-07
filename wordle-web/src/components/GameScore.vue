<template>
  <div>
    <v-dialog v-model="startDialog" width="auto">
      <v-btn @click="startGame"> Start Game! </v-btn>
    </v-dialog>
    <v-dialog v-model="dialog" width="auto">
      <v-card>
        <v-card-title>
          {{ dialogTitle }}
        </v-card-title>
        <v-card-text>
          You {{ gameState === WordleGameStatus.Won ? 'won' : 'lost' }} in {{ timer }} seconds. Your
          score is {{ score }}
        </v-card-text>
        <v-card-actions>
          <v-btn @click="dialog = false"> Done </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <v-chip v-if="timerVisible">
      <v-progress-circular indeterminate color="green" :size="20"></v-progress-circular>
      Time: {{ timer }} Score: {{ score }}
    </v-chip>
  </div>
</template>

<script setup lang="ts">
import { ref, watch, defineProps } from 'vue'
import { WordleGame, WordleGameStatus } from '@/scripts/wordleGame'

const startDialog = ref(true)
const dialog = ref(false)
const dialogTitle = ref('Game Over')
const score = ref(1000)
const timerVisible = ref(false)
const timer = ref(0)
let timerInterval: any

const props = defineProps({
  gameState: {
    type: Number,
    required: true
  }
})

watch(
  () => props.gameState,
  (newStatus) => {
    if (newStatus === WordleGameStatus.Won) {
      dialogTitle.value = 'You Won!'
      score.value += 500
      dialog.value = true
      clearInterval(timerInterval)
    } else if (newStatus === WordleGameStatus.Lost) {
      dialogTitle.value = 'Game Over'
      score.value -= 500
      dialog.value = true
      clearInterval(timerInterval)
    }
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
    score.value -= 2
  }, 1000)
}
</script>
