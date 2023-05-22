<template>
  <v-container>
    <h1 class="text-center">THIS GAME LETS YOU DO WHAT?!?!</h1>
  </v-container>

  <v-container>
    <RouterLink to="/instructions">
      <h2>Instructions</h2>
    </RouterLink>
    <RouterLink to="/wordle">
      <h2>Play</h2>
    </RouterLink>
    <RouterLink to="/wordoftheday">
      <h2>Daily Word</h2>
    </RouterLink>
    <RouterLink to="/leaderboard">
      <h2>Leaderboard</h2>
    </RouterLink>
  </v-container>
</template>

<script setup lang="ts"></script>
