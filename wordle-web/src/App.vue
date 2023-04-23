<template>
  <v-app>
    <AppBar></AppBar>
    <main class="pt-16">
      <v-spacer></v-spacer>

      <RouterView />

    </main>
  </v-app>
  
  
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router'
import { useTheme } from 'vuetify/lib/framework.mjs'
import AppBar from './components/AppBar.vue';

const theme = useTheme()

// TODO: Need to get toggle theme buttons inside of AppBar component
function toggleTheme() {
  if (theme.global.name.value === 'light') {
    theme.global.name.value = 'dark'
  } else if (theme.global.name.value === 'dark') {
    theme.global.name.value = 'light'
  }
}
</script>

<style scoped>
#toolbar {
  width: 100%;
  padding: 6px 24px;
  font-size: 26px;
  font-weight: bold;
  border-bottom: 1px solid #656464; /* TODO: Maybe a different color? */
  min-height: 65px;
}
</style>
