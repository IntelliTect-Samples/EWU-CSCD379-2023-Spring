<template>
  <header>
    <v-dialog v-model="promptUsername" persistent>
      <v-card class="mx-auto" min-width="30rem">
        <v-card-title>Enter Your Username</v-card-title>
        <v-card-text>
          <v-text-field v-model="username" maxlength="20" label="Username" />
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" @click="saveUsername">Save</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <v-toolbar :elevation="7">
      <v-toolbar-title class="text-h5"> Wordle Mind Bender </v-toolbar-title>
      <v-btn-toggle class="justify-center">
        <v-btn class="text-h5" variant="plain" to="/"> Home </v-btn>
        <v-btn class="text-h5" variant="plain" to="/wordle"> Wordle </v-btn>
        <v-btn class="text-h5" variant="plain" to="/leaderboard"> Leaderboard </v-btn>
        <v-btn class="text-h5" variant="plain" @click="setInverseTheme"> Inverse Theme </v-btn>
        <v-btn class="text-h5" variant="plain" @click="setDarkTheme"> Dark Theme </v-btn>
      </v-btn-toggle>
      <v-spacer></v-spacer>
      <v-btn-toggle class="me-2">
        <v-btn class="text-h5" variant="plain" @click="promptUsername = true">
          {{ username }}
        </v-btn>
      </v-btn-toggle>
    </v-toolbar>
  </header>

  <RouterView />
</template>

<script setup lang="ts">
import { inject, ref } from 'vue'
import type { VueCookies } from 'vue-cookies'
import { useTheme } from 'vuetify/lib/framework.mjs'
const $cookies = inject<VueCookies>('$cookies')
const promptUsername = ref(false)
const username = ref('')

// Get the username from the cookies
username.value = $cookies?.get('username')
if (!username.value) {
  $cookies?.set('username', 'Guest')
  username.value = $cookies?.get('username')
  promptUsername.value = true
}

const theme = useTheme()

// Get the theme from the cookies
const themeName = $cookies?.get('theme')
if (themeName) {
  theme.global.name.value = themeName
}

function setInverseTheme() {
  theme.global.name.value = 'inverse'
  $cookies?.set('theme', 'inverse')
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
  $cookies?.set('theme', 'dark')
}

function saveUsername() {
  username.value = username.value.trim()
  if (username.value) {
    $cookies?.set('username', username.value)
    promptUsername.value = false
  }
}
</script>
