<template>
  <v-card-title class="display-1"> LeaderBoard </v-card-title>
  <v-card-item>
    <v-table>
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
  </v-card-item>
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
const players = ref<Player[]>()
// store the index at which the current user is in the array, into variable
let currentUserIndex = players.value?.findIndex((player) => player.playerName === username.value)

console.log(currentUserIndex)

Axios.get('leaderboard/GetTopTenScores')
  .then((response) => {
    setTimeout(() => {}, 100)
    players.value = response.data
  })
  .catch((err) => {
    console.log(err)
  })

console.log(players)
</script>
