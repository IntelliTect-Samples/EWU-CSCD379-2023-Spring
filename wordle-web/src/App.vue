<template>
  <v-layout>
    <v-app-bar color="primary">
      <template #title>
        <div @click="$router.push('/')" style="cursor: pointer">Wordle Mind Bender</div>
      </template>

      <template #prepend>
        <v-icon icon="mdi-grid" class="mt-1 ml-2" @click="$router.push('/')" />
      </template>

      <template #append>
        <v-app-bar-nav-icon @click.stop="drawerOpen = !drawerOpen" />
      </template>
    </v-app-bar>
    <v-navigation-drawer v-model="drawerOpen" location="right" temporary>
      <v-list>
        <v-list-item to="/about" prepend-icon="mdi-information"> About </v-list-item>
        <v-list-item @click.stop="dialogOpen = true" prepend-icon="mdi-cog">
          Settings
          <SettingsDialog v-model="dialogOpen" />
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-main>
      <v-container class="pa-3 pt-5">
        <RouterView />
      </v-container>
    </v-main>
  </v-layout>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import SettingsDialog from './components/SettingsDialog.vue'
import { ref } from 'vue'

const dialogOpen = ref(false)
const drawerOpen = ref(false)

const theme = useTheme()
theme.global.name.value = localStorage.getItem('v-theme') ?? 'darkEnergizing'
</script>
