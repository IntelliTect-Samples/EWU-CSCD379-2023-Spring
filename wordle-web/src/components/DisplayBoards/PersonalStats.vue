<template>
  <div class="text-center align-center justify-center">
    <v-card-title class="display-1"> Personal Stats </v-card-title>
    <v-table class="align-center justify-center">
      <thead>
        <tr>
          <th class="text-center">Username</th>
          <th class="text-center">Games Played</th>
          <th class="text-center">Total Time Taken</th>
          <th class="text-center">Average Time Taken</th>
          <th class="text-center">Total Guess Attempts</th>
          <th class="text-center">Average Guess Attempts</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="player in players" :key="player.playerId">
          <td>{{ player.playerName }}</td>
          <td>{{ player.gameCount }}</td>
          <td>{{ player.totalTimeInSeconds }}</td>
          <td>{{ player.averageTimeInSeconds }}</td>
          <td>{{ player.totalAttempts }}</td>
          <td>{{ player.averageAttempts }}</td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'

interface Player {
  playerId: number
  playerName: string
  gameCount: number
  totalTimeInSeconds: number
  averageTimeInSeconds: number
  totalAttempts: number
  averageAttempts: number
}

let username = ref(localStorage.getItem('username') || 'Guest')
let players = ref<Player[]>()

Axios.get('leaderboard/GetPlayerStats', {
  params: {
    playerName: username.value
  }
})
  .then((response) => {
    setTimeout(() => {}, 100)
    players.value = response.data
  })
  .catch((err) => {
    console.log(err)
  })

console.log(players)
</script>
