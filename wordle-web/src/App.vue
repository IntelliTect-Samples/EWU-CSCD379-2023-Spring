<template>
  <v-card class="mx-auto mb-12" max-width="448">
    <v-layout>
      <v-app-bar color="white" density="compact">
        <template v-slot:prepend>
          <RouterLink to="/">
            <Icon icon="tabler:go-game" color="#155" width="50" height="50" />
          </RouterLink>
          <RouterLink to="/">
            <v-app-bar-title>Wordle Game</v-app-bar-title>
          </RouterLink>

          <nav></nav>
        </template>

        <template v-slot:append>
          <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
          <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
          <v-menu>
            <template v-slot:activator="{ props }">
              <v-btn v-bind="props">
                <Icon icon="charm:menu-hamburger" color="#155" width="30" height="30" />
              </v-btn>
            </template>
            <v-list>
              <v-list-item>
                <RouterLink to="/">Home</RouterLink>
              </v-list-item>
              <v-list-item>
                <RouterLink to="/about">About</RouterLink>
              </v-list-item>
              <v-list-item>
                <RouterLink to="/wordle">Game</RouterLink>
              </v-list-item>
            </v-list>
          </v-menu>
        </template>
      </v-app-bar>
    </v-layout>
  </v-card>

  <RouterView />
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { Icon } from '@iconify/vue'
const items = [{ title: 'About' }, { title: 'Wordle Game' }]

const theme = useTheme()

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}
</script>
