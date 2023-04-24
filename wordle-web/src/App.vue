<template>
  <v-app class="justify-center">
    <AppBar></AppBar>
    <main class="pt-16">
      <v-spacer></v-spacer>

      <RouterView />
    </main>
  </v-app>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router'
import AppBar from './components/AppBar.vue'
</script>
