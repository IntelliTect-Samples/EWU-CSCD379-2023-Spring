<template>
  <v-card>
    <main>-- Last Ten Wordle Days --</main>
  </v-card>
  <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
    <v-progress-circular color="primary" indeterminate size="64" />
  </v-overlay>
  <v-card v-if="!overlay && Days.length">
    <v-table>
      <thead>
        <tr>
          <th class="text-left">Date</th>
          <th class="text-left">Times Played</th>
          <th class="text-left">Average Attempts</th>
          <th class="text-left">Average Seconds</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in Days" :key="item.name">
          <td>{{ item.date }}</td>
          <td>{{ item.timesPlayed }}</td>
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

const overlay = ref(true)
var Days: any[] = []

function goBack() {
  $router.go(-1)
}

Axios.get('GetLastTenDays')
  .then((response) => {
    response.data.forEach((day: any) => {
      Days.push({
        date: `${day.Date}`,
        timesPlayed: `${day.GameCount}`,
        avgAttempts: `${day.AvgAttempts.toFixed(2)}`,
        avgSeconds: `${day.AvgSeconds.toFixed(2)}`
      })

      overlay.value = false
    })
  })
  .catch((error) => {
    console.log(error)
  })
</script>
