<template>
  <v-sheet>
    <v-card width="700px">
      <v-card-title>Leaderboard</v-card-title>
      <v-row>
        <v-col><v-card-title>Player Name:</v-card-title></v-col>
        <v-col><v-card-title>Average Attempts:</v-card-title></v-col>
        <v-col><v-card-title>Average Seconds:</v-card-title></v-col>
      </v-row>
      <v-card v-for="player in leaderboard" :key="player.name">
        <v-row>
          <v-col>{{ player.name }}</v-col>
          <v-col>{{ player.averageAttempts }}</v-col>
          <v-col>{{ player.averageSecondsPerGame }}</v-col>
        </v-row>
      </v-card>
    </v-card>
  </v-sheet>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'

interface Leaderboard {
  name: string
  averageAttempts: number
  averageSecondsPerGame: number
}

const leaderboard = ref<Leaderboard[]>()

Axios.get('Leaderboard/GetTopPlayers')
  .then((response) => {
    console.log(response.data)
    leaderboard.value = response.data
    console.log(response.data)
  })
  .catch((error) => {
    console.log(error)
  })
</script>
