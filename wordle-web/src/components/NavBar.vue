<template>
  <v-layout>
    <v-app-bar color="warning" density="compact" primary>
      <v-app-bar-title to="/">
        <v-btn :ripple="false" variant="plain" to="/">
          <v-icon>mdi-file-word-box</v-icon>
          Wordle
        </v-btn>
      </v-app-bar-title>
      <SettingsTab></SettingsTab>
      <template v-slot:append>
        <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      </template>
    </v-app-bar>

    <v-navigation-drawer v-model="drawer" temporary location="right">
      <v-list density="compact" nav>
        <v-list-item
          prepend-icon="mdi-view-dashboard"
          title="Home"
          value="home"
          to="/"
        ></v-list-item>
        <v-list-item
          prepend-icon="mdi-file-word-box"
          title="Wordle"
          value="wordle"
          to="/wordle"
        ></v-list-item>
        <v-list-item prepend-icon="mdi-forum" title="About" value="about" to="/about"></v-list-item>
      </v-list>
    </v-navigation-drawer>
  </v-layout>
</template>

<script setup lang="ts">
import SettingsTab from '@/components/SettingsTab.vue'
import { ref } from 'vue'

let drawer = ref(false)
</script>
