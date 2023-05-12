<template>
  <v-sheet>
    <v-card>
      <div class="text-center">
      <img src="../assets/golden-cup.png" alt="goldcup" height="100" />
      <v-card-title><strong>Leader Board</strong></v-card-title>
      </div>
      <template v-for="player in playerData" v-bind:key="player.name">
        <v-progress-linear 
          :model-value="getScore(player.averageAttempts)"
          max="5"
          color="#757575"
          height="25"
          striped
        >
        <strong>{{ player.name }}</strong>
        </v-progress-linear>
        <div class="text-center">
          Game Count: {{ player.gameCount }}, Average Attempts: {{ player.averageAttempts }}, Average Time To Win: {{ player.averageSecondsPerGame }} </div>
      </template>
      <div class="text-center">
      <v-btn @click="$router.back()" color="primary">Back</v-btn>
      </div>
    </v-card>
  </v-sheet>

  <v-overlay
      :model-value="overlay"
      class="align-center justify-center"
    >
      <v-progress-circular
        color="primary"
        indeterminate
        size="64"
      ></v-progress-circular>
    </v-overlay>

</template>

<script setup lang="ts">
import { ref } from 'vue';
import Axios from 'axios'

var playerData = ref<PlayerData[]>([])
const overlay = ref(true)

interface PlayerData {
  name: string
  gameCount: number
  averageAttempts: number
  averageSecondsPerGame: number
  TotalSecondsPlayed: number
  TotalAttempts: number
}

function getScore(i: number) {
    return (6  - i)
}

Axios.get('Player/GetTopTen')
  .then((response) => {
    console.log(response.data)
    playerData.value = response.data
    overlay.value = false
  })
  .catch((error) => {
    console.log(error)
  })





</script>

<style scoped>
 .v-progress-linear {
  border-radius: 8px;
  width: 99%;
  margin-bottom: 10px;
}
</style>
```



