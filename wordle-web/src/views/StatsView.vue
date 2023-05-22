<template>
  <v-card class="mx-auto mt-9" width="475px" color="cyan">
    <v-card color="yellow-lighten-1" style="border: 1px solid red">
      <v-card-title>Statistics</v-card-title>
    </v-card>
    <v-card v-for="play in plays">
      <v-card color="cyan" style="border: 3px solid red">
        <v-card-title>Date: {{ play.date }}</v-card-title>
      </v-card>
      <v-list>
        <v-list-item>
          <v-list-item-title>Games Played: {{ play.numberOfPlays }}</v-list-item-title>
        </v-list-item>
        <v-list-item>
          <v-list-item-title>Average Score: {{ play.averageAttempts }}</v-list-item-title>
        </v-list-item>
        <v-list-item>
          <v-list-item-title>Average Time: {{ play.averageTime }}</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-card>
  </v-card>
</template>

<script setup lang="ts">
import type { WordOfTheDayStats } from '@/scripts/wordOfTheDayStats'
import Axios from 'axios'
import { ref } from 'vue'
const plays = ref<WordOfTheDayStats[]>([])

const props = defineProps<{
  playerId: string
}>()

Axios.get('/Play/GetLastTenDates?playerId=' + props.playerId).then((response) => {
  for (let stat of response.data as WordOfTheDayStats[]) {
    stat.date = new Date(stat.date)
  }
  plays.value = response.data as WordOfTheDayStats[]
})
</script>
