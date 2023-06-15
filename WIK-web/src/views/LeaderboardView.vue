<template>
  <v-row class="justify-center"><h1>Most Games Played</h1></v-row>
  <v-container>
    <v-table :theme="theme.global.name.value">
      <thead>
        <tr>
          <th class="text-center">Rank</th>
          <th class="text-center">Name</th>
          <th class="text-center">Wins</th>
          <th class="text-center">Losses</th>
        </tr>
      </thead>
      <tbody>
        <tr class="text-center" v-for="(item, i) in result" :key="item">
          <td>{{ i + 1 }}</td>
          <td>{{ item.split(',')[0] }}</td>
          <td>{{ item.split(',')[1] }}</td>
          <td>{{ item.split(',')[2] }}</td>
        </tr>
      </tbody>
    </v-table>
  </v-container>
  <v-row class="justify-center"><h1>Most Viewed Clips</h1></v-row>
  <v-container>
    <v-table :theme="theme.global.name.value">
      <thead>
        <tr>
          <th class="text-center">Rank</th>
          <th class="text-center">Url</th>
          <th class="text-center">Correct Guesses</th>
          <th class="text-center">Incorrect Guesses</th>
        </tr>
      </thead>
      <tbody>
        <tr class="text-center" v-for="(item, j) in daily" :key="item">
          <td>{{ j + 1 }}</td>
          <td>{{ item.split(',')[0] }}</td>
          <td>{{ item.split(',')[1] }}</td>
          <td>{{ item.split(',')[2] }}</td>
        </tr>
      </tbody>
    </v-table>
  </v-container>
</template>

<script setup lang="ts">
  import { useTheme } from 'vuetify/lib/framework.mjs'
  import { LeaderboardService } from '../scripts/leaderboardService'
  import { onMounted, ref } from 'vue'
  const theme = useTheme()
  const name = ref(localStorage.getItem('name'))
  const result = ref(['', ''])
  const daily = ref(['', ''])
  onMounted(async () => {
    result.value = await LeaderboardService.getTopUsers()
    daily.value = await LeaderboardService.getTopClips()
  })
</script>
