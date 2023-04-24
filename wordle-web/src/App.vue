<template>
  <header>
    <div class="wrapper">
      <v-layout>
        <v-app-bar class="custom-app-bar" color="primary" density="compact">
          <template v-slot:prepend>

            <RouterLink to="/">
              <h1 class="titleClass">Wordle Web</h1>
            </RouterLink>
            <RouterLink to="/">
              <v-icon color="hsla(160, 100%, 37%, 1)" icon="mdi-alpha-w-box" size="large" />
            </RouterLink>


            <v-list-item>
              <RouterLink to="/about">About</RouterLink>
            </v-list-item>
            <v-list-item>
              <RouterLink to="/wordle">Game</RouterLink>
            </v-list-item>
            <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
            <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
            <v-btn @click="setKhorneTheme"> Khorne Theme </v-btn>
            <v-btn @click="setCornTheme"> Corn Theme </v-btn>
          </template>

        </v-app-bar>
      </v-layout>
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
function setKhorneTheme() {
  theme.global.name.value = 'khorne'
}
function setCornTheme() {
  theme.global.name.value = 'corn'
}

</script>
