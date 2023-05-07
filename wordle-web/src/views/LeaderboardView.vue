<template>
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
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { LeaderboardService } from '../scripts/leaderboardService'
import { onMounted, ref } from 'vue'
const theme = useTheme()
let result = ref(['', ''])
onMounted(async () => {
  result.value = await LeaderboardService.getLeaderboardFromApi()
})
</script>
