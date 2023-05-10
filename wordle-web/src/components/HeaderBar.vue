<template>
  <v-app-bar>
    <v-app-bar-nav-icon icon="mdi-air-horn" to="/"></v-app-bar-nav-icon>
    <RouterLink to="/wordle">
      <v-app-bar-title> Wordle </v-app-bar-title>
    </RouterLink>

    <v-spacer></v-spacer>

    <v-app-bar-nav-icon>
      <v-icon icon="mdi-cog" />
      <v-menu activator="parent">
        <v-list>
          <v-list-item @click="setDarkTheme"> Dark Theme </v-list-item>
          <v-list-item @click="setInverseTheme"> Inverse Theme </v-list-item>
        </v-list>
      </v-menu>
    </v-app-bar-nav-icon>

    <v-app-bar-nav-icon>
      <v-icon icon="$menu" />
      <v-menu activator="parent">
        <v-list>
          <v-list-item to="/leaderboard"> Leaderboard </v-list-item>
          <v-list-item to="/about"> About </v-list-item>
        </v-list>
      </v-menu>
    </v-app-bar-nav-icon>
  </v-app-bar>
  <div class="content">
    <RouterView />
  </div>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}
</script>
<style>
.content {
  margin-top: 64px;
}
</style>
