<template>
  <v-app>
    <v-app-bar :elevation="3" v-if="route.path != '/'">
      <template v-slot>
        <v-app-bar-title>
          <RouterLink to="/">
            <v-icon icon="mdi-alpha-w-box" color="orange-darken-3" class="mr-2"></v-icon>
            <span v-if="route.path == '/wordoftheday'"> Wordle Of The Day </span>
            <span v-else> Wordle Playground </span>
          </RouterLink>
        </v-app-bar-title>
        <v-spacer></v-spacer>

        <ActiveUser></ActiveUser>

        <v-btn icon="mdi-brightness-7" @click="switchTheme" class="text-h5"></v-btn>

        <v-dialog transition="dialog-top-transition" width="auto">
          <template v-slot:activator="{ props }">
            <v-btn icon="mdi-help-circle" class="text-h5" v-bind="props"></v-btn>
          </template>
          <template v-slot:default="{ isActive }">
            <v-card>
              <v-toolbar color="primary" title="How To Play"></v-toolbar>
              <v-card-text>
                <div class="text-h5">Guess the word in 6 tries!</div>
                <div class="text-h6">Click on a letter to guess it.</div>
                <v-list lines="one">
                  <v-list-item
                    title="GREEN LETTERS"
                    subtitle="If the letter is in the word, it will turn green."
                  >
                  </v-list-item>
                  <v-list-item
                    title="ORANGE LETTERS"
                    subtitle="If the leffer is missplaced, it will turn orange."
                  >
                  </v-list-item>
                  <v-list-item
                    title="RED LETTERS"
                    subtitle="If the letter is not in the word, it will turn red."
                  >
                  </v-list-item>
                </v-list>
                <div class="text-h6">A new puzzle is released daily at midnight.</div>
              </v-card-text>
              <v-card-actions class="justify-end">
                <v-btn variant="text" @click="isActive.value = false">Close</v-btn>
              </v-card-actions>
            </v-card>
          </template>
        </v-dialog>

        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn icon="mdi-hamburger" v-bind="props" class="text-h5"></v-btn>
          </template>

          <v-list>
            <v-list-item>
              <v-list-item-title>
                <RouterLink to="/">Play Again</RouterLink>
              </v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title>
                <RouterLink to="/leaderboard">Leaderboard</RouterLink>
              </v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title>
                <RouterLink to="/dailywords">Daily Stats</RouterLink>
              </v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
      </template>
    </v-app-bar>

    <v-main class="animated-background">
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
import ActiveUser from './components/ActiveUser.vue'
import { useRoute } from 'vue-router'

let route = useRoute()

// Provide the useDisplay to other components so that it can be used in testing.
const display = reactive(useDisplay())
provide(Services.Display, display)
const playerService = new PlayerService()
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
</script>
