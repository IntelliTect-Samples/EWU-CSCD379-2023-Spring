<template>
  <v-container class="d-flex justify-center align-center">
    <v-card>
      <div class="bg-primary text-h5 pa-3 text-center">Last 10 Words</div>
      <v-card-text>
        <div v-for="dailyWord in dailyWords" :key="dailyWord.word" class="border my-3">
          <div class="d-flex justify-center bg-secondary text-h6">Date: {{ dailyWord.date }}</div>
          <v-card-text class="d-flex flex-column align-center">
            <v-row dense>
              <v-col cols="6" class="text-end">Number of Plays -</v-col>
              <v-col cols="6">{{ dailyWord.plays }}</v-col>
              <v-col cols="6" class="text-end">Average Score -</v-col>
              <v-col cols="6">{{ dailyWord.averageAttempts }}</v-col>
              <v-col cols="6" class="text-end">Average Time -</v-col>
              <v-col cols="6">{{ formatTime(dailyWord.averageSecondsPerGame) }}</v-col>
            </v-row>
          </v-card-text>
        </div>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script lang="ts" setup>
// import Axios from 'axios'
// import { ref } from 'vue'
// import type { Player } from '@/scripts/player'
// import { formatTime } from '@/scripts/helpers'

// const players = ref<Player[]>([])

// Axios.get('/player/TopPlayers').then((result) => {
//   console.log(result.data)
//   players.value = result.data as Player[]
// })
import type { DailyWord } from '@/scripts/dailyWord'
import { formatTime } from '@/scripts/helpers'
const dailyWords: DailyWord[] = [
  { date: '1-11-1111', word: 'hello', plays: 3, averageAttempts: 1, averageSecondsPerGame: 22 },
  { date: '1-11-1111', word: 'hello', plays: 3, averageAttempts: 1, averageSecondsPerGame: 22 },
  { date: '1-11-1111', word: 'hello', plays: 3, averageAttempts: 1, averageSecondsPerGame: 22 },
  { date: '1-11-1111', word: 'hello', plays: 3, averageAttempts: 1, averageSecondsPerGame: 22 },
  { date: '1-11-1111', word: 'hello', plays: 3, averageAttempts: 1, averageSecondsPerGame: 22 },
  { date: '1-11-1111', word: 'hello', plays: 3, averageAttempts: 1, averageSecondsPerGame: 22 },
  { date: '1-11-1111', word: 'hello', plays: 3, averageAttempts: 1, averageSecondsPerGame: 22 },
  { date: '1-11-1111', word: 'hello', plays: 3, averageAttempts: 1, averageSecondsPerGame: 22 },
  { date: '1-11-1111', word: 'hello', plays: 3, averageAttempts: 1, averageSecondsPerGame: 22 },
  { date: '1-11-1111', word: 'hello', plays: 3, averageAttempts: 1, averageSecondsPerGame: 22 }
]
</script>
