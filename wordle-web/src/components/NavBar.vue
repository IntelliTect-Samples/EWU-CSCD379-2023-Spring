<template>
  <v-layout>
    <v-app-bar color="primary">
      <v-app-bar-title @click="$router.push('/')">
        <v-icon>mdi-looks</v-icon>
        Wordle
      </v-app-bar-title>
      <SettingsDialog />
      <template v-slot:append>
        <v-app-bar-nav-icon @click.stop="open = !open"></v-app-bar-nav-icon>
      </template>
    </v-app-bar>
    <v-navigation-drawer v-model="open" temporary location="right">
      <v-list>
        <v-list-item title="Home" to="/"></v-list-item>
        <v-list-item title="About" to="/about"></v-list-item>
        <v-list-item title="Wordle" to="/wordle"></v-list-item>
      </v-list>
    </v-navigation-drawer>
  </v-layout>
</template>

<script setup lang="ts">
import SettingsDialog from '@/components/SettingsDialog.vue'
import { ref } from 'vue'

let open = ref(false)
</script>
