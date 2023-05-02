<template>
  <v-card class="mx-auto mt-12" max-width="844">
    <v-img src="https://i.makeagif.com/media/2-08-2016/LUwPC9.gif" max-width="320"></v-img>
    <v-card-title> Meg is super cool and awesome and likes cats and and </v-card-title>

    <v-card-text>
      This site is a group project for a class, duplicating the Wordle Project in Vue.
    </v-card-text>
    <v-card-actions>
      <v-container>
        <v-btn variant="outlined" @click="goBack">Go Back</v-btn>
      </v-container>
    </v-card-actions>
  </v-card>

  
  <WeatherDialog v-model="isOpen" :weather="currentWeather"></WeatherDialog>

  <v-card v-for="item in weatherData" :key="item.date" @click="setCurrentWeather(item)">
    {{ item.date }}
  </v-card>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router'
import Axios from 'axios'
import { ref } from 'vue'
import WeatherDialog from '@/components/WeatherDialog.vue'
import type { WeatherData } from '@/types/WeatherData'

const router = useRouter()
function goBack() {
  router.back()
}

const isOpen = ref(false)
const weatherData = ref<WeatherData[]>()
const currentWeather = ref<WeatherData>()

function setCurrentWeather(weather: WeatherData) {
  currentWeather.value = weather
  isOpen.value = true
}

Axios.get('https://wordleweb.azurewebsites.net/WeatherForecast')
  .then((response) => {
    console.log(response.data)
    weatherData.value = response.data
  })
  .catch((err) => {
    console.log(err)
  })
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
