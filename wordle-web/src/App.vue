<template>
  <v-dialog v-model="promptUsername" persistent>
      <v-card class="mx-auto" min-width="30rem">
        <v-card-title>Enter Your Username</v-card-title>
        <v-card-text>
          <v-text-field v-model="username" maxlength="20" label="Username"/>
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" @click="saveUsername">Save</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

  <v-app>
    <v-app-bar :elevation="3">
      <template v-slot>
        <v-app-bar-title>
          <RouterLink to="/game">
            <v-icon icon="mdi-alpha-w-box" color="orange-darken-3"></v-icon>
            <span class="wurdleFont">Wurdle</span>
          </RouterLink>
        </v-app-bar-title>
        <v-spacer></v-spacer>
        <v-btn-toggle class="me-2">
        <v-btn class="text-h5" variant="plain" @click="promptUsername = true">
          {{ username }}
        </v-btn>

      </v-btn-toggle>
      <RouterLink to="/leaderboard">
            <v-btn icon="mdi-podium-gold" color="orange-darken-3"></v-btn>
      </RouterLink>
       

      <RouterLink to="/game">
            <v-btn icon="mdi-controller-classic-outline" color="orange-darken-3"></v-btn>
      </RouterLink>
      
      <RouterLink to="/help">
            <v-btn icon="mdi-help-box" color="orange-darken-3"></v-btn>
      </RouterLink>

        <v-btn icon="mdi-brightness-7" color="orange-darken-3" @click="switchTheme" ></v-btn>

        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn icon="mdi-hamburger" v-bind="props" color="orange-darken-3"></v-btn>
          </template>

          <v-list>
            <v-list-item>
              <v-list-item-title><RouterLink to="/game">Wurdle play ground</RouterLink></v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title><RouterLink to="/wordOfTheDay">Wurdle Of The Day</RouterLink></v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title><RouterLink to="/about">About</RouterLink></v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title><RouterLink to="/">Home</RouterLink></v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
      </template>
    </v-app-bar>
    <v-main>
      <FallingLetters />
      <RouterView />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import FallingLetters from "@/components/FallingLetters.vue";
import { inject, ref } from 'vue'
import type { VueCookies } from 'vue-cookies'
import { useTheme } from 'vuetify/lib/framework.mjs'
import { reactive } from 'vue'
import { useDisplay } from 'vuetify'
import { provide } from 'vue'

// Provide the useDisplay to other components so that it can be used in testing.
const $cookies = inject<VueCookies>('$cookies')
const promptUsername = ref(false)
const username = ref('')
// Get the username from the cookies
username.value = $cookies?.get('username')
if (!username.value) {
  $cookies?.set('username', 'Guest')
  username.value = $cookies?.get('username')
  promptUsername.value = true
}
const display = reactive(useDisplay())
provide('display', display)

const theme = useTheme()
// Get the theme from the cookies
const themeName = $cookies?.get('theme')
if (themeName) {
  theme.global.name.value = themeName
}
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
  $cookies?.set('theme', 'inverse')
}

function saveUsername() {
  username.value = username.value.trim()
  if (username.value) {
    $cookies?.set('username', username.value)
    promptUsername.value = false
  }
}
</script>
