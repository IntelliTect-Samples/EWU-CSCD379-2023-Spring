<template>
  <v-card class="mx-auto mt-9" width="475px" color="cyan">
    <v-card color="yellow-lighten-1" style="border: 1px solid red">
      <v-card-title>Statistics</v-card-title>
    </v-card>
    <v-card v-for="play in plays" :key="play.date.toString">
      <v-card color="cyan" style="border: 3px solid red">
        <v-card-title>{{ play.date.toDateString() }}</v-card-title>
      </v-card>
      <v-list>
        <v-list-item>
          <v-list-item-title>Games Played: {{ play.numberOfPlays }}</v-list-item-title>
        </v-list-item>
        <v-list-item>
          <v-list-item-title
            >Average Attempts:
            {{ play.avgAttempts == -1 ? '' : Math.round(play.avgAttempts) }}</v-list-item-title
          >
        </v-list-item>
        <v-list-item>
          <v-list-item-title
            >Average Time:
            {{ play.avgTime == -1 ? '' : Math.round(play.avgTime) + ' seconds' }}</v-list-item-title
          >
        </v-list-item>
      </v-list>
    </v-card>
  </v-card>
</template>

<script setup lang="ts">
import type { PlayerService } from '@/scripts/playerService'
import { Services } from '@/scripts/services'
import type { WordOfTheDayStats } from '@/scripts/wordOfTheDayStats'
import Axios from 'axios'
import { inject, ref } from 'vue'
const plays = ref<WordOfTheDayStats[]>([])
const playerService = inject(Services.PlayerService) as PlayerService

Axios.get('/Word/GetLastTenDates?playerId=' + playerService.player.playerId).then((response) => {
  for (let stat of response.data as WordOfTheDayStats[]) {
    stat.date = new Date(stat.date)
  }
  plays.value = response.data as WordOfTheDayStats[]
  console.log(plays.value)
})
</script>
