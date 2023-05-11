<template>
  <v-sheet>
    <v-card>
      <v-card-title>Leader Board</v-card-title>
        
      <template v-for=" player in playerData" :key="player.PlayerID">
        <v-progress-linear 
          v-model="progress[player.PlayerID]"
          color="#757575"
          height="25"
        >
        <strong>{{ player.Name }}</strong>>
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



