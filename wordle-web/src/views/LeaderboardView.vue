<template>
  <v-container class="d-flex justify-center align-center">
    <v-card>
      <div class="bg-primary text-h5 pa-3 text-center">Leader Board</div>
      <v-card-text>
        <div v-for="(player, index) in players" :key="player.playerId" class="border my-3">
          <div class="d-flex justify-center bg-secondary text-h6">
            #{{ index + 1 }} - {{ player.name }}
          </div>
          <v-card-text class="d-flex flex-column align-center">
            <v-row dense>
              <v-col cols="6" class="text-end">Total Games -</v-col>
              <v-col cols="6">{{ player.gameCount }}</v-col>
              <v-col cols="6" class="text-end">Average Attempts -</v-col>
              <v-col cols="6">{{ player.averageAttempts }}</v-col>
              <v-col cols="6" class="text-end">Average Duration -</v-col>
              <v-col cols="6">{{ formatTime(player.averageSecondsPerGame) }}</v-col>
            </v-row>
          </v-card-text>
        </div>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script lang="ts" setup>
import Axios from 'axios'
import { ref } from 'vue'
import type { Player } from '@/scripts/player'
import { formatTime } from '@/scripts/helpers'

const players = ref<Player[]>([])

Axios.get('/player/TopPlayers').then((result) => {
  console.log(result.data)
  players.value = result.data as Player[]
})
</script>
