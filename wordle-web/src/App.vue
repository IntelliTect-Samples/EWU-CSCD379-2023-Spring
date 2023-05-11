<template>
  <v-app>
    <v-app-bar :elevation="3">
      <template v-slot>
        <v-app-bar-title>
          <RouterLink to="/">
            <v-icon icon="mdi-alpha-w-box" color="orange-darken-3"></v-icon>
            Wordle
          </RouterLink>
        </v-app-bar-title>
        <v-spacer></v-spacer>

        <v-btn icon="mdi-brightness-7" @click="switchTheme"></v-btn>

        <v-menu>
          <template v-slot:activator="{ props }">
            {{ playerService.player.name }}
            <v-btn icon="mdi-hamburger" v-bind="props"></v-btn>
          </template>

          <v-list>
            <v-list-item>
              <v-list-item-title><RouterLink to="/about">About</RouterLink></v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>

        <v-dialog v-model="dialog" persistent width="auto">
          <template v-slot:activator="{ props }">
            <v-btn color="primary" v-bind="props">WHAT THE FUCK</v-btn>
          </template>
          <v-card>
            <v-card-title class="text-h5">HELLLOOOOO</v-card-title>
              <v-card-text>Fuck off and fuck this</v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="green-darken-1" variant="text" @click="dialog = false">FUCK THIS</v-btn>
              <v-btn color="green-darken-1" variant="text" @click="dialog = false">FUCK THAT</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </template>
    </v-app-bar>
    <v-main>
      <RouterView />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { reactive } from 'vue'
import { useDisplay } from 'vuetify'
import { provide } from 'vue'
import { PlayerService } from './scripts/playerService'
import { Services } from './scripts/services'

// Provide the useDisplay to other components so that it can be used in testing.
const display = reactive(useDisplay())
provide(Services.Display, display)
const playerService = reactive(new PlayerService())
playerService.setupPlayerAsync()
provide(Services.PlayerService, playerService)

const theme = useTheme()

function switchTheme() {
  if (theme.global.name.value === 'light') {
    setDarkTheme()
  } else {
    setLightTheme()
  }
}

function setLightTheme() {
  theme.global.name.value = 'light'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}

var dialog = true
</script>
