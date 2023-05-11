<template>
  <v-sheet>
    <v-card>
      <v-card-title>Leader Board</v-card-title>
      <v-progress-linear 
        v-model="progress[0]"
        color="amber"
        height="25"
      ><strong>First place: {{ playerData[0].Name }} Number of Games: {{ playerData[0].GameCount }} Average Guesses: {{ playerData[0].AverageAttempts }} Average Time: {{ playerData[0].AverageSecondsPerGame }} </strong> 
      </v-progress-linear>
      <v-progress-linear 
        v-model="progress[1]"
        color="#AFAFAF"
        height="25"
      ><strong>Second place: {{ playerData[1].Name }} Number of Games: {{ playerData[1].GameCount }} Average Guesses: {{ playerData[1].AverageAttempts }} Average Time: {{ playerData[1].AverageSecondsPerGame }}</strong> 
      </v-progress-linear>
      <v-progress-linear 
        v-model="progress[2]"
        color="#CD7F32"
        height="25"
      ><strong>Third place: {{ playerData[2].Name }} Number of Games: {{ playerData[2].GameCount }} Average Guesses: {{ playerData[2].AverageAttempts }} Average Time: {{ playerData[2].AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[3]"
        color="#757575"
        height="25"
      ><strong>Fourth place: {{ playerData[3].Name }} Number of Games: {{ playerData[3].GameCount }} Average Guesses: {{ playerData[3].AverageAttempts }} Average Time: {{ playerData[3].AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[4]"
        color="#757575"
        height="25"
      ><strong>Fifth place: {{ playerData[4].Name }} Number of Games: {{ playerData[4].GameCount }} Average Guesses: {{ playerData[4].AverageAttempts }} Average Time: {{ playerData[4].AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[5]"
        color="#757575"
        height="25"
      ><strong>Sixth place: {{ playerData[5].Name }} Number of Games: {{ playerData[5].GameCount }} Average Guesses: {{ playerData[5].AverageAttempts }} Average Time: {{ playerData[5].AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[6]"
        color="#757575"
        height="25"
      ><strong>Seventh place: {{ playerData[6].Name }} Number of Games: {{ playerData[6].GameCount }} Average Guesses: {{ playerData[6].AverageAttempts }} Average Time: {{ playerData[6].AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[7]"
        color="#757575"
        height="25"
      ><strong>Eighth place: {{ playerData[7].Name }} Number of Games: {{ playerData[7].GameCount }} Average Guesses: {{ playerData[7].AverageAttempts }} Average Time: {{ playerData[7].AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[8]"
        color="#757575"
        height="25"
      ><strong>Ninth place: {{ playerData[8].Name }} Number of Games: {{ playerData[8].GameCount }} Average Guesses: {{ playerData[8].AverageAttempts }} Average Time: {{ playerData[8].AverageSecondsPerGame }}</strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[9]"
        color="#757575"
        height="25"
      ><strong>Tenth place: {{ playerData[9].Name }} Number of Games: {{ playerData[9].GameCount }} Average Guesses: {{ playerData[9].AverageAttempts }} Average Time: {{ playerData[9].AverageSecondsPerGame }}</strong> 
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



