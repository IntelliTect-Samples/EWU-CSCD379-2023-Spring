<template>
  <v-card>
    <nav>
      <v-layout>
        <v-toolbar prominent>
          <RouterLink to="/"><icon /></RouterLink>
          <v-toolbar-title><RouterLink to="/">Wordle</RouterLink></v-toolbar-title>
          <v-btn @click="showDialog = !showDialog"><settingsIcon /></v-btn>
          <v-app-bar-nav-icon
            variant="text"
            @click.stop="showDrawer = !showDrawer"
          ></v-app-bar-nav-icon>
        </v-toolbar>
      </v-layout>
    </nav>
    <p><RouterView /></p>

    <v-navigation-drawer v-model="showDrawer" location="right" temporary elevation="24">
      <v-list nav dense>
        <v-list-item>
          <RouterLink to="/">Home</RouterLink>
        </v-list-item>
        <v-list-item>
          <RouterLink to="/wordle">Wordle</RouterLink>
        </v-list-item>
        <v-list-item>
          <RouterLink to="/about">About</RouterLink>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <template>
      <v-dialog v-model="showDialog">
        <v-card>
          <v-card-title> Settings: </v-card-title>
          <v-btn @click="setLightTheme"> Light Theme (for psychopaths) </v-btn>
          <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
          <v-btn @click="setBlandTheme"> Bland </v-btn>
          <v-btn @click="setBlueTheme"> Blue Theme </v-btn>
          <v-btn @click="showDialog = !showDialog">Close Settings</v-btn>
        </v-card>
      </v-dialog>
    </template>
  </v-card>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { ref } from 'vue'
import icon from './icons/CustomIcon.vue'
import settingsIcon from './icons/SettingsIcon.vue'

let showDrawer = ref(false)
let showDialog = ref(false)
const theme = useTheme()

function setLightTheme() {
  theme.global.name.value = 'light'
}

function setBlandTheme() {
  theme.global.name.value = 'bland'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}

function setBlueTheme() {
  theme.global.name.value = 'blue'
}
</script>
