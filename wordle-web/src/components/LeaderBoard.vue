<template>
    <v-container class="d-flex justify-center align-center">
      <v-card>
        <v-text class="text-h5">Leaderboard</v-text>
        <v-table style="max-width: 800px">
          <thead>
            <tr>
              <th class="text-left">Name</th>
              <th class="text-left">Average Guesses</th>
              <th class="text-left">Games Played</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in leaderboardData" :key="item.name">
              <td>{{ item.name }}</td>
              <td>{{ Math.round((item.averageAttempts + Number.EPSILON) * 100) / 100 }}</td>
              <td>{{ item.gameCount }}</td>
            </tr>
          </tbody>
        </v-table>
      </v-card>
    </v-container>
  </template>

<script setup lang="ts">
import Axios from 'axios'
import { ref } from 'vue'
import type { LeaderBoardData } from '@/types/LeaderBoardData'

const leaderboardData = ref<LeaderBoardData[]>()

Axios.get('https://calvarezassignment-3.azurewebsites.net/Leaderboard/Leaderboard')
  .then((response) => {
    console.log(response.data)
    leaderboardData.value = response.data
  })
  .catch((err) => {
    console.log(err)
  })
</script>