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
            <v-card-title class="text-center">Theme</v-card-title>
  
            <v-chip variant="outlined" ripple  size="small" @click="setDarkTheme">Dark Mode</v-chip>
            <v-chip variant="outlined" ripple size="small" @click="setInverseTheme">Inverse Mode</v-chip>
            <v-chip variant="outlined" ripple size="small" @click="setRainbowTheme">Rainbow Mode</v-chip>
            <v-chip variant="outlined" ripple size="small" @click="setZenTheme">Zen Mode</v-chip>
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
  function setRainbowTheme(){
    theme.global.name.value = 'rainbow'
  }
  function setZenTheme(){
    theme.global.name.value = 'zen'
  }
  let dialog = ref(false)
</script>