<template>
  <v-container class="d-flex justify-center align-center">
    <v-card>
      <div class="bg-primary text-h5 pa-3 text-center">Leader Board</div>
      <v-card-text>
        <div
          v-for="(score, index) in scores"
          :key="`${score.score} + ${index}`"
          class="border my-3"
        >
          <div class="d-flex justify-center bg-secondary text-h6">
            #{{ index + 1 }} - {{ score.playerName }}
          </div>
          <v-card-text class="d-flex flex-column align-center">
            <v-row dense>
              <v-col cols="6" class="text-end">Score -</v-col>
              <v-col cols="6">{{ score.score }}</v-col>
              <v-col cols="6" class="text-end">Attempts -</v-col>
              <v-col cols="6">{{ score.attempts }}</v-col>
              <v-col cols="6" class="text-end">Duration -</v-col>
              <v-col cols="6">{{ formatTime(score.duration) }}</v-col>
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
import type { PlayerResult } from '@/scripts/wordleGame'
import { formatTime } from '@/scripts/timer'
const scores = ref<PlayerResult[]>([])
Axios.get('/playerresult/topscores').then((res) => {
  scores.value = res.data as PlayerResult[]
})
</script>
