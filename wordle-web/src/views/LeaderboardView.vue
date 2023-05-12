<template>
  <div>
    <v-card>
      <v-card-title>
        <div class="text-h4">Leaderboard</div>
      </v-card-title>
      <v-table dense>
        <thead>
          <tr>
            <th class="text-center">Rank</th>
            <th class="text-center">Name</th>
            <th class="text-center">Score</th>
            <th class="text-center">Game Count</th>
            <th class="text-center">Average Attempts</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(player, index) in players" :key="player.playerId">
            <td class="text-center">{{ index + 1 }}</td>
            <td class="text-center">
              <v-icon v-if="index === 0" small class="mr-1">mdi-crown</v-icon>
              {{ player.name }}
            </td>
            <td class="text-center">{{ player.score }}</td>
            <td class="text-center">{{ player.gameCount }}</td>
            <td class="text-center">{{ player.averageAttempts }}</td>
          </tr>
        </tbody>
      </v-table>
    </v-card>
  </div>
</template>

<script lang="ts">
import { LeaderboardService } from '../scripts/leaderboardService'
import { Player } from '../scripts/player'

export default {
  data() {
    return {
      players: [] as Player[]
    }
  },
  async created() {
    try {
      const leaderboardData = await LeaderboardService.GetLeaderboard()
      this.players = leaderboardData.map((playerData: Player) => {
        return new Player(
          playerData.playerId,
          playerData.name,
          playerData.score,
          playerData.gameCount,
          playerData.averageAttempts
        )
      })
    } catch (error) {
      console.error('Failed to fetch leaderboard data:', error)
    }
  }
}
</script>

<style scoped>
.mr-1 {
  margin-right: 0.5rem;
}
</style>
