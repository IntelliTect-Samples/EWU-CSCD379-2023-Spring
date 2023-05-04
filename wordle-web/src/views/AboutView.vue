<template>
<<<<<<< HEAD
  <div>
    <h1>This is an about page</h1>
    <p>
      This is website designed to allow you to play the hit game Wordle. Wordle is a game in which
      you are provided 6 guesses to figure out what a 5 letter word is. It will tell you which
      letters were misplaced, which letters are incorrect and which letters are correctly placeed.
      Wordle is a great game, but not as great as Meg is!
    </p>
  </div>
  <div>
    <v-btn density="compact" @click="goBack"> Back </v-btn>
  </div>
</template>

<script setup lang="ts">
import $router from '../router/index'

function goBack() {
  $router.go(-1)
}
=======
  <v-sheet color="blue" height="170px" class="pt-10 my-5">
    <v-card color="indigo-darken-3" class="ma-5" elevation="5" rounded="xl">
      <v-card-title>Hello World</v-card-title>
    </v-card>
  </v-sheet>

  {{ isDialogOpen }}
  <WeatherDialog v-model="isDialogOpen" :weather="currentWeather!"></WeatherDialog>

  <v-card v-for="item in weatherData" :key="item.date" @click="setCurrentWeather(item)">
    {{ item.date }}</v-card
  >
</template>

<script setup lang="ts">
import Axios from 'axios'
import { ref } from 'vue'
import WeatherDialog from '@/components/WeatherDialog.vue'
import type { WeatherData } from '@/types/WeatherData'

const isDialogOpen = ref(false)
const weatherData = ref<WeatherData[]>()
const currentWeather = ref<WeatherData>()

function setCurrentWeather(weather: WeatherData) {
  currentWeather.value = weather
  isDialogOpen.value = true
}

Axios.get('https://localhost:7053/WeatherForecast')
  .then((response) => {
    console.log(response.data)
    weatherData.value = response.data
  })
  .catch((err) => {
    console.log(err)
  })
>>>>>>> 65d410439297113ad6946631cf981f206191fc49
</script>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
