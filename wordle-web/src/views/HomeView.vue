<script setup lang="ts">
import TheWelcome from '../components/TheWelcome.vue'
</script>

<template>
  <main>
    <RouterLink to="/game">
      <v-btn variant="outlined">
        To the Game view!
      </v-btn>
    </RouterLink>
    <TheWelcome />
  </main>
</template>
