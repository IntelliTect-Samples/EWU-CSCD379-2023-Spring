<template>
  <v-sheet>
    <v-card>
      <v-card-title>Leader Board</v-card-title>
        <v-progress-linear 
          v-model="progress[0]"
          color="amber"
          height="25"
          v-for="(player, index) in playerData"
    :key="player.PlayerID"
        ><strong>{{ index + 1 }}: {{ player.Name }} Number of Games: {{ player.GameCount }} Average Guesses: {{ player.AverageAttempts }} Average Time: {{ player.AverageSecondsPerGame }} </strong> 
        </v-progress-linear>
      <v-progress-linear 
        v-model="progress[1]"
        color="#AFAFAF"
        height="25"
        v-for="(player, index) in playerData"
    :key="player.PlayerID"
        ><strong>{{ index + 2 }}: {{ player.Name }} Number of Games: {{ player.GameCount }} Average Guesses: {{ player.AverageAttempts }} Average Time: {{ player.AverageSecondsPerGame }} </strong> 
      </v-progress-linear>
      <v-progress-linear 
        v-model="progress[2]"
        color="#CD7F32"
        height="25"
        v-for="(player, index) in playerData"
    :key="player.PlayerID"
        ><strong>{{ index + 3 }}: {{ player.Name }} Number of Games: {{ player.GameCount }} Average Guesses: {{ player.AverageAttempts }} Average Time: {{ player.AverageSecondsPerGame }} </strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[3]"
        color="#757575"
        height="25"
        v-for="(player, index) in playerData"
    :key="player.PlayerID"
        ><strong>{{ index + 4 }}: {{ player.Name }} Number of Games: {{ player.GameCount }} Average Guesses: {{ player.AverageAttempts }} Average Time: {{ player.AverageSecondsPerGame }} </strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[4]"
        color="#757575"
        height="25"
        v-for="(player, index) in playerData"
    :key="player.PlayerID"
        ><strong>{{ index + 5 }}: {{ player.Name }} Number of Games: {{ player.GameCount }} Average Guesses: {{ player.AverageAttempts }} Average Time: {{ player.AverageSecondsPerGame }} </strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[5]"
        color="#757575"
        height="25"
        v-for="(player, index) in playerData"
    :key="player.PlayerID"
        ><strong>{{ index + 6 }}: {{ player.Name }} Number of Games: {{ player.GameCount }} Average Guesses: {{ player.AverageAttempts }} Average Time: {{ player.AverageSecondsPerGame }} </strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[6]"
        color="#757575"
        height="25"
        v-for="(player, index) in playerData"
    :key="player.PlayerID"
        ><strong>{{ index + 7 }}: {{ player.Name }} Number of Games: {{ player.GameCount }} Average Guesses: {{ player.AverageAttempts }} Average Time: {{ player.AverageSecondsPerGame }} </strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[7]"
        color="#757575"
        height="25"
        v-for="(player, index) in playerData"
    :key="player.PlayerID"
        ><strong>{{ index + 8 }}: {{ player.Name }} Number of Games: {{ player.GameCount }} Average Guesses: {{ player.AverageAttempts }} Average Time: {{ player.AverageSecondsPerGame }} </strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[8]"
        color="#757575"
        height="25"
        v-for="(player, index) in playerData"
    :key="player.PlayerID"
        ><strong>{{ index + 9 }}: {{ player.Name }} Number of Games: {{ player.GameCount }} Average Guesses: {{ player.AverageAttempts }} Average Time: {{ player.AverageSecondsPerGame }} </strong> 
    </v-progress-linear>
      <v-progress-linear 
        v-model="progress[9]"
        color="#757575"
        height="25"
        v-for="(player, index) in playerData"
    :key="player.PlayerID"
        ><strong>{{ index + 10 }}: {{ player.Name }} Number of Games: {{ player.GameCount }} Average Guesses: {{ player.AverageAttempts }} Average Time: {{ player.AverageSecondsPerGame }} </strong> 
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



