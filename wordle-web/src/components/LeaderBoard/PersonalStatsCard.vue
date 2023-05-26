<!--
---- Displays the personal stats of the current player on a v-card.
--->

<template>
  <v-card>
    <div class="text-center">
      <v-card-title> Personal Stats </v-card-title>
      <v-card-item>
        <v-table class="align-center justify-center">
          <thead>
            <tr>
              <th class="text-center">Username</th>
              <th class="text-center">Games Played</th>
              <th class="text-center">Average Guesses</th>
              <th class="text-center">Average Time</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>{{ playerService.player.playerName }}</td>
              <td>{{ playerService.player.gameCount }}</td>
              <td>{{ playerService.player.averageAttempts }}</td>
              <td>{{ playerService.player.averageSecondsPerGame }}</td>
            </tr>
          </tbody>
        </v-table>
      </v-card-item>
    </div>
  </v-card>
</template>

<script setup lang="ts">
import { inject } from 'vue'
import { Services } from '@/scripts/services/services'
import type { PlayerService } from '@/scripts/services/playerService'

const playerService = inject(Services.PlayerService) as PlayerService
playerService.refreshPlayerFromServerAsync()
</script>
