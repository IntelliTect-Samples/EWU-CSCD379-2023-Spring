<template>
  <v-card-title primary-title class="justify-center">
    <v-card-text>
      Welcome our Wordle game.
    </v-card-text>
  </v-card-title>
</template>
<script setup lang="ts">
//This class is for the home screen
import { useRouter } from 'vue-router'

const router = useRouter()
function Back() {
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
