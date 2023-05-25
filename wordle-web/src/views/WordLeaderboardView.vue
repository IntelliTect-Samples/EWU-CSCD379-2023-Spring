<template>
  <v-container class="d-flex justify-center align-center">
    <v-card>
      <div class="bg-primary text-h5 pa-3 text-center">Leader Board</div>
      <v-card-text>
        <div v-for="(word, index) in wordStats" :key="word.date.getDay" class="border my-3">
          <div class="d-flex justify-center bg-secondary text-h6">
            #{{ index + 1 }} - {{ word.date }}
          </div>
          <v-card-text class="d-flex flex-column align-center">
            <v-row dense>
              <v-col cols="6" class="text-end">Total Games -</v-col>
              <v-col cols="6">{{ word.numberOfPlays }}</v-col>
              <v-col cols="6" class="text-end">Average Attempts -</v-col>
              <v-col cols="6">{{ word.attempts }}</v-col>
              <v-col cols="6" class="text-end">Average Attempts -</v-col>
              <v-col cols="6">{{ word.averageSeconds }}</v-col>
              <v-col cols="6" class="text-end">Average Duration -</v-col>
              <v-col cols="6">{{ formatTime(word.averageSeconds) }}</v-col>
              <v-col cols="6" class="text-end">Has Played? -</v-col>
              <v-col cols="6">{{ word.hasPlayed }}</v-col>
            </v-row>
          </v-card-text>
        </div>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script lang="ts" setup>
import Axios from 'axios'
import { ref } from 'vue'
import type { WordStats } from '@/scripts/wordStats'
import { formatTime } from '@/scripts/helpers'

const wordStats = ref<WordStats[]>([])

Axios.get('/word/WordOfTheDayStats').then((result) => {
  console.log(result.data)
  wordStats.value = result.data as WordStats[]
})
</script>
