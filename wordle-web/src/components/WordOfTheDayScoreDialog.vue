<template>
  <v-dialog :model-value="modelValue" @update:model-value="close" :max-width="400">
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
        <v-table density="compact">
          <thead>
            <tr>
              <td class="text-left" cols="2">Date</td>
              <td class="text-center">Plays</td>
              <td class="text-center">Guesses</td>
              <td class="text-right">Time</td>
            </tr>
          </thead>
          <tbody>
            <tr
              @click="() => playDay(stat.date)"
              v-for="stat in stats"
              :key="stat.date.toString()"
              dense
            >
              <td>
                <v-icon v-if="stat.hasUserPlayed" icon="mdi-check-decagram" color="green"></v-icon>
                <v-icon v-else icon="mdi-decagram-outline" color="gray"></v-icon>
                <span class="ml-2">{{ stat.date.getMonth() + 1 }}/{{ stat.date.getDate() }}</span>
              </td>
              <td class="text-center">{{ stat.numberOfPlays }}</td>
              <td class="text-center">
                <span v-if="stat.numberOfPlays > 0">
                  {{ stat.averageAttempts.toFixed(1) }}
                </span>
              </td>
              <td class="text-right">
                <span v-if="stat.numberOfPlays > 0">
                  {{ formatTime(stat.averageDurationInSeconds) }}
                </span>
              </td>
            </tr>
          </tbody>
        </v-table>
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn @click="playRandom" variant="elevated" color="primary"> Play Random </v-btn>
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
import router from '@/router'
import type { WordOfTheDayStats } from '@/scripts/wordOfTheDayStats'

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

function playDay(date: Date) {
  close()
  router.push({ name: 'wordOfTheDay', query: { date: date.toLocaleDateString() } })
}

const stats: Ref<Array<WordOfTheDayStats>> = ref([])

const duration = computed(() => {
  return props.gameResult ? formatTime(props.gameResult.durationInSeconds) : '???'
})

const emit = defineEmits<{
  (e: 'update:model-value', value: boolean): void
}>()

function playRandom() {
  router.push({ name: 'wordle' })
  close()
}

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
</script>

<style scoped>
/*Cursor on row should be pointer*/
tbody tr:hover {
  cursor: pointer;
}
</style>
