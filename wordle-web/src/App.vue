<template>
  <header>
    <div class="wrapper">
      <v-layout>
        <v-app-bar class="custom-app-bar" color="black" density="compact">
          <template v-slot:prepend>
            <RouterLink to="/wordle">
              <h1 class="titleClass">Wordle Web</h1>
            </RouterLink>


            <v-list-item>
              <RouterLink to="/about">About</RouterLink>
            </v-list-item>

            <RouterLink to="/">
              <v-icon color="hsla(160, 100%, 37%, 1)" icon="mdi-alpha-w-box" size="large" />
            </RouterLink>

            <v-navigation-drawer color="white"
            >hi
              <v-list-item>
                <RouterLink to="/about">About</RouterLink>
              </v-list-item>
              <v-list-item>
                <RouterLink to="/wordle">Game</RouterLink>
              </v-list-item>
            </v-navigation-drawer>
          </template>

        </v-app-bar>
      </v-layout>
      <nav>
        <RouterLink to="/">Home</RouterLink> | <RouterLink to="/wordle">Wordle</RouterLink> |
        <RouterLink to="/about">About</RouterLink>
      </nav>
      <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
      <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
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
