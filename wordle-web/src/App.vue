<template>
  <v-app>
    <Navbar />
    <v-content>
      <RouterView></RouterView>
    </v-content>
  </v-app>
</template>

<script setup lang="ts">
import Navbar from './components/NavBar.vue'
</script>
