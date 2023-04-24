<template>
  <header>
    <div class="wrapper">
      <NavBar class="ma-10"></NavBar>
      
    </div>
  </header>

  <RouterView />
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}
function setKhorneTheme() {
  theme.global.name.value = 'khorne'
}
function setCornTheme() {
  theme.global.name.value = 'corn'
}

import NavBar from '@/components/NavBar.vue'
</script>
