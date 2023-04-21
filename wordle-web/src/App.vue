<template>
  <header>
    <div class="wrapper">
      <NavBar></NavBar>
    </div>
  </header>
  <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
  <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
  <RouterView />
</template>

<script setup lang="ts">
import NavBar from '@/components/NavBar.vue'
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}
</script>
