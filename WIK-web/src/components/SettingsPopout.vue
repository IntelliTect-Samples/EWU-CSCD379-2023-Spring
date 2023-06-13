<template>
  <v-btn icon>
    <v-icon>mdi-cog</v-icon>
    <v-dialog
      width="75%"
      height="75%"
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
          <v-card-title class="text-center">Select a color theme for the site:</v-card-title>

          <v-chip size="small" @click="setDarkTheme">Dark Theme</v-chip>
          <v-chip size="small" @click="setInverseTheme">Inverse Theme</v-chip>
          <v-chip size="small" @click="setKhorneTheme">Khorne Theme</v-chip>
          <v-chip size="small" @click="setCornTheme">Corn Theme</v-chip>
        </v-chip-group>
      </v-card>
    </v-dialog>
  </v-btn>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { ref } from 'vue'

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

let dialog = ref(false)
</script>
