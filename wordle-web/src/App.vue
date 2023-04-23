<template>
  <header>
    <div class="wrapper">
      <nav>
        <RouterLink to="/">Home</RouterLink> | <RouterLink to="/wordle">Wordle</RouterLink> |
        <RouterLink to="/about">About</RouterLink>
      </nav>
      <v-btn @click="setLightTheme"> Light Theme </v-btn>
      <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
      <v-btn @click="setDefault">Default Colors</v-btn>
      <v-btn @click="setNeon">Neon Colors</v-btn>
    </div>
  </header>

  <RouterView />
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()

function setLightTheme() {
  if(theme.global.name.value == 'neonLight') {
    theme.global.name.value = 'neonLight'
  }
  else {
    theme.global.name.value = 'light'
  }
}

function setDarkTheme() {
  if(theme.global.name.value == 'neonDark') {
    theme.global.name.value = 'neonDark'
  }
  else {
    theme.global.name.value = 'dark'
  }
}

function setNeon() {
  if (theme.global.name.value == 'dark') {
    theme.global.name.value = 'neonDark'
  }
  if (theme.global.name.value == 'light') {
    theme.global.name.value = 'neonLight'
  }
}

function setDefault() {
  if (theme.global.name.value == 'neonDark') {
    theme.global.name.value = 'dark'
  }
  if (theme.global.name.value == 'neonLight') {
    theme.global.name.value = 'light'
  }
}
</script>
