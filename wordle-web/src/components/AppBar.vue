<template>
  <v-card class="mx-auto">
    <v-layout>
      <v-app-bar density="compact">
        <template v-slot:prepend>
          <div class="d-flex justify-center align-center">
            <v-icon icon="mdi-head-cog" @click.stop="$router.push('/')" size="x-large"></v-icon>
            <v-app-bar-title> <RouterLink to="/"> YAWC </RouterLink> </v-app-bar-title>
          </div>
        </template>
        <template v-slot:append>
          <v-btn icon="mdi-menu" @click.stop="hamburgerDrawer = !hamburgerDrawer"> </v-btn>
          <v-btn icon="mdi-cog" @click="dialog = !dialog"> </v-btn>
        </template>
      </v-app-bar>
      <v-navigation-drawer v-model="hamburgerDrawer" location="right" temporary>
        <v-btn size="x-large" width="100%" prepend-icon="mdi-home" @click="$router.push('/')">
          Home
        </v-btn>
        <v-btn
          size="x-large"
          width="100%"
          prepend-icon="mdi-gamepad-variant"
          @click="$router.push('/wordle')"
        >
          Wordle
        </v-btn>
        <v-btn
          size="x-large"
          width="100%"
          prepend-icon="mdi-information"
          @click="$router.push('/about')"
        >
          About
        </v-btn>
      </v-navigation-drawer>

      <v-dialog
        v-model="dialog"
        activator="#select"
        transition="dialog-bottom-transition"
        width="auto"
      >
        <v-card class="justify-center text-center" width="400px" height="320px">
          <v-card-title>Theme Mode</v-card-title>
          <v-btn class="mb-2" @click="setTheme('light')"> Light Mode </v-btn>
          <v-btn class="mb-2" @click="setTheme('dark')"> Dark Mode </v-btn>
          <v-card-title>Theme Selection</v-card-title>
          <v-btn class="mb-2" @click="setTheme('default')"> Default Theme </v-btn>
          <v-btn class="mb-2" @click="setTheme('neon')"> Neon Theme </v-btn>
          <v-btn class="mb-2" @click="setTheme('pastel')"> Pastel Theme </v-btn>
        </v-card>
      </v-dialog>
      <v-main> </v-main>
    </v-layout>
  </v-card>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()
const dialog = ref(false)
const hamburgerDrawer = ref(false)
let currentTheme = 'default'

function setTheme(themeName: string) {
  /*   switch (themeName) {
    case 'light':
      isDark = false
      break
    case 'dark':
      isDark = true
      break
    case 'neon':
      if (isDark) theme.global.name.value = themeName + 'Dark'
      else theme.global.name.value = themeName + 'Light'
      break
    case 'pastel':
      if (isDark) theme.global.name.value = themeName + 'Dark'
      else theme.global.name.value = themeName + 'Light'
      break
  } */
  switch (themeName) {
    case 'light':
      theme.global.name.value = currentTheme + 'Light'
      break
    case 'dark':
      theme.global.name.value = currentTheme + 'Dark'
      break
    default:
      if (theme.global.current.value.dark === true) theme.global.name.value = themeName + 'Dark'
      else theme.global.name.value = themeName + 'Light'
      currentTheme = themeName
      break
  }
  dialog.value = false
  /*   if (themeName === 'light') {
    isDark = false
  } else if (themeName === 'dark') {
    isDark = true
  }
  if (isDark === false && themeName != 'light') {
    theme.global.name.value = themeName + 'AndLight'
  } else {
    theme.global.name.value = themeName
  }
  dialog.value = false */
}

function themeDefaultLight() {}
</script>
