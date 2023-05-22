<template>
  <v-container class="d-flex justify-center align-center">
    <v-card>
      <div class="bg-primary text-h5 pa-3 text-center">Past Ten Days</div>
      <v-card-text>
        <div v-for="(dayGame, index) in playedGames" :key="dayGame.daysAgo" class="border my-3">
          <div class="d-flex justify-center bg-secondary text-h6">
            <RouterLink v-bind:to="'/wordoftheday?date=' + String(dayGame.date)">{{
              String(dayGame.date).split('T')[0]
            }}</RouterLink>
          </div>
          <v-card-text class="d-flex flex-column align-center">
            <v-row dense>
              <v-col cols="6" class="text-end">Number of Plays -</v-col>
              <v-col cols="6">{{ dayGame.numPlays }}</v-col>
              <v-col cols="6" class="text-end">Average Attempts -</v-col>
              <v-col cols="6">{{ dayGame.avgAttempts }}</v-col>
              <v-col cols="6" class="text-end">Average Duration -</v-col>
              <v-col cols="6">{{ formatTime(dayGame.avgSeconds) }}</v-col>
              <v-col cols="6" class="text-end">Did You Play -</v-col>
              <v-col cols="6" v-if="dayGame.didPlay">Yes</v-col>
              <v-col cols="6" v-else>No</v-col>
            </v-row>
          </v-card-text>
        </div>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script lang="ts" setup>
import Axios from 'axios'
import { ref, inject } from 'vue'
import type { DayResults } from '@/scripts/dayResults'
import { formatTime } from '@/scripts/helpers'
import type { PlayerService } from '@/scripts/playerService'
import { Services } from '@/scripts/services'
import { RouterLink } from 'vue-router'

const playerService = inject(Services.PlayerService) as PlayerService

//const players = ref<Player[]>([])
const playedGames = ref<DayResults[]>([])

var playerId = playerService.player.playerId

Axios.get(
  `/word/LastTenDays?offsetInHours=${new Date().getTimezoneOffset() / -60}&playerId=${playerId}`
).then((result) => {
  console.log(result.data)
  playedGames.value = result.data as DayResults[]
})
</script>
