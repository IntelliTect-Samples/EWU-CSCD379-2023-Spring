<template>
  <v-card class="mx-auto mt-9" width="475px" color="cyan">
    <v-card color="yellow-lighten-1" style="border: 1px solid red">
      <v-card-title>Statistics</v-card-title>
    </v-card>

    <v-card v-for="i in 10">
      <v-card color="cyan" style="border: 3px solid red">
        <v-card-title>Date: {{ date }}</v-card-title>
      </v-card>
      <v-list>
        <v-list-item>
          <v-list-item-title>Games Played: {{ gamesPlayed }}</v-list-item-title>
        </v-list-item>
        <v-list-item>
          <v-list-item-title>Average Score: {{ averageTime }}</v-list-item-title>
        </v-list-item>
        <v-list-item>
          <v-list-item-title>Average Time: {{ averageTime }}</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-card>
  </v-card>
</template>

<script setup lang="ts">
import Axios from 'axios'
import { ref } from 'vue'
</script>
