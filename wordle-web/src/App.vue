<script setup lang="ts">
import { RouterView } from 'vue-router'
import ThemeSelector from './components/ThemeSelector.vue'
</script>

<template>
  <v-container fluid class="pa-0">
    <v-row class="ma-0">
      <v-col class="pa-0">
        <v-toolbar density="compact" class="elevation-4">
          <v-toolbar-title style="cursor: pointer" @click="$router.push('/')">
            <v-icon icon="mdi-gamepad-square" class="mx-1" color="teal"></v-icon>
            Wordle Mind Bender
          </v-toolbar-title>
          <v-spacer></v-spacer>
          <v-menu location="bottom">
            <template v-slot:activator="{ props }">
              <v-btn k v-bind="props"> <v-icon icon="mdi-menu" size="x-large"></v-icon> </v-btn>
            </template>

            <v-list flat>
              <v-list-item>
                <v-btn variant="plain" to="/"> Home </v-btn>
              </v-list-item>
              <v-list-item>
                <v-btn variant="plain" to="/about"> About </v-btn>
              </v-list-item>
              <v-list-item>
                <v-btn variant="plain" to="/game"> Game </v-btn>
              </v-list-item>
            </v-list>
          </v-menu>

          <ThemeSelector />
        </v-toolbar>
      </v-col>
    </v-row>

    <v-row>
      <v-col cols="auto" class="mx-auto">
        <RouterView />
      </v-col>
    </v-row>
  </v-container>
</template>
