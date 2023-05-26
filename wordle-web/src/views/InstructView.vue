<template>
    <v-parallax height="650" src="https://source.unsplash.com/RwHv7LgeC7s">
      <div class="d-flex flex-column fill-height justify-center align-center text-white">
        <h1 class="text-h1 font-weight-bold mb-4">W.O.R.D.L.E</h1>
        <p class="subheading font-weight-bold">Check out all we have to offer in this bootleg copy of the classic NYTimes fan-favorite!</p>
        <div>
          <v-btn variant="outlined" class="midbtn">How to Play</v-btn>
          <v-btn to="/wordoftheday" variant="outlined" class="midbtn">Daily Wordle</v-btn>
          <v-btn variant="outlined" class="midbtn">Recent Wordles</v-btn>
          <v-btn to="/wordle" variant="outlined" class="midbtn">Play Random</v-btn>
        </div>
      </div>
    </v-parallax>
  </template>
  <style>
    .midbtn {
      margin-top: 15px;
      margin-left: 5px;
      margin-right: 5px;
    }
  </style>
  <script lang="ts">
  
  </script>
  