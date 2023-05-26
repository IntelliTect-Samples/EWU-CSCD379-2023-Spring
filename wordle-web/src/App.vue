<template>
  <v-app class="justify-center">
    <span class="bg"></span>
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
import { PlayerService } from '@/scripts/services/playerService'
import { Services } from '@/scripts/services/services'
import AppBar from '@/components/Header/HeaderAppBar.vue'

// Provide the useDisplay to other components so that it can be used in testing.
const display = reactive(useDisplay())
provide(Services.Display, display)
const playerService = new PlayerService()
playerService.setupPlayerAsync()
provide(Services.PlayerService, playerService)
</script>
