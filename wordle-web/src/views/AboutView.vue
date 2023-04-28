<template>
  <v-sheet height="170px" class="pt-10 my-5">
    <v-card color="indigo-darken-3" class="ma-5 justify-center" elevation="5" rounded="xl">
      <v-card-title>"CSCD 379 - The best class I've ever taken." </v-card-title>
      <v-card-text> - some guy named Jake</v-card-text>
    </v-card>
  </v-sheet>
  <v-card class="ma-1">
    <v-card-title> *Ahem*.. MEG RULES </v-card-title>
    <v-card-text> - also some guy named Jake</v-card-text>
  </v-card>
  <v-btn to="/wordle"> back to the action </v-btn>
</template>

<!-- <script setup lang="ts">
// import Axios from 'axios';
import { ref } from 'vue';

interface WeatherData {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

const isDialogOpen = ref(false);
const weatherData = ref<WeatherData[]>();

Axios.get('https://localhost:7053/WeatherForecast')
  .then((response) => {
    console.log(response.data);
    weatherData.value = response.data;
  })
  .catch((err) => {
    console.log(err);
  });
</script> -->

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
