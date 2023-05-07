<template>
  <v-card>
    <main>-- L Page --</main>
  </v-card>
  <v-card>
    time to complete last game = {{ totalTime }} seconds
  </v-card>
  <v-card>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">player Name</th>
          <th class="text-left">Score</th>
          <th class="text-left">Agv Attempts</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in data().topPlayers" :key="item.name">
          <td>{{ item.name }}</td>
          <td>{{ item.gamesPlayed }}</td>
          <td>{{ item.avgAttempts }}</td>
        </tr>
      </tbody>
    </v-table>
  </v-card>
  <v-btn density="compact" @click="goBack"> Back </v-btn>
</template>

<script setup lang="ts">
import Axios from 'axios'
import $router from '../router/index'

var totalTime = localStorage.total_time/1000

function goBack() {
  $router.go(-1)
}

//var players = []
/*
Axios.get('player/GetTopTenPlayers')
  .then((response) => {
    response.data.forEach((player) => {


    })
      
    
  })
  .catch((error) => {
    console.log(error)
  })*/

function data() {
  return {
    topPlayers: [
      {
        name: 'Frozen Yogurt',
        gamesPlayed: 159,
        avgAttempts: 12
      },
      {
        name: 'Ice cream sandwich',
        gamesPlayed: 237,
        avgAttempts: 12
      },
      {
        name: 'Eclair',
        gamesPlayed: 262,
        avgAttempts: 12
      },
      {
        name: 'Cupcake',
        gamesPlayed: 305,
        avgAttempts: 12
      },
      {
        name: 'Gingerbread',
        gamesPlayed: 356,
        avgAttempts: 12
      },
      {
        name: 'Jelly bean',
        gamesPlayed: 375,
        avgAttempts: 12
      },
      {
        name: 'Lollipop',
        gamesPlayed: 392,
        avgAttempts: 12
      },
      {
        name: 'Honeycomb',
        gamesPlayed: 408,
        avgAttempts: 12
      },
      {
        name: 'Donut',
        gamesPlayed: 452,
        avgAttempts: 12
      },
      {
        name: 'KitKat',
        gamesPlayed: 518,
        avgAttempts: 12
      }
    ]
  }
}
</script>
