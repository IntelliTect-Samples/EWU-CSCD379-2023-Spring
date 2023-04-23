<template>
  <v-card class="mx-auto mt-12" max-width="844">
    <v-img
      src="https://www.wric.com/wp-content/uploads/sites/74/2023/04/patches.jpg?w=540"
      cover
    ></v-img>

    <v-card-title> It was foretold, in class. Meg likes cats. </v-card-title>

    <v-card-subtitle> So here's a cat </v-card-subtitle>
    <v-card-text>
      This site is a copy of the game, Wordle, intended to gain experience with front-end
      development using Vue. The homework description says to say that Meg is awesome. Meg is
      awesome.
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
