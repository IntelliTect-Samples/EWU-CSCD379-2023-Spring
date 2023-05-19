<template>
  <v-card>
    <main>-- Leaderboard --</main>
  </v-card>
  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>
  <v-card v-if="!overlay && players.length">
    <v-table>
      <thead>
        <tr>
          <th class="text-left">Player Name</th>
          <th class="text-left">Games Played</th>
          <th class="text-left">Average Attempts</th>
          <th class="text-left">Average Seconds</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in players" :key="item.name">
          <td>{{ item.name }}</td>
          <td>{{ item.gamesPlayed }}</td>
          <td>{{ item.avgAttempts }}</td>
          <td>{{ item.avgSeconds }}</td>
        </tr>
      </tbody>
    </v-table>
  </v-card>
  <v-btn density="compact" @click="goBack"> Back </v-btn>
</template>

<script setup lang="ts">
import Axios from 'axios'
import { ref } from 'vue'
import $router from '../router/index'

var totalTime = localStorage.total_time / 1000
const overlay = ref(true)
var players: any[] = []

function goBack() {
  $router.go(-1)
}

Axios.get('GetTopTenPlayers')
  .then((response) => {
    response.data.forEach((player: any) => {
      players.push({
        name: `${player.UserName}`,
        gamesPlayed: `${player.GameCount}`,
        avgAttempts: `${player.AvgAttempts.toFixed(2)}`,
        avgSeconds: `${player.AvgSeconds.toFixed(2)}`
      })

      overlay.value = false
    })
  })
  .catch((error) => {
    console.log(error)
  })
</script>
