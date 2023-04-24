<template>
  <header>
    <AppBar />
    <div class="wrapper">
      <nav>
        <RouterLink to="/">Home</RouterLink> | <RouterLink to="/wordle">Wordle</RouterLink> |
        <RouterLink to="/about">About</RouterLink>
      </nav>
      <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
      <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
      <v-spacer></v-spacer>
      <v-btn @click="setNeonTheme"> Neon Theme </v-btn>
      <v-btn @click="setPastelTheme"> Pastel Theme </v-btn>
    </div>
  </header>

  <RouterView />
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import AppBar from './components/AppBar.vue'

const theme = useTheme()

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}

function setNeonTheme() {
  theme.global.name.value = 'neon'
}

function setPastelTheme() {
  theme.global.name.value = 'pastel'
}
</script>
