<template>
  <main>Home Page</main>
  <v-btn @click="addPlayer()" style="tonal">Add Player</v-btn>
</template>

<script setup lang="ts">
import Axios from 'axios'

function addPlayer() {
  console.log('Adding Nick!')
  Axios.post('player/AddPlayer', {
    Name: 'nick'
  })
    .then((response) => {
      console.log(response.data)
    })
    .catch((error) => {
      console.log(error)
    })
}
</script>
