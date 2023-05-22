<template>
  <v-container>
    <h1 class="text-center">THIS GAME LETS YOU DO WHAT?!?!</h1>
  </v-container>

  <v-container class="text-center">
    <v-btn>
      <RouterLink to="/wordoftheday">
        <h2>Daily Word Challenge</h2>
      </RouterLink>
    </v-btn></v-container
  >
  <v-container class="text-center">
    <v-btn>
      <RouterLink to="/wordle">
        <h2>Random Word</h2>
      </RouterLink>
    </v-btn></v-container
  >
  <v-container class="text-center">
    <v-btn
      ><RouterLink to="/leaderboard">
        <h2>Leaderboard</h2>
      </RouterLink>
    </v-btn>
  </v-container>
</template>

<script setup lang="ts"></script>
