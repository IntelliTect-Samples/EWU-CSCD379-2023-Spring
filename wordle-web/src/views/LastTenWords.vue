<template>
<v-card @click="redirect">
    <v-card-title class="text-center"><strong>Last 10 Wordle of the day</strong></v-card-title>
    <v-table density="compact" >
        <thead>
      <tr>
        <th class="text-left">
        Date
        </th>
        <th class="text-left">
        Average Seconds Per Game
        </th>
        <th class="text-left">
        Average Attempts
        </th>
        <th class="text-left">
        Number of Plays
        </th>
        <th class="text-left">
        Has User Played
        </th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in playerData" :key="item.date">
        <td>{{ item.date.split('T')[0] }}</td>
        <td>{{ item.averageSecondsPerGame === -1 ? 0 : item.averageSecondsPerGame }}</td>
        <td>{{ item.averageAttempts === -1 ? 0 : item.averageAttempts }}</td>
        <td>{{ item.numberOfPlays }}</td>
        <td>{{ item.hasUserPlayed ? 'Yes' : 'No' }}</td>
      </tr>
    </tbody>
    </v-table>
</v-card>


<v-overlay
      :model-value="overlay"
      class="align-center justify-center"
    >
      <v-progress-circular
        color="primary"
        indeterminate
        size="64"
      ></v-progress-circular>
    </v-overlay>


</template>

<script setup lang="ts">
import { ref } from 'vue';
import Axios from 'axios'



var playerData = ref<PlayerData[]>([])
const overlay = ref(true)

interface PlayerData {
  date: string
  averageSecondsPerGame: number
  averageAttempts: number
  numberOfPlays: number
  hasUserPlayed: boolean
}

  Axios.get('Word/GetDailyWordStatistics?name=' + localStorage.getItem('username'))
  .then((response) => {
    console.log(response.data)
    playerData.value = response.data
    overlay.value = false
  })
  .catch((error) => {
    console.log(error)
  })

  function redirect() {
    window.location.href = '/worldoftheday'
  }



</script>