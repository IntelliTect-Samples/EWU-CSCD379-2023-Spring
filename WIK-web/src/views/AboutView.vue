<template>
  <v-card class="mx-auto mt-12 text-center" max-width="844">
    <v-img src="https://i.redd.it/vevgp409dqw81.gif" max-height="320"></v-img>
    <v-card-title> What is Will it Kill?</v-card-title>

    <v-card-text>
      Will it Kill is an online game wherein people try to guess if a fighting game clip will result
      in someone dying or not, often with the person being hit taking an unexpected amount of
      damage.
    </v-card-text>
    <v-card-actions>
      <v-container>
        <v-btn variant="outlined" @click="goBack">To Home</v-btn>
      </v-container>
    </v-card-actions>
  </v-card>

  <v-card-text> </v-card-text>
  <WeatherDialog v-model="isOpen" :weather="currentWeather!"></WeatherDialog>

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
