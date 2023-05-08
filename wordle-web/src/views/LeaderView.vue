<template>
  <h1 align="center">Top 10 Wordle Scores</h1>
  <v-row class="justify-center" dense v-for="(leader, index) in LeaderData" :key="leader.playerId">
    <v-col cols="auto"
      >{{ index + 1 }}: {{ leader.name }} - {{ leader.gameCount }} games,
      {{ leader.averageAttempts }} average attempts</v-col
    >
  </v-row>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'
import type { LeaderData } from '@/types/LeaderData'

const leaderData = ref<LeaderData[]>()

Axios.get('leaderboard/GetTopTenScores')
  .then((response) => {
    console.log(response.data)
    leaderData.value = response.data
  })
  .catch((err) => {
    console.log(err)
  })
</script>
