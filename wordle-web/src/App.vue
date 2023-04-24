<template>
  <div :class="themeClass">
    <v-card class="mx-auto mb-12" max-width="448">
      <v-layout>
        <v-app-bar class="custom-app-bar" color="white" density="compact">
          <template v-slot:prepend>
            <RouterLink to="/">
              <Icon icon="tabler:go-game" color="#155" width="50" height="50" />
            </RouterLink>
          </template>
          <RouterLink to="/wordle">
            <h1 class="titleClass">Wordle</h1>
          </RouterLink>
          <template v-slot:append>
            <v-menu>
              <template v-slot:activator="{ props }">
                <v-btn v-bind="props">
                  <Icon icon="ph:gear-fill" color="#120" width="25" height="25" />
                </v-btn>
              </template>
              <v-list>
                <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
                <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
                <v-btn @click="setMarvelTheme"> Marvel Theme </v-btn>
                <v-btn @click="setDCTheme"> DC Theme </v-btn>
              </v-list>
            </v-menu>
            <v-menu>
              <template v-slot:activator="{ props }">
                <v-btn v-bind="props">
                  <Icon icon="charm:menu-hamburger" color="#120" width="25" height="25" />
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
  </div>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { Icon } from '@iconify/vue'
import { computed } from 'vue'
const theme = useTheme()

const themeClass = computed(() => {
  if (theme.global.name.value === 'marvel') {
    return 'marvel-theme'
  }
  if (theme.global.name.value === 'dc') {
    return 'dc-theme'
  }
  return ''
})

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}

function setDCTheme() {
  theme.global.name.value = 'dc'
}

function setMarvelTheme() {
  theme.global.name.value = 'marvel'
}
</script>
