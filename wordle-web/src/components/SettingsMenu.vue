<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()

function setDarkTheme() {
  theme.global.name.value = 'dark'
}

function setLightTheme() {
  theme.global.name.value = 'light'
}

function setSunsetTheme() {
  theme.global.name.value = 'sunset'
}

function setOceanTheme() {
  theme.global.name.value = 'ocean'
}
</script>

<template>
  <v-dialog transition="dialog-bottom-transition" width="auto">
    <template v-slot:activator="{ props }">
      <v-btn v-bind="props" icon>
        <v-icon size="25px" icon="mdi:mdi-cog" />
      </v-btn>
    </template>
    <template v-slot:default="{ isActive }">
      <v-card width="500px" height="350px">
        <v-toolbar color="primary">
          <v-toolbar-title class="flex text-center">
            <span class="text-h4"> Settings </span>
          </v-toolbar-title>
        </v-toolbar>
        <v-card-text>
          <V-text class="text-h5"> Theme: </V-text> <br /><br />

          <v-btn variant="tonal" color="#9575CD" @click="setDarkTheme">Dark</v-btn> &nbsp;
          <v-btn variant="tonal" color="#4CAF50" @click="setLightTheme">Light</v-btn> &nbsp;
          <v-btn variant="tonal" color="#FF781E" @click="setSunsetTheme">Sunset</v-btn>&nbsp;
          <v-btn variant="tonal" color="#3079CC" @click="setOceanTheme">Ocean</v-btn>
        </v-card-text>
        <v-card-actions>
          <v-btn variant="text" density="compact" elevation="4" text size="x-large" @click="isActive.value = false">Close</v-btn>
        </v-card-actions>
      </v-card>
    </template>
  </v-dialog>
</template>
