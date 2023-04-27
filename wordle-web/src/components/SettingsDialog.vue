<template>
  <v-btn icon>
    <v-icon>mdi-cog</v-icon>
    <v-dialog width="300px" height="200px" v-model="dialog" activator="parent">
      <v-card width="100%" height="100%">
        <v-card-item class="justify-end">
          <v-btn icon dark variant="text" @click="dialog = false">
            <v-icon>mdi-close</v-icon>
          </v-btn>
        </v-card-item>
        <v-card-title class="text-center">Theme Settings</v-card-title>
        <v-card-text>
          <v-row justify="center">
            <v-chip-group>
              <v-chip @click="setLight"><v-icon icon="mdi-weather-sunny" /></v-chip>
              <v-chip @click="setDark"><v-icon icon="mdi-moon-waxing-crescent" /></v-chip>
              <v-chip @click="setChristmas"><v-icon icon="mdi-pine-tree" /></v-chip>
              <v-chip @click="setHalloween"><v-icon icon="mdi-halloween" /></v-chip>
            </v-chip-group>
          </v-row>
        </v-card-text>
      </v-card>
    </v-dialog>
  </v-btn>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { ref } from 'vue'

let dialog = ref(false)
const theme = useTheme()

const setLight = () => {
  theme.global.name.value = 'light'
}

const setDark = () => {
  theme.global.name.value = 'dark'
}

const setChristmas = () => {
  theme.global.name.value = 'christmas'
}

const setHalloween = () => {
  theme.global.name.value = 'halloween'
}
</script>
