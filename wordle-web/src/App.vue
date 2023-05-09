<template>
  <header>
    <v-dialog v-model="promptUsername" :persistent="persistentPrompt">
      <v-card>
        <v-card-title>Enter Your Username</v-card-title>
        <v-card-text>
          <v-text-field v-model="username" label="Username" />
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" @click="saveUsername">Save</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <div class="wrapper">
      <v-card class="rounded-0">
        <v-toolbar flat>
          <v-toolbar-title>Wordle Mind Bender</v-toolbar-title>
          <v-btn variant="plain" to="/"> Home </v-btn>
          <v-btn variant="plain" to="/wordle"> Wordle </v-btn>
          <v-btn variant="plain" to="/leaderboard"> Leaderboard </v-btn>
          <v-btn variant="plain" @click="setInverseTheme"> Inverse Theme </v-btn>
          <v-btn variant="plain" @click="setDarkTheme"> Dark Theme </v-btn>
          <v-spacer></v-spacer>
          <v-btn-toggle>
            <v-btn variant="plain" @click="promptUsername = true"> {{ username }} </v-btn>
          </v-btn-toggle>
        </v-toolbar>
      </v-card>
    </div>
  </header>

  <RouterView />
</template>

<script setup lang="ts">
import { inject, ref } from 'vue'
import type { VueCookies } from 'vue-cookies'
import { useTheme } from 'vuetify/lib/framework.mjs'
const $cookies = inject<VueCookies>('$cookies')
const promptUsername = ref(false)
const persistentPrompt = ref(false)
const username = ref('')

// Get the username from the cookies
username.value = $cookies?.get('username')
if (!username.value) {
  $cookies?.set('username', 'Guest')
  username.value = $cookies?.get('username')
  persistentPrompt.value = true
  promptUsername.value = true
}

const theme = useTheme()

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}

function saveUsername() {
  if (username.value) {
    $cookies?.set('username', username.value)
    promptUsername.value = false
    persistentPrompt.value = false
  }
}
</script>
