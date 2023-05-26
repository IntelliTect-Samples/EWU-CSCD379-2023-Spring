<template>
  <v-container class="d-flex justify-center align-center">
    <v-card>
      <div class="bg-primary text-h5 pa-3 text-center">Daily Words</div>
      <v-card-text>
        <div v-for="(day, index) in dailywords" :key="index" class="border my-3">
          <div class="d-flex justify-center bg-secondary text-h6">
            #{{ index + 1 }} - {{ moment(day.date).format('MMMM DD, YYYY') }}
          </div>
          <v-card-text class="d-flex flex-column align-center">
            <v-row dense>
              <v-col cols="6" class="text-end">Total Games -</v-col>
              <v-col cols="6">{{ day.plays }}</v-col>
              <v-col cols="6" class="text-end">Average Attempts -</v-col>
              <v-col cols="6">{{ day.averageAttempts }}</v-col>
              <v-col cols="6" class="text-end">Average Duration -</v-col>
              <v-col cols="6">{{ day.averageSecondsPerGame }}</v-col>
              <v-col cols="6" class="text-end">Played -</v-col>
              <v-col cols="6">{{ day.hasPlayed }}</v-col>
            </v-row>
          </v-card-text>
        </div>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script lang="ts" setup>
import Axios from 'axios'
import { inject, ref } from 'vue'
import type { DateStats } from '@/scripts/dateStats'
import type { PlayerService } from '@/scripts/playerService'
import { Services } from '@/scripts/services'
import moment from 'moment'

const playerService = inject(Services.PlayerService) as PlayerService

const dailywords = ref<DateStats[]>([])
let id = playerService.player.playerId

Axios.get(`/Word/WordOfTheDayStats?playerId=${id}`).then((result) => {
  console.log(result.data)
  dailywords.value = result.data as DateStats[]
})
</script>
