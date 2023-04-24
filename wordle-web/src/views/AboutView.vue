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
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router'
const router = useRouter()
function goBack() {
  router.back()
}
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
