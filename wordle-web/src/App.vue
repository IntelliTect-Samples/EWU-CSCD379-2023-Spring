<template>
  <header>
    
    <div class="wrapper">
      <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
      <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
      <NavBar/>
    </div>
  </header>

  <RouterView />
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import NavBar from '@/components/NavBar.vue'

const theme = useTheme()

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}
</script>
