<template>
  <main class="d-flex align-center justify-center flex-wrap text-center mx-auto">
    <div class="mt-4">
      <h1>Leaderboard</h1>
      <v-table hover striped class="text-no-wrap rounded dialog" style="background: none">
        <v-overlay
          style="overflow: hidden"
          :model-value="overlay"
          class="align-center justify-center"
          contained
          persistent
        >
          <v-progress-circular color="primary" indeterminate size="64" />
        </v-overlay>
        <thead>
          <tr>
            <th class="text-left">Name</th>
            <th class="text-left">Games Played</th>
            <th class="text-left">Average Attempts</th>
            <th class="text-left">Average Time</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in leaderboardData" :key="item.playerId">
            <td class="text-left">{{ item.name }}</td>
            <td>{{ item.gameCount }}</td>
            <td>{{ item.averageAttempts.toFixed(3) }}</td>
            <td>{{ item.averageSecondsPerGame.toFixed(3) }}</td>
          </tr>
        </tbody>
      </v-table>
    </div>
  </main>
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
const leaderboardUrl = 'https://wurdle.azurewebsites.net/Player/GetTopTenPlayers'
const overlay = ref(true)
const leaderboardData = ref<LeaderboardData[]>()
Axios.get(leaderboardUrl)
  .then((response) => {
    setTimeout(() => {
      overlay.value = false
    }, 100)
    leaderboardData.value = response.data
  })
  .catch((err) => {
    console.log(err)
  })
</script>
