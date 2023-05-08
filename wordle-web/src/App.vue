<template>
  <header>
    <div class="wrapper">
      <v-card>
        <v-tool-bar>
          <v-btn variant="plain" to="/"> Home </v-btn>
          <v-btn variant="plain" to="/wordle"> Wordle </v-btn>
          <v-btn variant="plain" to="/leaderboard"> Leader Board </v-btn>
          <v-btn variant="plain" @click="setInverseTheme"> Inverse Theme </v-btn>
          <v-btn variant="plain" @click="setDarkTheme"> Dark Theme </v-btn>
        </v-tool-bar>
      </v-card>
    </div>
  </header>

  <RouterView />
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
