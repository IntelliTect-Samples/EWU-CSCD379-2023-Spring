<template>
  <v-sheet>
    <v-card>
      <v-card-title>Leader Board</v-card-title>
        <v-progress-linear 
          v-model="progress[0]"
          color="#757575"
          height="25"
        >
        <strong>{{ playerData }}</strong>>
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


var playerData = ref<PlayerData[]>([])

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



