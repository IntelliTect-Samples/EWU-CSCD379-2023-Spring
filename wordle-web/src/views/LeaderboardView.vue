<template>
  <div class="leaderboard-page">
    <center>
      <v-card class="leaderboard">
        <v-card-title>Leader Board</v-card-title>
        <div class="leaderboard-item">
          <h3>Name</h3>
          <h3>Games Played</h3>
          <h3>Average Number of Attempts</h3>
        </div>
        <hr />
        <div v-for="player in players" :key="player" class="leaderboard-item" elevation="1">
          <h4>{{ player.name }}</h4>
          <h4>{{ player.gameCount }}</h4>
          <h4>{{ player.averageAttempts }}</h4>
        </div>
      </v-card>
    </center>
  </div>
</template>
<script setup lang="ts">
import Axios from 'axios'
import { ref } from 'vue'

const players = ref()

Axios.get('https://localhost:7053/Player/GetTopTen')
  .then((response) => {
    console.log(response)
    players.value = response.data
  })
  .catch((error) => {
    console.log(error)
  })
</script>

<style scoped>
.leaderboard {
  width: 60%;
  padding: 2rem;
}
.leaderboard-item {
  display: flex;
  margin-top: 0.5rem;
}
.leaderboard-item h3,
h4 {
  width: 33%;
}

@media (max-width: 1024px) {
  .leaderboard {
    width: 85%;
  }
}
</style>
