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
import AppBar from './components/AppBar.vue'

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
