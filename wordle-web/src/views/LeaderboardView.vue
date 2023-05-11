<template>
  <v-sheet>
    <v-card>
      <v-card-title>Leader Board</v-card-title>
      <template v-for="player in playerData" v-bind:key="player.name">
        <v-progress-linear 
          v-model="player.averageAttempts"
          max = "6"
          color="#757575"
          height="25"
        >
        <strong>{{ player.name }}</strong>
        </v-progress-linear>
        <div class="text-center">
          Game Count: {{ player.gameCount }}, Average Attempts: {{ player.averageAttempts }}, Average Time Per Game: {{ player.averageSecondsPerGame }} </div>
      </template>
      <v-btn @click="$router.back()">Back</v-btn>
    </v-card>
  </v-sheet>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue';
import Axios from 'axios'

var playerData = ref<PlayerData[]>([])

interface PlayerData {
  name: string
  gameCount: number
  totalAttempts: number
  averageAttempts: number
  totalSecondsPlayed: number
  averageSecondsPerGame: number
}


Axios.get('Player/GetTopTen')
  .then((response) => {
    console.log(response.data)
    playerData.value = response.data
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



