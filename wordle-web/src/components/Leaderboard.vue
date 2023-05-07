<template>
  <h1>Leaderboard</h1>
  <v-table style="max-width: 800px">
    <thead>
      <tr>
        <th class="text-left">Name</th>
        <th class="text-left">Average Guesses</th>
        <th class="text-left">Games Played</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in desserts" :key="item.name">
        <td>{{ item.name }}</td>
        <td>{{ item.averageGuesses }}</td>
        <td>{{ item.gameCount }}</td>
      </tr>
    </tbody>
  </v-table>
</template>

<script setup lang="ts">
const desserts = [
  { name: 'ben', averageGuesses: '5', gameCount: '2' },
  { name: 'ben', averageGuesses: '5', gameCount: '2' },
  { name: 'ben', averageGuesses: '5', gameCount: '2' },
  { name: 'ben', averageGuesses: '5', gameCount: '2' },
  { name: 'ben', averageGuesses: '5', gameCount: '2' }
]

import Axios from 'axios'
import { ref } from 'vue'
import type { LeaderBoardData } from '@/types/LeaderBoardData'

const leaderboardData = ref<LeaderBoardData[]>()

Axios.get('https://localhost:7053/api/Leaderboard')
  .then((response) => {
    console.log(response.data)
    leaderboardData.value = response.data
  })
  .catch((err) => {
    console.log(err)
  })
</script>
