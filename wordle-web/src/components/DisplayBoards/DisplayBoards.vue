<template>
  <h1>LeaderBoard</h1>
  <div>
    <v-carousel>
      <v-carousel-item>
        <v-card class="text-center">
          <Leaderboard />
        </v-card>
      </v-carousel-item>
      <v-carousel-item width="700px">
        <PersonalStats />
      </v-carousel-item>
    </v-carousel>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'
import Leaderboard from '@/components/DisplayBoards/Leaderboard.vue'
import PersonalStats from '@/components/DisplayBoards/PersonalStats.vue'

interface Player {
  playerId: number
  playerName: string
  gameCount: number
  totalTimeInSeconds: number
  averageTimeInSeconds: number
  totalAttempts: number
  averageAttempts: number
}

let username = ref(localStorage.getItem('username') || 'Guest')
const players = ref<Player[]>()
// store the index at which the current user is in the array, into variable
let currentUserIndex = players.value?.findIndex((player) => player.playerName === username.value)

console.log(currentUserIndex)

Axios.get('leaderboard/GetTopTenScores')
  .then((response) => {
    setTimeout(() => {}, 100)
    players.value = response.data
  })
  .catch((err) => {
    console.log(err)
  })

console.log(players)
</script>

<style>
.v-card {
  height: 100%;
}
</style>
