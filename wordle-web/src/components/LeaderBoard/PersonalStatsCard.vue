<template>
  <div class="text-center align-center justify-center">
    <v-card-title class="display-1"> Personal Stats </v-card-title>
    <v-table class="align-center justify-center" v-model="player">
      <thead>
        <tr>
          <th class="text-center">Username</th>
          <th class="text-center">Games Played</th>
          <th class="text-center">Average Number of Guesses</th>
          <th class="text-center">Average Time to Finish</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>{{ player.name }}</td>
          <td>{{ player.gameCount }}</td>
          <td>{{ player.averageAttempts }}</td>
          <td>{{ player.averageSecondsPerGame }}</td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'

let userId = ref(localStorage.getItem('userId') || null)
let name = ref(localStorage.getItem('userName') || 'Guest')
let player = ref({
  playerId: userId.value,
  name: name.value,
  gameCount: 0,
  averageAttempts: 0,
  averageSecondsPerGame: 0
})

Axios.get(`/Player?playerId=${userId.value}`)
    .then((response) => {
      setTimeout(() => {}, 100)
      player.value = response.data
    })
    .catch((err) => {
      console.log(err)
    })
</script>
