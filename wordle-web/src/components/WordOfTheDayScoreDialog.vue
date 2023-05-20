<template>
  <v-dialog :model-value="modelValue" @update:model-value="close" :max-width="800">
    <v-card>
      <div class="d-flex justify-center pa-2 bg-primary text-h6">
        You {{ gameResult?.wasGameWon ? 'Won' : 'Lost' }} Word of the Day
      </div>
      <v-card-text class="align-center">
        <v-row dense>
          <v-col cols="3" class="text-end">Attempts -</v-col>
          <v-col cols="3">{{ gameResult?.attempts }}</v-col>
          <v-col cols="3" class="text-end">Duration -</v-col>
          <v-col cols="3">{{ duration }}</v-col>
        </v-row>
        <hr />
        <v-row>
          <v-col cols="3">Date</v-col>
          <v-col cols="1"> </v-col>
          <v-col cols="2">Plays</v-col>
          <v-col cols="2"> Guesses </v-col>
          <v-col cols="4">Time </v-col>
        </v-row>
        <v-row v-for="stat in stats" :key="stat.date.toString()" dense>
          <v-col cols="3">{{ stat.date.getMonth() + 1 }}/{{ stat.date.getDate() }}</v-col>
          <v-col cols="1">
            <v-icon v-if="stat.hasUserPlayed" icon="mdi-check" color="green"></v-icon>
            <v-icon v-if="stat.hasUserPlayed" icon="mdi-circle" color="green"></v-icon>
          </v-col>
          <v-col cols="2">{{ stat.numberOfPlays }}</v-col>
          <v-col cols="2">
            <span v-if="stat.numberOfPlays > 0">
              {{ stat.averageAttempts }}
            </span>
          </v-col>
          <v-col cols="4">
            <span v-if="stat.numberOfPlays > 0">
              {{ formatTime(stat.averageDurationInSeconds) }}
            </span>
          </v-col>
        </v-row>
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn @click="close" variant="elevated" color="primary"> Play Again </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import type { GameResult } from '@/scripts/gameResult'
import { computed, ref, type Ref } from 'vue'
import { formatTime } from '@/scripts/helpers'
import Axios from 'axios'
import { watch } from 'vue'

const props = defineProps<{
  modelValue: boolean
  gameResult: GameResult
  playerId: string
}>()

watch(
  () => props.modelValue,
  (newValue) => {
    if (newValue) {
      refreshStats()
    }
  }
)

const stats: Ref<Array<WordOfTheDayStats>> = ref([])

const duration = computed(() => {
  return props.gameResult ? formatTime(props.gameResult.durationInSeconds) : '???'
})

const emit = defineEmits<{
  (e: 'update:model-value', value: boolean): void
}>()

function close() {
  emit('update:model-value', false)
}

function refreshStats() {
  // Grab the stats via axios from /word/WordOfTheDayStats
  Axios.get('/word/WordOfTheDayStats?playerId=' + props.playerId).then((response) => {
    for (let stat of response.data as Array<WordOfTheDayStats>) {
      stat.date = new Date(stat.date)
    }
    stats.value = response.data as Array<WordOfTheDayStats>
    console.log(stats.value)
  })
}

interface WordOfTheDayStats {
  date: Date
  averageDurationInSeconds: number
  averageAttempts: number
  numberOfPlays: number
  hasUserPlayed: boolean
}
</script>
