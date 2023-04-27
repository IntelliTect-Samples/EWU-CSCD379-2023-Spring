<script setup lang="ts">
import { RouterView } from 'vue-router'
import NavBar from '@/components/NavigationBar.vue'
</script>

<template>
  <v-app>
    <NavBar />
    <v-main class="pb">
      <RouterView />
    </v-main>
  </v-app>
</template>

<style scoped>
.v-main {
  align-self: center;
  padding: 4rem 4rem;
  max-width: 50vw;
  min-width: 500px;
}
@media (min-width: 1024px) {
}
</style>
