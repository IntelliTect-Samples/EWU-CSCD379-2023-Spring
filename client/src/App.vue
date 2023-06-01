<template>
  <v-app>
    <v-app-bar :elevation="3">
      <template v-slot>
        <v-app-bar-title style="flex: auto">
          <RouterLink to="/"> Noted </RouterLink>
        </v-app-bar-title>
        <v-spacer />

        <v-btn icon="mdi-brightness-7" @click="switchTheme" />
        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn icon="mdi-menu" v-bind="props" />
          </template>
        </v-menu>
      </template>
    </v-app-bar>
    <v-main class="background">
      <RouterView />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'

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
