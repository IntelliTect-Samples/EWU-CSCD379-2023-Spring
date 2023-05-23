<template>
  <v-row justify="center">
    <v-dialog :scrim="false" transition="dialog-bottom-transition">
      <template v-slot:activator="{ props }">
        <v-btn dark v-bind="props">
          <v-icon>mdi-cog</v-icon>
        </v-btn>
      </template>
      <v-card>
        <!-- HEADER BAR-->
        <v-toolbar dark>
          <v-toolbar-title>Settings</v-toolbar-title>
          <v-spacer></v-spacer>
        </v-toolbar>

        <v-divider></v-divider>
        <!-- Body-->
        <v-btn @click="toggleWinter()">Winter Theme</v-btn>
        <v-btn @click="toggleSpace()">Space Theme</v-btn>
        <v-btn @click="toggleShallowOcean()">Ocean Day</v-btn>
        <v-btn @click="toggleDeepOcean()">Deep Ocean</v-btn>
        <v-btn @click="toggleForestDay()">Bright Forest</v-btn>
        <v-btn @click="toggleForestNight()">Forest at Night</v-btn>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify'

const root = document.documentElement
const theme = useTheme()

function toggleWinter() {
  theme.global.name.value = 'inverse'
  root.style.setProperty(
    '--background-image',
    `url(https://img.freepik.com/free-vector/unfocused-winter-landscape-with-snowflakes_1393-210.jpg)`
  )
}
function toggleSpace() {
  theme.global.name.value = 'dark'
  root.style.setProperty(
    '--background-image',
    'url(https://c4.wallpaperflare.com/wallpaper/582/155/806/space-space-art-nebula-stars-wallpaper-preview.jpg)'
  )
}

function toggleShallowOcean() {
  theme.global.name.value = 'oceanlight'
  root.style.setProperty(
    '--background-image',
    'url(https://img.freepik.com/premium-vector/underwater-ocean-sandy-bottom-sunrays_87720-3706.jpg?size=626&ext=jpg)'
  )
}

function toggleDeepOcean() {
  theme.global.name.value = 'oceandark'
  root.style.setProperty(
    '--background-image',
    'url(https://img.freepik.com/free-photo/lovely-blue-paint-water_23-2147798302.jpg)'
  )
}
function toggleForestDay() {
  theme.global.name.value = 'forestlight'
  root.style.setProperty(
    '--background-image',
    'url(https://img.freepik.com/premium-vector/autumn-forest-landscape-with-grass-land-mid-autumn-fall-season-panoramic-illustration_288411-1838.jpg'
  )
}
function toggleForestNight() {
  theme.global.name.value = 'forestdark'
  root.style.setProperty(
    '--background-image',
    'url(https://img.freepik.com/free-vector/watercolor-enchanted-forest-illustration_52683-84111.jpg)'
  )
}
</script>

<style>
.dialog-bottom-transition-enter-active,
.dialog-bottom-transition-leave-active {
  transition: transform 0.2s ease-in-out;
}
</style>
