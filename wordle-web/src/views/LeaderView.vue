<template>
  <v-sheet
    :rounded="true"
    :elevation="4"
    width="600px"
    height="600px"
    class="mx-auto my-6"
    color="green"
  >
    <v-card height="100px" class="mb-4" :style="{ padding: '7px' }">
      <v-card-item class="mx-auto mr-12">
        <v-card-title class="text-center" style="font-size: 3em">
          <v-icon icon="mdi-trophy" class="mb-5" color="yellow" size="60"> </v-icon>
          Leaderboard
        </v-card-title>
      </v-card-item>
    </v-card>
    <v-row
      class="justify-center"
      dense
      v-for="(leader, index) in leaderData"
      :key="leader.playerId"
      :class="{ 'flip-in-x': showLeaderData }"
    >
      <v-col cols="auto">
        <v-card
          :style="{
            padding: '7px',
            width: '475px',
            animationDelay: `${index * 0.03}s`
          }"
          class="flip-in-x"
        >
          {{ index + 1 }}: {{ leader.name }} - {{ leader.gameCount }} games,
          {{ leader.averageAttempts }} average attempts
          <v-icon v-if="index === 0" color="yellow" size="25">mdi-crown</v-icon>
        </v-card>
      </v-col>
    </v-row>
  </v-sheet>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import Axios from 'axios'
import type { LeaderData } from '@/types/LeaderData'

const leaderData = ref<LeaderData[]>([])
const showLeaderData = ref(false)

onMounted(() => {
  setTimeout(() => {
    showLeaderData.value = true
  })
})

Axios.get('/Leaderboard/GetTopTenScores')
  .then((response) => {
    console.log(response.data)
    leaderData.value = response.data
  })
  .catch((err) => {
    console.log(err)
  })
</script>

<style scoped>
.flip-in-x {
  animation-duration: 2s;
  animation-fill-mode: forwards;
}

@keyframes flip-in-x {
  0% {
    transform: rotateX(90deg);
  }
  100% {
    transform: rotateX(0deg);
  }
}

.flip-in-x {
  animation-name: flip-in-x;
}
</style>
