<template>
  <v-dialog>
    <v-card>
      <v-card-title>Weather or Not</v-card-title>
      <v-card-text>
        {{ weather.date }} - {{ weather.temperatureC }} - {{ weather.summary }}</v-card-text
      >
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import type { WeatherData } from '@/types/WeatherData'

const props = defineProps<{
  weather: WeatherData
}>()
</script>
