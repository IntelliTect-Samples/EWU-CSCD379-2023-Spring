<template>
  <v-container class="text-center">
    <h1><strong>Welcome to World Redux</strong></h1>
    <br/>
    <h3>A game a casual game of Wordle</h3>
    <v-btn @click="$router.push('/Wordle')" color="primary">Wordle</v-btn>
    <br/>
    <br/>
    <h3>Compete to be the first to guess our wordle of the day</h3>
    <v-btn @click="$router.push('/worldoftheday')" color="primary">Wordle of the day</v-btn>
    <br/>
    <br/>
    <h3>Check out how you stack up against other players</h3>
    <v-btn @click="$router.push('/Leaderboard')" color="primary">Leaderboard</v-btn>
    <br/>
    <br/>
    <h3>See the last 10 wordles of the day</h3>
    <v-btn @click="$router.push('/lasttenwords')" color="primary">Last 10 Wordle of the day</v-btn>
    <br/>
    <br/>
    <h3>Learn more about us</h3>
    <v-btn @click="$router.push('/about')" color="primary">About</v-btn>
    <br/>
    <br/>
    <h3>Want to add a word to our word bank?</h3>
    <v-btn @click="$router.push('/wordeditor')" color="primary">Word Editor</v-btn>



  </v-container>
</template>

<script setup lang="ts">
</script>


