<template>
  <v-layout>
    <v-app-bar class="custom-app-bar" color="primary" density="compact">
      <template v-slot:prepend>
        <RouterLink to="/">
          <v-img :width="200" cover src="https://i.imgur.com/HSZpKhV.jpg"> </v-img>
        </RouterLink>
      </template>

      <RouterLink to="/leaderboard">
        <h2>Leaderboard</h2>
      </RouterLink>

      <SettingsTab />
      <template v-slot:append>
        <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      </template>
      <LoginPopout></LoginPopout>
    </v-app-bar>

    <v-navigation-drawer v-model="drawer" temporary location="right">
      <v-list density="compact" nav>
        <v-list-item
          prepend-icon="mdi-trophy"
          title="About"
          value="about"
          to="/about"
        ></v-list-item>
        <v-list-item
          prepend-icon="mdi-chat-question"
          title="Instructions"
          value="instructions"
          to="/instructions"
        ></v-list-item>
        <v-list-item
          prepend-icon="mdi-pencil"
          title="Submit Clips"
          value="editor"
          to="/editor"
        ></v-list-item>
        <v-list-item
          prepend-icon="mdi-account"
          title="Profile"
          value="profile"
          to="/profile"
        ></v-list-item>
      </v-list>
    </v-navigation-drawer>
  </v-layout>
</template>

<script setup lang="ts">
import SettingsTab from '@/components/SettingsPopout.vue'
import { moduleExpression } from '@babel/types'
import { ref } from 'vue'
import LoginPopout from './LoginPopout.vue'
let drawer = ref(false)
</script>
