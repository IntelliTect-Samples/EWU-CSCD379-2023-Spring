<template>
  <v-sheet>
    <v-card>
      <v-card-title>Leader Board</v-card-title>
        <v-progress-linear 
        v-for="(player, index) in playerData"
      :key="player.PlayerID"
      cols="auto"
          v-model="progress[index + 1]"
          color="amber"
          height="25"
        >
        <strong>{{ index + 1 }}: {{ player.Name }} Number of Games: {{ player.GameCount }} 
          Average Guesses: {{ player.AverageAttempts }} Average Time: {{ player.AverageSecondsPerGame }} </strong> 
      </v-progress-linear>
      
      <v-btn @click="$router.back()">Back</v-btn>
    </v-card>
  </v-sheet>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'
import type { PlayerData } from '@/types/PlayerData'

const progress = ref([100,80,60,40,20,18,16,14,18,10])

const playerData = ref<PlayerData[]>([])

Axios.get('topTen')
  .then((response) => {
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



