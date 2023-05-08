<template>
  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>

  <h1>Leaderboard</h1>
  <v-table striped class="text-no-wrap">
    <thead>
      <tr>
        <th class="text-left">Name</th>
        <th class="text-left">Games Played</th>
        <th class="text-left">Average Attempts</th>
        <th class="text-left">Average Time</th>
        <th class="w-100"></th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in leaderboardData" :key="item.playerId">
        <td>{{ item.name }}</td>
        <td>{{ item.gameCount }}</td>
        <td>{{ item.averageAttempts }}</td>
        <td>{{ item.averageSecondsPerGame }}</td>
        <td class="w-100"></td>
      </tr>
    </tbody>
  </v-table>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'

interface LeaderboardData {
  playerId: number
  name: string
  gameCount: number
  averageAttempts: number
  averageSecondsPerGame: number
  weightedScore: number
}

const leaderboardUrl = 'https://wordlemindbender.azurewebsites.net/Player/GetTopTenPlayers'
const overlay = ref(true)

const leaderboardData = ref<LeaderboardData[]>()
Axios.get(leaderboardUrl)
  .then((response) => {
    console.log(response.data)
    overlay.value = false
    leaderboardData.value = response.data
  })
  .catch((err) => {
    console.log(err)
  })
</script>
