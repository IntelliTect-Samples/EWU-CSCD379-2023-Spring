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
        <v-card-item class="justify-end">
          <v-btn icon dark @click="dialog = false">
            <v-icon>mdi-close</v-icon>
          </v-btn>
        </v-card-item>
        <v-card-title class="text-center">Settings</v-card-title>

        <v-chip-group outlined class="justify-center ma-10 pa-10">
          <v-card-title class="text-center">Light/Dark</v-card-title>
          <v-switch
            v-model="lightDarkToggle"
            @click="setLightDark(lightDarkToggle)"
            hide-details
            inset
          ></v-switch>

          <v-card-title class="text-center">Theme</v-card-title>

          <v-chip size="small" @click="setCalmTheme(lightDarkToggle)">Calm Mode</v-chip>
          <v-chip size="small" @click="setColorfulTheme(lightDarkToggle)">Colorful Mode</v-chip>
        </v-chip-group>
      </v-card>
    </v-dialog>
  </v-btn>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { ref } from 'vue'

const theme = useTheme()

function setLightDark(lightOrDark: boolean) {
  if (lightOrDark == true) {
    theme.global.name.value = 'inverse'
  } else {
    theme.global.name.value = 'dark'
  }
}

function setCalmTheme(lightOrDark: boolean) {
  if (lightOrDark == true) {
    theme.global.name.value = 'darkCalm'
  } else {
    theme.global.name.value = 'calm'
  }
}

function setColorfulTheme(lightOrDark: boolean) {
  if (lightOrDark == true) {
    theme.global.name.value = 'darkColorful'
  } else {
    theme.global.name.value = 'colorful'
  }
}

let dialog = ref(false)
let lightDarkToggle = ref(true)
</script>
