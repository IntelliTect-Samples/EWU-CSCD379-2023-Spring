<template>
  <header>
    <div class="wrapper">
      <div class="nav-bar">
        <nav>
          <RouterLink to="/">Home</RouterLink> | <RouterLink to="/wordle">Wordle</RouterLink> |
          <RouterLink to="/leaderboard">Leader Board</RouterLink>
        </nav>
      </div>
    </div>
  </header>
  <div class="theme-buttons">
    <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
    <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
  </div>

  <RouterView />
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useTheme } from 'vuetify/lib/framework.mjs'
import { useCookies } from 'vue3-cookies'

const theme = useTheme()
const { cookies } = useCookies()
const playerName = ref(cookies.get('playerName') || 'Guest')
const dialogVisible = ref(true)

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}

if (!playerName.value) {
  dialogVisible.value = true
}

function saveName() {
  cookies.set('playerName', playerName.value)
  dialogVisible.value = false
}
</script>

<style scoped>
.wrapper {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.player-name {
  cursor: pointer;
}
</style>
