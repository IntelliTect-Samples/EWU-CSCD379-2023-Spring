<template>
  <v-sheet>
    <v-card>
      <v-card-title>Leader Board</v-card-title>
        <v-progress-linear 
          v-model="progress[0]"
          color="amber"
          height="25"
        >
        <strong>First: {{ playerData[0].Name }} Number of Games: {{ playerData[0].GameCount }} 
          Average Guesses: {{ playerData[0].AverageAttempts }} Average Time: {{ playerData[0].AverageSecondsPerGame }} </strong> 
      </v-progress-linear>
      <v-progress-linear 
          v-model="progress[1]"
          color="#CD7F32S"
          height="25"
        >
        <strong>Second: {{ playerData[1].Name }} Number of Games: {{ playerData[1].GameCount }} 
          Average Guesses: {{ playerData[1].AverageAttempts }} Average Time: {{ playerData[1].AverageSecondsPerGame }} </strong> 
      </v-progress-linear>
      <template v-for="i in 8" :key="i.id">
        <v-progress-linear 
          v-model="progress[i+3]"
          color="#757575"
          height="25"
        >
        <strong>{{ i+3 }}: {{ playerData[i+3].Name }} Number of Games: {{ playerData[i+3].GameCount }} 
          Average Guesses: {{ playerData[i+3].AverageAttempts }} Average Time: {{ playerData[i+3].AverageSecondsPerGame }}</strong>
        </v-progress-linear>
      </template>
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



