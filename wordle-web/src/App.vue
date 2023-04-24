<template>
  <header>
    <div class="wrapper">
      <nav>
        <v-layout>
          <v-app-bar>
            <v-app-bar-nav-icon icon="mdi-air-horn" to="/wordle"></v-app-bar-nav-icon>
            <RouterLink to="/wordle">
              <v-app-bar-title> Wordle </v-app-bar-title>
            </RouterLink>

            <v-spacer></v-spacer>

            <v-app-bar-nav-icon>
              <v-icon icon="$menu" />
              <v-menu activator="parent">
                <v-list>
                  <v-list-item to="/about"> About </v-list-item>
                </v-list>
              </v-menu>
            </v-app-bar-nav-icon>

            <v-app-bar-nav-icon>
              <v-icon icon="mdi-cog" />
              <v-menu activator="parent">
                <v-list>
                  <v-list-item @click="setDarkOrLightTheme"> Dark/Light </v-list-item>
                  <v-list-item @click="setInverseTheme"> Inverse Theme </v-list-item>
                  <v-list-item @click="setMinecraftTheme"> Minecraft Theme </v-list-item>
                  <v-list-item @click="setPirateTheme"> Pirate Theme </v-list-item>
                </v-list>
              </v-menu>
            </v-app-bar-nav-icon>
          </v-app-bar>
        </v-layout>
      </nav>
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

function setDarkOrLightTheme() {
  if (theme.global.name.value == 'dark') {
    theme.global.name.value = 'light'
  } else {
    theme.global.name.value = 'dark'
  }
}

function setMinecraftTheme() {
  theme.global.name.value = 'minecraft'
}

function setPirateTheme() {
  theme.global.name.value = 'pirate'
}
</script>
