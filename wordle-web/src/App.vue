<template>
  <header>
    <div class="wrapper">
      <div class="nav-bar">
        <nav>
          <RouterLink to="/">Home</RouterLink> | <RouterLink to="/wordle">Wordle</RouterLink> |
          <RouterLink to="/leaderboard">Leader Board</RouterLink>
        </nav>
      </div>
      <div class="player-name" @click="dialogVisible = true">{{ playerName }}</div>
    </div>
  </header>
  <div class="theme-buttons">
    <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
    <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
  </div>

  <RouterView :playerName="playerName" />

  <div class="text-center">
    <v-dialog v-model="dialogVisible" persistent width="auto">
      <v-card>
        <v-card-title class="headline">Enter your name</v-card-title>
        <v-card-text>
          <v-text-field
            label="Player name"
            v-model="playerName"
            @keyup.enter="dialogVisible = false"
          />
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="primary" block @click="saveName">Save</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
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
