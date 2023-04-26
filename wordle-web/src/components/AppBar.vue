<template>
  <v-card class="mx-auto">
    <v-layout>
      <v-app-bar density="compact">
        <template v-slot:prepend>
          <div class="d-flex justify-center align-center">
            <v-app-bar-title class="text-center m2-auto" @click.stop="$router.push('/')">Wordle</v-app-bar-title>
            <v-icon icon="mdi-head-cog" @click.stop="$router.push('/')" size="x-large"></v-icon>
          </div>
        </template>
        <template v-slot:append>
          <v-btn icon="mdi-menu" @click.stop="hamburgerDrawer = !hamburgerDrawer"> </v-btn>
          <v-btn icon="mdi-cog" @click="dialog = !dialog"> </v-btn>
        </template>
      </v-app-bar>
      <v-navigation-drawer
        v-model="hamburgerDrawer"
        location="right"
        temporary
      >
        <v-btn size="x-large" width="100%" prepend-icon="mdi-home" @click="$router.push('/')">
          Home
        </v-btn>
        <v-btn size="x-large" width="100%" prepend-icon="mdi-gamepad-variant" @click="$router.push('/wordle')">
          Wordle
        </v-btn>
        <v-btn size="x-large" width="100%" prepend-icon="mdi-information" @click="$router.push('/about')">
          About
        </v-btn>
      </v-navigation-drawer>

      <v-dialog   
      v-model="dialog"
      activator="#select"
      transition="dialog-bottom-transition"
      width="auto"  
      >
        <v-card class="justify-center text-center" width ='400px' height="300px">
          Choose a theme!
          <v-btn class="mb-2" @click="setTheme('light')"> Light normal Theme </v-btn>
          <v-btn class="mb-2" @click="setTheme('dark')"> Dark normal Theme </v-btn>
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
let isDark = true

function setTheme(themeName: string) {
  if(themeName === 'light') {
    isDark = false
  } else if (themeName === 'dark') {
    isDark = true
  }
  if(isDark === false && themeName != 'light') {
    theme.global.name.value = themeName + 'AndLight'
  } else {
    theme.global.name.value = themeName
  }
  dialog.value = false
}

</script>
