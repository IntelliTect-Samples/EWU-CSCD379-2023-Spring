<template>
  <v-container class="d-flex justify-center align-center">
    <v-card color="brown-darken-2">
      <div class="text-h2 text-center">LeaderBoard</div>
      <v-card-text>
        <div
          v-for="(score, index) in scores"
          :key="`${score.score} + ${index}`"
          class="border my-8"
        >
          <div class="text-h8">{{ index + 1 }}'s Place: {{ score.playerName }}</div>
          <v-card-text class="align-center">
            <v-row dense>
              <v-col cols="2">Score: </v-col>
              <v-col >{{ score.score }}</v-col>
              <v-col cols="4">Attempts: </v-col>
              <v-col >{{ score.attempts }}</v-col>
              <v-col cols="4">Duration:</v-col>
              <v-col >{{ formatTime(score.duration) }}</v-col>
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
