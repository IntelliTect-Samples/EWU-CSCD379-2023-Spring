<template>
  <v-container class="d-flex justify-center align-center">
    <v-card>
      <div class="text-h1 text-center">LeaderBoard</div>
      <v-card-text>
        <div
          v-for="(score, index) in scores"
          :key="`${score.score} + ${index}`"
          class="border my-2"
        >
          <div class="d-flex justify-center bg-secondary text-h8">
            #{{ index + 1 }} - {{ score.playerName }}
          </div>
          <v-card-text class="d-flex flex-column align-center">
            <v-row dense>
              <v-col cols="5" class="text-end">Score -</v-col>
              <v-col cols="5">{{ score.score }}</v-col>
              <v-col cols="5" class="text-end">Attempts -</v-col>
              <v-col cols="5">{{ score.attempts }}</v-col>
              <v-col cols="5" class="text-end">Duration -</v-col>
              <v-col cols="5">{{ formatTime(score.duration) }}</v-col>
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
import type { GameResult } from '@/scripts/wordleGame'
import { formatTime } from '@/scripts/time'

const scores = ref<GameResult[]>([])

Axios.get('/gameresult/topscores').then((res) => {
  scores.value = res.data as GameResult[]
})
</script>
