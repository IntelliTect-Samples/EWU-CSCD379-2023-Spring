<template>
  <v-app class="justify-center">
    <AppBar></AppBar>
    <br />
    <br />
    <br />

    <main>
      <RouterView />
    </main>
  </v-app>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router'
import AppBar from './components/AppBar/AppBar.vue'
</script>
