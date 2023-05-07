<template>
  <v-card>
    <main>-- Leaderboard --</main>
  </v-card>
  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>
  <v-card> Time to complete last game = {{ totalTime }} seconds </v-card>
  <v-card v-if="!overlay && players.length">
    <v-table>
      <thead>
        <tr>
          <th class="text-left">player Name</th>
          <th class="text-left">Score</th>
          <th class="text-left">Agv Attempts</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in players" :key="item.name">
          <td>{{ item.name }}</td>
          <td>{{ item.gamesPlayed }}</td>
          <td>{{ item.avgAttempts }}</td>
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

Axios.get('player/GetTopTenPlayers')
  .then((response) => {
    response.data.forEach((player : any) => {
      console.log(`${player.Name}, ${player.GameCount}, ${player.AverageAttempts}`)

      players.push({
        name: `${player.Name}`,
        gamesPlayed: `${player.GameCount}`,
        avgAttempts: `${player.AverageAttempts}` 
      })

      overlay.value = false
    })
  })
  .catch((error) => {
    console.log(error)
  })
</script>