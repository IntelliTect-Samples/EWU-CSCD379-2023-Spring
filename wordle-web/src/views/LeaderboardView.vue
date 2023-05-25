<template>
  <v-row class="justify-center"><h1>Overall</h1></v-row>
  <v-container>
    <v-table :theme="theme.global.name.value">
      <thead>
        <tr>
          <th class="text-center">Rank</th>
          <th class="text-center">Name</th>
          <th class="text-center">Avg. Attempts</th>
          <th class="text-center">Games Played</th>
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
  <v-row class="justify-center"><h1>Daily</h1></v-row>
  <v-container>
    <v-table :theme="theme.global.name.value">
      <thead>
        <tr>
          <th class="text-center">Date</th>
          <th class="text-center">Avg. Attempts</th>
          <th class="text-center">Avg. Seconds</th>
          <th class="text-center">Games Played</th>
          <th class="text-center">{{ name }} Has Played?</th>
        </tr>
      </thead>
      <tbody>
        <tr class="text-center" v-for="item in daily" :key="item">
          <td>{{ item.split(',')[0] }}</td>
          <td>{{ item.split(',')[1] }}</td>
          <td>{{ item.split(',')[4] }}</td>
          <td>{{ item.split(',')[2] }}</td>
          <td>{{ item.split(',')[5] }}</td>
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
  result.value = await LeaderboardService.getLeaderboardFromApi()
  daily.value = await LeaderboardService.getDailyLeaderboard()
})
</script>
