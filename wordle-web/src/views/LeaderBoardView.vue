<template>
  <div class="leaderboard">
    <h1>Leaderboard</h1>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">Name</th>
          <th class="text-left">Average Guesses</th>
          <th class="text-left">Games Played</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="player in players" :key="player.playerId">
          <td>{{ player.name }}</td>
          <td>{{ player.averageAttempts }}</td>
          <td>{{ player.gameCount }}</td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  data() {
    return {
      players: []
    }
  },
  async created() {
    try {
      const response = await axios.get('https://wordle-assignment3.azurewebsites.net/leaderboard')
      this.players = response.data
    } catch (error) {
      console.error('Error fetching leaderboard data:', error)
    }
  }
}
</script>

<style scoped>
th,
td {
  padding: 8px;
  text-align: left;
}

th {
  font-weight: bold;
}
</style>
