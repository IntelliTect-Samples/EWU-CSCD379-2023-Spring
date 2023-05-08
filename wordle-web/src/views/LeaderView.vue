<template>
  <h1 align="center">Top 10 Wordle Scores</h1>
  <v-row class="justify-center" dense v-for="(leader, index) in LeaderData" :key="leader.playerId">
    <v-col cols="auto">{{ index + 1 }}: {{ leader.name }} - {{ leader.gameCount }} games, {{ leader.averageAttempts }} average attempts</v-col>
  </v-row>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'
import type { LeaderData } from '@/types/LeaderData'

const LeaderData = ref<LeaderData[]>()

Axios.defaults.baseURL = 'https://kind-stone-01ab5711e.3.azurestaticapps.net'
if (window.location.hostname === 'localhost') {
  Axios.defaults.baseURL = 'http://localhost:7053'
}

Axios.get(Axios.defaults.baseURL + '/Leaderboard')
  .then((response) => {
    console.log(response.data)
    LeaderData.value = response.data
  })
  .catch((err) => {
    console.log(err)
  })

</script>
