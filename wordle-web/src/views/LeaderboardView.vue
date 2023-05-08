<template>
  <div>
    <v-card>
      <h1>Leaderboard</h1>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Score</th>
            <th>Game Count</th>
            <th>Average Attempts</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="player in players" :key="player.playerId">
            <td>{{ player.name }}</td>
            <td>{{ player.score }}</td>
            <td>{{ player.gameCount }}</td>
            <td>{{ player.averageAttempts }}</td>
          </tr>
        </tbody>
      </table>
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
      this.players = leaderboardData.map((playerData: any) => {
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

<style scoped></style>
