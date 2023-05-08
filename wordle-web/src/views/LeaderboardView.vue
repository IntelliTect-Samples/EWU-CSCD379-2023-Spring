<template>
  <div class="leaderboard-container">
    <template v-if="players && players.length > 0">
      <v-card
        v-for="player in players"
        :key="player.id"
        class="mx-auto"
        max-width="300"
        style="margin-bottom: 16px"
      >
        <v-card-title>{{ player.name }}</v-card-title>
        <v-card-text>
          <template v-if="!player.revealStats">
            <v-btn color="primary" @click="revealPlayerStats(player)"> Show Stats </v-btn>
          </template>
          <template v-else>
            <p>Game Count: {{ player.gameCount }}</p>
            <p>Average Attempts: {{ player.averageAttempts }}</p>
          </template>
        </v-card-text>
      </v-card>
    </template>
    <template v-else>
      <v-card class="mx-auto" max-width="300">
        <v-card-text> The Leaderboard Is Empty </v-card-text>
      </v-card>
    </template>
  </div>
</template>

<script lang="ts">
import Axios from 'axios'

interface Player {
  id: number
  name: string
  gameCount: number
  averageAttempts: number
  revealStats: boolean
}

export default {
  data: () => ({
    players: [] as Player[]
  }),
  mounted() {
    this.getTopTenScores()
  },
  methods: {
    getTopTenScores() {
      Axios.get('https://wordlewebassignment.azurewebsites.net/player')
        .then((response) => {
          this.players = response.data.map((player: Player) => ({
            ...player,
            revealStats: false
          }))
        })
        .catch((error) => {
          console.log(error)
        })
    },
    revealPlayerStats(player: Player) {
      player.revealStats = true
    }
  }
}
</script>

<style scoped>
.leaderboard-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100vh;
}
</style>
