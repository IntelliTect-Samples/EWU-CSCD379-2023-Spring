<template>
  <v-container class="d-flex justify-center align-center">
    <v-card>
      <div class="bg-primary text-h5 pa-3 text-center">Leader Board</div>
      <v-card-text>
        <div v-for="(player, index) in players" :key="player.playerId" class="border my-3">
          <div class="d-flex justify-center bg-secondary text-h6 tile-top">
            #{{ index + 1 }} - {{ player.name }}
          </div>
          <v-card-text class="d-flex flex-column align-center">
            <v-row dense>
              <v-col cols="6" class="text-end">Count -</v-col>
              <v-col cols="6">{{ player.gameCount }}</v-col>
              <v-col cols="6" class="text-end">Attempts -</v-col>
              <v-col cols="6">{{ player.averageAttempts }}</v-col>
              <v-col cols="6" class="text-end">Duration -</v-col>
              <v-col cols="6">{{ formatTime(player.averageSecondsPerGame) }} sec</v-col>
            </v-row>
          </v-card-text>
        </div>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<style>
.tile-top {
  border-bottom: 5px solid grey;
  animation-name: pulse;
  animation-duration: 3s;
  animation-iteration-count: infinite;
  animation-timing-function: linear;
}
@keyframes pulse {
  0%   {border-color: #ff5900;}
  50%  {border-color: maroon;}
  100% {border-color: #ff5900;}
}
</style>

<script lang="ts" setup>
import Axios from 'axios'
import { ref } from 'vue'
import { Player } from '@/scripts/player'
import { formatTime } from '@/scripts/helpers'
const players = ref<Player[]>([])
const playerD = new Player()
playerD.name = "Mildly"
playerD.gameCount = 42
playerD.averageAttempts = 1.8
players.value.push(playerD)
const playerE = new Player()
playerE.name = "Pointless"
playerE.gameCount = 3
playerE.averageAttempts = 5.5
players.value.push(playerE)
const playerA = new Player()
playerA.name = "Illusion"
playerA.gameCount = 5
playerA.averageAttempts = 2.5
players.value.push(playerA)
const playerB = new Player()
playerB.name = "Of_A"
playerB.gameCount = 75
playerB.averageAttempts = 1.2
players.value.push(playerB)
const playerC = new Player()
playerC.name = "Leaderboard"
playerC.gameCount = 19
playerC.averageAttempts = 5.7
players.value.push(playerC)

Axios.get('/player/TopPlayers').then((result) => {
  players.value = result.data as Player[]
})
</script>
