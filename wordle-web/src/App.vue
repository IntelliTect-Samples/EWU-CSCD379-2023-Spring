<template>
  <v-app>
    <span class="bg"></span>
    <v-app-bar :elevation="3">
      <template v-slot>
        <v-app-bar-title>
          <RouterLink to="/">
            <v-icon icon="mdi-alpha-w-box" color="orange-darken-3"></v-icon>
            Wordle
          </RouterLink>
        </v-app-bar-title>
        <v-spacer></v-spacer>

        <v-btn>
          <span v-if="!signInService.isSignedIn">Not signed in</span>
          <span v-else>{{ signInService.token.userName }}</span>
        </v-btn>

        <v-btn icon="mdi-brightness-7" @click="switchTheme"></v-btn>
        <ActiveUser></ActiveUser>

        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn icon="mdi-hamburger" v-bind="props"></v-btn>
          </template>

          <v-list width="200">
            <v-list-item>
              <v-list-item-title>
                <RouterLink :to="{ name: 'wordOfTheDay' }"> Play Word of the Day </RouterLink>
              </v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title>
                <RouterLink :to="{ name: 'wordle' }"> Play Random Word </RouterLink>
              </v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title>
                <RouterLink :to="{ name: 'leaderboard' }"> Leaderboard </RouterLink>
              </v-list-item-title>
            </v-list-item>
            <v-list-item v-if="signInService.isSignedIn">
              <v-list-item-title>
                <RouterLink :to="{ name: 'about' }"> About </RouterLink>
              </v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title v-if="signInService.isSignedIn" @click="signInService.signOut()">
                Sign Out
              </v-list-item-title>
              <v-list-item-title
                v-if="!signInService.isSignedIn"
                @click="signInService.signIn('admin@intellitect.com', 'P@ssw0rd123')"
              >
                Sign In
              </v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
      </template>
    </v-app-bar>

    <v-main>
      <RouterView />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { inject, reactive } from 'vue'
import { useDisplay } from 'vuetify'
import { provide } from 'vue'
import { Services } from './scripts/services'
import ActiveUser from './components/ActiveUser.vue'
import type { SignInService } from './scripts/signInService'

// Provide the useDisplay to other components so that it can be used in testing.
const display = reactive(useDisplay())
provide(Services.Display, display)

const signInService = inject(Services.SignInService) as SignInService

const theme = useTheme()

function switchTheme() {
  if (theme.global.name.value === 'light') {
    setDarkTheme()
  } else {
    setLightTheme()
  }
}

function setLightTheme() {
  theme.global.name.value = 'light'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}

setTimeout(() => {
  // This is terrible, nasty, and should be removed.
  signInService.signIn('admin@intellitect.com', 'P@ssw0rd123')
}, 1000)
</script>
