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
      <v-card-title class="titleText">Words of the Day Games! </v-card-title>
      <v-card-text>
        <v-row justify="center">
          <v-col v-for="date in dates" :key="date" class="ma-2">
            <v-btn
              :to="`/wordOfTheDay/${date}`"
              outlined
              :color="isDatePlayed(date) ? 'green' : 'red'"
            >
              <span class="bodyText">
                {{ date }}
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
      dates: [
        '2023-05-01',
        '2023-05-02',
        '2023-05-03',
        '2023-05-04',
        '2023-05-05',
        '2023-05-06',
        '2023-05-07',
        '2023-05-08',
        '2023-05-09',
        '2023-05-10'
      ],
      playedDates: ['2023-05-02', '2023-05-05', '2023-05-07', '2023-05-09']
    }
  },
  methods: {
    isDatePlayed(date) {
      return this.playedDates.includes(date)
    }
  }
}
</script>

<style scoped>
@media (max-width: 600px) {
  .bodyText {
    font-size: 12px;
  }
  .subText {
    font-size: 10px;
  }
  .titleText {
    font-size: 20px;
  }
}

@media (min-width: 601px) {
  .bodyText {
    font-size: 16px;
  }
  .subText {
    font-size: 14px;
  }
  .titleText {
    font-size: 28px;
  }
}

@media (min-width: 1200px) {
  .bodyText {
    font-size: 20px;
  }
  .subText {
    font-size: 18px;
  }
  .titleText {
    font-size: 30px;
  }
}
</style>
