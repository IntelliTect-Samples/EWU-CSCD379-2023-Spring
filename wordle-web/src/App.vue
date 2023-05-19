<template>
  <v-app class="justify-center">
    <AppBar></AppBar>
    <br />
    <br />
    <br />

    <main>
      <RouterView />
    </main>
  </v-app>
</template>

<script setup lang="ts">
import { reactive } from 'vue'
import { useDisplay } from 'vuetify'
import { provide } from 'vue'
import { PlayerService } from './scripts/playerService'
import { Services } from './scripts/services'
import AppBar from './components/AppBar/AppBar.vue'

// Provide the useDisplay to other components so that it can be used in testing.
const display = reactive(useDisplay())
provide(Services.Display, display)
const playerService = new PlayerService()
playerService.setupPlayerAsync()
provide(Services.PlayerService, playerService)
</script>
