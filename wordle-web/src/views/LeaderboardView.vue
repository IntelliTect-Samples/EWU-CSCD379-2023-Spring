<template>
  <h1>Leaderboard</h1>
  <v-row>
    <v-col> Player Name: </v-col>
    <v-col> Average Number of Attempts: </v-col>
    <v-col> Average Seconds Per Game: </v-col>
  </v-row>
  <v-row v-for="player in leaderboard" :key="player['playerId']">
    <v-col>
      {{ player['name'] }}
    </v-col>
    <v-col>
      {{ player['averageAttempts'] }}
    </v-col>
    <v-col>
      {{ player['averageSecondsPerGame'] }}
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'

var leaderboard = ref([])

Axios.get('Leaderboard/GetTopPlayers')
  .then((response) => {
    console.log(response.data)
    leaderboard = response.data
  })
  .catch((error) => {
    console.log(error)
  })
</script>
