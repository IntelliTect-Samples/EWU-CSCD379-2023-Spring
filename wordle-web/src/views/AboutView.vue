<script setup lang="ts"></script>

<template>
  <v-card>
    <v-card-title> About </v-card-title>
    <v-card-text>
      This project was created by an aspiring web developer who is taking a class through Eastern
      Washington University - CSCD379<br />
      The end goal of this project is to create a working version of the classic word game Wordle
      using Vue.js and Vuetify. Along with a few other things to make it interesting.
      <br /><br />
      One of our instrustors is Meg, she is a genius sofware engineer at Intellitect. Shadowing her
      made me realize I wanted to become a developer! <br />
      The other instructor is Grant, and he is the Chief Techical Officer at Intellitect.
    </v-card-text>
  </v-card>
  <br /><br />
  <v-btn class="button" variant="outlined" color="secondary" @click="$router.go(-1)">Back</v-btn>
  &nbsp;
  <v-btn variant="outlined" color="secondary" to="/">Home</v-btn>
</template>

<!-- <style>
h1 {
    min-height: 100vh;
    place-items: center;
}

p {
    min-height: 100vh;
    place-items: center;
}
</style> -->
