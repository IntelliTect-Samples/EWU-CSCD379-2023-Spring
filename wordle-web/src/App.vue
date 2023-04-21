<template>
  <v-app>
    <header>
      <!-- -- Old header before the implementation of the 'v-app-bar`. -- -->
      <!--    <v-toolbar id="toolbar">-->
      <!--      <img alt="Vue logo" class="logo" src="@/assets/logo.svg" width="50" height="50" />-->
      <!--      <v-toolbar-title>Wordle Web</v-toolbar-title>-->
      <!--      <v-spacer></v-spacer>-->
      <!--      <v-toolbar-items>-->
      <!--        <v-btn @click="toggleTheme" :key="mode = theme.global.name.value" text>Toggle {{ mode }} mode</v-btn>-->
      <!--      </v-toolbar-items>-->
      <!--      <v-spacer></v-spacer>-->
      <!--      <v-toolbar-items>-->
      <!--        <v-btn to="/">Home</v-btn>-->
      <!--        <v-btn to="/wordle">Wordle</v-btn>-->
      <!--        <v-btn to="/about">About</v-btn>-->
      <!--      </v-toolbar-items>-->
      <!--    </v-toolbar>-->
      <!--    <v-app-bar app color="primary" dark>-->

      <v-app-bar id="toolbar" dark>
        <img alt="Vue logo" class="logo" src="@/assets/logo.svg" width="50" height="50" />
        <v-toolbar-title>Wordle Web</v-toolbar-title>
        <!-- TODO: Size of icon needs to be modified. -->
        <v-icon @click="toggleTheme">mdi-lightbulb</v-icon>
        <v-app-bar-nav-icon></v-app-bar-nav-icon>
      </v-app-bar>
    </header>

    <!-- TODO: Maybe choose something better than '<br />' -->
    <br />
    <br />

    <!-- TODO: Main text needs to be centered. -->
    <RouterView />
  </v-app>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router'
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()
theme.global.name.value = 'dark'

function toggleTheme() {
  if (theme.global.name.value === 'light') {
    theme.global.name.value = 'dark'
  } else if (theme.global.name.value === 'dark') {
    theme.global.name.value = 'light'
  }
}
</script>

<style scoped>
#toolbar {
  width: 100%;
  padding: 6px 24px;
  font-size: 26px;
  font-weight: bold;
  border-bottom: 1px solid #656464; /* TODO: Maybe a different color? */
  min-height: 65px;
}
</style>
