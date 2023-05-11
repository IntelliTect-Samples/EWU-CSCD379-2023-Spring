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
            <v-btn icon="mdi-hamburger" v-bind="props"></v-btn>
          </template>

          <v-list>
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
  </v-app>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { reactive } from 'vue'
import { useDisplay } from 'vuetify'
import { provide } from 'vue'

// Provide the useDisplay to other components so that it can be used in testing.
const display = reactive(useDisplay())
provide('display', display)

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
