<template>
  
  <v-app>
    <v-parallax src="https://cdn.vuetifyjs.com/images/parallax/material.jpg">
    <v-app-bar :elevation="3" color="yellow-lighten-1">
      <template v-slot>
        <v-app-bar-title>
          <RouterLink to="/wordoftheday">
            <v-icon icon="mdi-alpha-w-box" color="cyan"></v-icon>
            Daily Word
          </RouterLink>
        </v-app-bar-title>
        <v-spacer></v-spacer>

        <v-btn icon="mdi-brightness-7" color="cyan" @click="switchTheme"></v-btn>

        <ActiveUser></ActiveUser>

        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn icon="mdi-hamburger" color="cyan" v-bind="props"></v-btn>
          </template>

          <v-list>
            <v-list-item>
              <v-list-item-title>
                <RouterLink to="/wordoftheday">Word of the day</RouterLink>
              </v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title>
                <RouterLink to="/">Practice mode</RouterLink>
              </v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title>
                <RouterLink to="/leaderboard">Leaderboard</RouterLink>
              </v-list-item-title>
            </v-list-item>
            <v-list-item>
                <RouterLink to="/instructions">Instructions</RouterLink>
            </v-list-item>
            <v-list-item>
              <v-list-item-title><RouterLink to="/stats">Statistics</RouterLink></v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title><RouterLink to="/about">About</RouterLink></v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
      </template>
    </v-app-bar>

    <v-main>
      <RouterView />
    </v-main>
  </v-parallax>
  </v-app>
  
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { reactive } from 'vue'
import { useDisplay } from 'vuetify'
import { provide } from 'vue'
import { PlayerService } from './scripts/playerService'
import { Services } from './scripts/services'
import { ref } from 'vue'
import ActiveUser from './components/ActiveUser.vue'

// Provide the useDisplay to other components so that it can be used in testing.
const display = reactive(useDisplay())
provide(Services.Display, display)
const playerService = new PlayerService()
playerService.setupPlayerAsync()
provide(Services.PlayerService, playerService)
const gameGuide = ref(true)

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
</script>
