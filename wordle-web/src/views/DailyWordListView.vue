<template>
  <v-col>
    <v-card
      class="align-center text-center mx-auto"
      max-height="100%"
      max-width="90%"
      min-height="90%"
      min-width="25%"
      rounded
    >
      <v-card-title class="titleText">Word Of The Day Games! (Dummy Data)</v-card-title>
      <v-card-text>
        <v-row justify="center">
          <v-col v-for="stats in gameStats" :key="stats.date" class="ma-2">
            <v-btn
              height="100%"
              :to="`/wordOfTheDay/${stats.date}`"
              outlined
              :color="isDatePlayed(stats.date) ? 'green' : 'red'"
            >
              <span class="bodyText"
                >{{ stats.date }}
                <div class="stats">
                  <div>Avg Guesses: {{ stats.avgGuesses }}</div>
                  <div>Avg Seconds per Game: {{ stats.avgSeconds }}</div>
                  <div>Total Games: {{ stats.totalGames }}</div>
                </div>
              </span>
            </v-btn>
          </v-col>
        </v-row>
      </v-card-text>
    </v-card>
  </v-col>
</template>

<script lang="ts">
import type { WordOfTheDayStats } from '@/scripts/WordOfTheDayStats'
import Axios from 'axios'
import { type Ref, ref } from 'vue'
import type { PlayerService } from '@/scripts/playerService'
import { mergeProps } from 'vue'

const stats: Ref<Array<WordOfTheDayStats>> = ref([])

function refreshStats() {
  // Grab the stats via axios from /word/WordOfTheDayStats
  Axios.get('/word/WordOfTheDayStats?playerId=' + props.playerId).then((response) => {
    for (let stat of response.data as Array<WordOfTheDayStats>) {
      stat.date = new Date(stat.date)
    }
    stats.value = response.data as Array<WordOfTheDayStats>
    console.log(stats.value)
  })
}

export default {
  data() {
    return {
      playedDates: ['2023-05-02', '2023-05-05', '2023-05-07', '2023-05-09'],
      gameStats: [
        { date: '2023-05-01', avgGuesses: 3.5, avgSeconds: 120, totalGames: 2 },
        { date: '2023-05-02', avgGuesses: 4, avgSeconds: 90, totalGames: 5 },
        { date: '2023-05-03', avgGuesses: 3.8, avgSeconds: 100, totalGames: 3 },
        { date: '2023-05-04', avgGuesses: 3.2, avgSeconds: 150, totalGames: 1 },
        { date: '2023-05-05', avgGuesses: 4.5, avgSeconds: 80, totalGames: 4 },
        { date: '2023-05-06', avgGuesses: 3.9, avgSeconds: 110, totalGames: 2 },
        { date: '2023-05-07', avgGuesses: 3.7, avgSeconds: 95, totalGames: 3 },
        { date: '2023-05-08', avgGuesses: 4.2, avgSeconds: 105, totalGames: 2 },
        { date: '2023-05-09', avgGuesses: 4.1, avgSeconds: 100, totalGames: 4 },
        { date: '2023-05-10', avgGuesses: 3.6, avgSeconds: 125, totalGames: 1 }
      ]
    }
  },
  methods: {
    isDatePlayed(date: string): boolean {
      return this.playedDates.includes(date)
    }
  }
}
</script>

<style scoped>
@media (max-width: 400px) {
  .bodyText {
    font-size: 12px;
  }
  .subText {
    font-size: 10px;
  }
  .stats {
    font-size: 8px;
    font-style: italic;
  }
  .titleText {
    font-size: 20px;
  }
}

@media (min-width: 401px) {
  .bodyText {
    font-size: 16px;
  }
  .subText {
    font-size: 14px;
  }
  .stats {
    font-size: 12px;
    font-style: italic;
  }
  .titleText {
    font-size: 28px;
  }
}

@media (min-width: 800px) {
  .bodyText {
    font-size: 20px;
  }
  .subText {
    font-size: 18px;
  }
  .stats {
    font-size: 16px;
    font-style: italic;
  }
  .titleText {
    font-size: 36px;
  }
}
</style>
