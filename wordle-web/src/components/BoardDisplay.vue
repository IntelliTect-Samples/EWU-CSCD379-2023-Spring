<template>
  <h1>LeaderBoard</h1>
  <div>
    <v-carousel >
      <v-carousel-item width="700px">
        <v-card class="text-center">
          <v-card-title class="display-1"> LeaderBoard </v-card-title>
        </v-card>
      </v-carousel-item>
      <v-carousel-item width="700px">
        <v-card class="text-center">
          <v-card-title class="display-1"> Personal Stats </v-card-title>
          <v-card-item> Username: {{ username }} </v-card-item>
        </v-card>
      </v-carousel-item>
    </v-carousel>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

let dialog = ref(true)
let username = ref(localStorage.getItem('username') || 'Guest')
</script>

<style>
.v-card {
  height: 100%;
}
</style>
