<template>
  <v-app>
  <header>
    <v-toolbar id="toolbar">
      <img alt="Vue logo" class="logo" src="@/assets/logo.svg" width="50" height="50" />
      <v-toolbar-title>Wordle Web</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-toolbar-items>
        <v-btn @click="toggleTheme" :key="mode = theme.global.name.value" text>Toggle {{ mode }} mode</v-btn>
      </v-toolbar-items>
      <v-spacer></v-spacer>
      <v-toolbar-items>
        <v-btn to="/">Home</v-btn>
        <v-btn to="/wordle">Wordle</v-btn>
        <v-btn to="/about">About</v-btn>
      </v-toolbar-items>
    </v-toolbar>
  </header>

  <RouterView />
  </v-app>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router'
import { useTheme } from 'vuetify/lib/framework.mjs'

let mode
const theme = useTheme()
theme.global.name.value = 'dark'


const toggleTheme = () => {
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
  background-color: #141414;
  font-size: 26px;
  font-weight: bold;
  border-bottom: 3px solid #4c4c4c;
  min-height: 65px;
  color: white;
}
</style>
