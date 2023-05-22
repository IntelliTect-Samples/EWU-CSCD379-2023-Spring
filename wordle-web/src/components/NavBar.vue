<template>
  <v-layout>
    <v-app-bar class="custom-app-bar" color="primary" density="compact">
      <template v-slot:prepend>
        <RouterLink to="/">
          <h1 class="titleClass">Wordle Web</h1>
        </RouterLink>
        <RouterLink to="/">
          <v-icon color="hsla(160, 100%, 37%, 1)" icon="mdi-alpha-w-box" size="large" />
        </RouterLink>
      </template>

      <RouterLink to="/leaderboard">
        <h2>Leaderboard</h2>
      </RouterLink>

      <SettingsTab />
      <template v-slot:append>
        <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      </template>
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
          prepend-icon="mdi-question"
          title="Instructions"
          value="instructions"
          to="/instructions"
        ></v-list-item>
      </v-list>
    </v-navigation-drawer>
  </v-layout>
</template>

<script setup lang="ts">
import SettingsTab from '@/components/SettingsPopout.vue'
import { ref } from 'vue'

let drawer = ref(false)
</script>
