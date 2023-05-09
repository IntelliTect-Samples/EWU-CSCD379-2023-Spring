<template>
  <h1>LeaderBoard</h1>
  <div>
    <v-carousel>
      <v-carousel-item width="700px">
        <v-card class="text-center">
          <v-card-title class="display-1"> LeaderBoard </v-card-title>
          <v-list v-for="(player, i) in players" :key="i">
            {{ players[i] }}
          </v-list>
        </v-card>
      </v-carousel-item>
      <v-carousel-item width="700px">
        <v-card class="text-center">
          <v-card-title class="display-1"> Personal Stats </v-card-title>
          <v-card-item> Username: {{ username }} </v-card-item>
        </v-card>
      </v-carousel-item>
    </v-carousel>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'

let dialog = ref(true)
let username = ref(localStorage.getItem('username') || 'Guest')
let players = new Array<string>()

Axios.get('leaderboard/GetTopTenScores')
  .then((response) => {
    players[0] = response.data[0]
    players[1] = response.data[1]
    players[2] = response.data[2]
    players[3] = response.data[3]
    players[4] = response.data[4]
    players[5] = response.data[5]
    players[6] = response.data[6]
    players[7] = response.data[7]
    players[8] = response.data[8]
    players[9] = response.data[9]
    console.log(response.data)
  })
  .catch((error) => {
    console.log(error)
  })
</script>

<style>
.v-card {
  height: 100%;
}
</style>
