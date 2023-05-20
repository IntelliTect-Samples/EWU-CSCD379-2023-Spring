<!--
---- Displays the personal stats of the current player on a v-card.
--->

<template>
  <div class="text-center align-center justify-center">
    <v-card-title class="display-1"> Personal Stats </v-card-title>
    <v-table class="align-center justify-center">
      <thead>
        <tr>
          <th class="text-center">Username</th>
          <th class="text-center">Games Played</th>
          <th class="text-center">Average Number of Guesses</th>
          <th class="text-center">Average Time to Finish</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>{{ playerService.player.name }}</td>
          <td>{{ playerService.player.gameCount }}</td>
          <td>{{ playerService.player.averageAttempts }}</td>
          <td>{{ playerService.player.averageSecondsPerGame }}</td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script setup lang="ts">
import { inject } from 'vue'
import { Services } from '@/scripts/Services/services'
import type { PlayerService } from '@/scripts/Services/playerService'

const playerService = inject(Services.PlayerService) as PlayerService
</script>
