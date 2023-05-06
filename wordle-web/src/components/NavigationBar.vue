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

        <v-card>
          <router-link to="/leaderBoard"><v-btn>Link To leaderBoard</v-btn></router-link>
        </v-card>
        <!--
        <LoginDialog />
        -->
        <v-btn>
          <SettingsDialogVue />
        </v-btn>

        <template v-slot:append>
          <v-menu>
            <template v-slot:activator="{ props }">
              <v-btn v-bind="props" icon="mdi-hamburger"> </v-btn>
            </template>

            <v-list>
              <router-link to="/about"
                ><v-list-item-title>Link To About Page</v-list-item-title></router-link
              >
              <router-link to="/wordle"
                ><v-list-item-title>Link To Wordle Game</v-list-item-title></router-link
              >
              <router-link to="/leaderBoard"
                ><v-list-item-title>Link To LeaderBoard</v-list-item-title></router-link
              >
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
import LoginDialog from './LoginDialog.vue'
</script>
