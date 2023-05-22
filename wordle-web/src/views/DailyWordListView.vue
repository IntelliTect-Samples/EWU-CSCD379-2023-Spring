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
      <v-card-title class="titleText">Word Of The Day Games!</v-card-title>
      <v-card-text>
        <v-row justify="center">
          <v-col v-for="stats in gameStats" :key="stats.date" class="ma-2">
            <v-btn
              height="100%"
              :to="`/wordOfTheDay/${date}`"
              outlined
              :color="isDatePlayed(stats.date) ? 'green' : 'red'"
            >
              <span class="bodyText"
                >{{ stats.date }}
                <div class="stats">
                  <div>Avg Guesses: {{ getAverageGuesses(date) }}</div>
                  <div>Avg Seconds per Game: {{ getAverageSeconds(date) }}</div>
                  <div>Total Games: {{ getTotalGames(date) }}</div>
                </div>
              </span>
            </v-btn>
          </v-col>
        </v-row>
      </v-card-text>
    </v-card>
  </v-col>
</template>

<script>
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
    isDatePlayed(date) {
      return this.playedDates.includes(date)
    },
    getAverageGuesses(date) {
      return this.gameStats[date] ? this.gameStats[date].avgGuesses : 0
    },
    getAverageSeconds(date) {
      return this.gameStats[date] ? this.gameStats[date].avgSeconds : 0
    },
    getTotalGames(date) {
      return this.gameStats[date] ? this.gameStats[date].totalGames : 0
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
