<template>
  <v-card>
    <v-layout>
      <v-app-bar>
        <template v-slot:image> </template>
        <template v-slot:prepend>
          <router-link to="/"
            ><v-app-bar-nav-icon icon="mdi-vuejs"></v-app-bar-nav-icon
          ></router-link>
          <router-link to="/"
            ><v-app-bar-title class="primary" color="primary"> wordle</v-app-bar-title></router-link
          >
        </template>
        <v-spacer></v-spacer>

        <v-btn>{{ signInService.token.userName }}</v-btn>

        <v-btn>
          <SettingsDialogVue />
        </v-btn>

        <template v-slot:append>
          <v-menu>
            <template v-slot:activator="{ props }">
              <v-btn v-bind="props" icon="mdi-hamburger"> </v-btn>
            </template>

            <v-list>
              <router-link to="/wordle"><v-list-item-title>Play</v-list-item-title></router-link>
              <router-link to="/wordoftheday"
                ><v-list-item-title>Wordle of Day</v-list-item-title></router-link
              >
              <router-link to="/leaderBoard"
                ><v-list-item-title>Leader Board</v-list-item-title></router-link
              >
              <router-link to="/days"
                ><v-list-item-title>Last Ten Days</v-list-item-title></router-link
              >
              <router-link to="/about"
                ><v-list-item-title>About Page</v-list-item-title></router-link
              >
              <router-link to="/description"
                ><v-list-item-title>How To Play</v-list-item-title></router-link
              >
              <router-link to="/index"
                ><v-list-item-title>Dictionary</v-list-item-title></router-link
              >
              <router-link to="/signIn"><v-list-item-title>signIn</v-list-item-title></router-link>
            </v-list>
          </v-menu>
        </template>
      </v-app-bar>
    </v-layout>
  </v-card>
</template>

<script setup lang="ts">
import { RouterLink } from 'vue-router'
import SettingsDialogVue from './SettingsDialog.vue'

import { useRoute } from 'vue-router'
import { Services } from '@/scripts/services'
import type { SignInService } from '@/scripts/signInService'
import { inject, watch } from 'vue'

//---sign in
const signInService = inject(Services.SignInService) as SignInService

watch(
  () => signInService.token,
  (value) => {
    console.log(`Signed in user: ${value.userName}`)
  }
)
//--------
</script>
