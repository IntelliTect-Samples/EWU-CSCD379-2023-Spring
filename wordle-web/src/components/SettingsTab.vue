<template>
  <v-btn icon>
    <v-icon>mdi-cog</v-icon>
    <v-dialog
      width="70%"
      height="50%"
      v-model="dialog"
      activator="parent"
      transition="dialog-top-transition"
    >
      <v-card width="100%" height="100%">
        <v-card-title class="text-center">Settings</v-card-title>

        <v-card-title class="text-center">Theme</v-card-title>
        <v-chip-group class="justify-center ma-10 pa-10">
          <v-chip @click="setDarkTheme">Dark Mode</v-chip>

          <v-chip @click="setInverseTheme">Inverse Mode</v-chip>
        </v-chip-group>

        <v-card-title class="text-center">Volume</v-card-title>

        <v-slider v-model="volume" step="10" show-ticks prepend-icon="mdi-volume-high"></v-slider>

        <v-btn color="primary" @click="dialog = false">Close Dialog</v-btn>
      </v-card>
    </v-dialog>
  </v-btn>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { ref } from 'vue'

const theme = useTheme()
const volume = ref(10)

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}

// function setVolume() {
//   for(const audio in document.getElementsByTagName('audio')) {
//     audio.volume = volume
//   }
//   console.log(volume)
// }

let dialog = ref(false)
</script>
