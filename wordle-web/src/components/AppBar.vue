<template>
  <v-card>
    <nav>
      <v-layout>
        <v-toolbar prominent>
            <RouterLink to="/"><icon/></RouterLink>
          <v-toolbar-title><RouterLink to="/">Wordle</RouterLink></v-toolbar-title>
          <v-app-bar-nav-icon
            variant="text"
            @click.stop="showDrawer = !showDrawer"
          ></v-app-bar-nav-icon>
        </v-toolbar>
      </v-layout>
    </nav>
    <p><RouterView /></p>

    <v-navigation-drawer v-model="showDrawer" location="right" temporary elevation="24">
      <v-list nav dense>
        <v-list-item>
          <RouterLink to="/">Home</RouterLink>
        </v-list-item>
        <v-list-item>
          <RouterLink to="/wordle">Wordle</RouterLink>
        </v-list-item>
        <v-list-item>
          <RouterLink to="/about">About</RouterLink>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </v-card>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import icon from './icons/icon.vue'

let showDrawer = ref(false)
</script>
