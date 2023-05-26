<!--
---- Displays the top ten players from the database on a v-card.
--->

<template>
  <v-card>
    <v-card-title class="text-center"> Top Ten Scores </v-card-title>
    <v-card-item>
      <v-table>
        <thead>
          <tr>
            <th class="text-center">Username</th>
            <th class="text-center">Games Played</th>
            <th class="text-center">Average Guesses</th>
            <th class="text-center">Average Time</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="player in players" :key="player.playerId">
            <td>{{ player.playerName }}</td>
            <td>{{ player.gameCount }}</td>
            <td>{{ player.averageAttempts }}</td>
            <td>{{ player.averageSecondsPerGame }}</td>
          </tr>
        </tbody>
      </v-table>
    </v-card-item>
  </v-card>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'

interface Player {
  playerId: number
  playerName: string
  gameCount: number
  averageAttempts: number
  averageSecondsPerGame: number
}

const players = ref<Player[]>()

Axios.get('Player/TopPlayers')
  .then((response) => {
    setTimeout(() => {}, 100)
    players.value = response.data
  })
  .catch((err) => {
    console.log(err)
  })

console.log(players)
</script>
