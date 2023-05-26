<template>
<v-card>
    <v-card-title class="text-center"><strong>Last 10 Wordle of the day</strong></v-card-title>
    <v-table density="compact" >
        <thead>
      <tr>
        <th class="text-left">
        Date
        </th>
        <th class="text-left">
        Average Seconds Per Game
        </th>
        <th class="text-left">
        Average Attempts
        </th>
        <th class="text-left">
        Number of Plays
        </th>
        <th class="text-left">
        Has User Played
        </th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in playerData" :key="item">
        <td>{{ item.Date.split('T')[0] }}</td>
        <td>{{ item.AverageSecondsPerGame === -1 ? 0 : item.AverageSecondsPerGame }}</td>
        <td>{{ item.AverageAttempts === -1 ? 0 : item.AverageAttempts }}</td>
        <td>{{ item.NumberOfPlays }}</td>
        <td>{{ item.HasUserPlayed }}</td>
      </tr>
    </tbody>
    </v-table>
</v-card>


<v-overlay
      :model-value="overlay"
      class="align-center justify-center"
    >
      <v-progress-circular
        color="primary"
        indeterminate
        size="64"
      ></v-progress-circular>
    </v-overlay>


</template>

<script setup lang="ts">
import { ref } from 'vue';
import Axios from 'axios'

interface WordOfTheDayStatsDto {
  Date: string;
  AverageSecondsPerGame: number;
  AverageAttempts: number;
  NumberOfPlays: number;
  HasUserPlayed: boolean;
}

const playerData = ref<WordOfTheDayStatsDto[]>([]);
const overlay = ref(true);

Axios.get('Word/GetDailyWordStatistics')
  .then((response) => {
    console.log(response.data);
    playerData.value = response.data.map((item: WordOfTheDayStatsDto) => ({
      date: item.Date,
      averageSecondsPerGame: item.AverageSecondsPerGame,
      averageAttempts: item.AverageAttempts,
      numberOfPlays: item.NumberOfPlays,
      hasUserPlayed: item.HasUserPlayed,
    }));
    overlay.value = false;
  })
  .catch((error) => {
    console.log(error);
  });


</script>