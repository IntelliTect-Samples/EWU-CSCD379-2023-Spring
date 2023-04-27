<template>
  <v-card class="mx-auto mt-15" max-width="844">
    <v-card-text>
      This website is meant to be a replica of the New York Times version of Wordle. Meg is awesome
      and has helped a lot during the production of this website including making it look fun and
      engaging.
    </v-card-text>
    <v-card-actions>
      <v-btn variant="outlined" @click="Back">Go Back</v-btn>
    </v-card-actions>
  </v-card>
</template>
<script setup lang="ts">
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
