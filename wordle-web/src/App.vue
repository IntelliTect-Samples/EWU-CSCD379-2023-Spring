<template>
  <header>
    <v-toolbar id="toolbar">
      <img alt="Vue logo" class="logo" src="@/assets/logo.svg" width="50" height="50" />
      <v-toolbar-title>Wordle Web</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-toolbar-items>
        <v-btn to="/">Home</v-btn>
        <v-btn to="/wordle">Wordle</v-btn>
        <v-btn to="/about">About</v-btn>
      </v-toolbar-items>
    </v-toolbar>
  </header>

  <RouterView />
</template>

<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<style scoped>
#toolbar {
  width: 100%;
  padding: 6px 24px;
  background-color: #141414;
  font-size: 26px;
  font-weight: bold;
  border-bottom: 3px solid #4c4c4c;
  min-height: 65px;
  color: white;
}
</style>
