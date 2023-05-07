<template>
  <v-container>
    <h1 class="text-center">REALLY COOL WORDLE GAME !!!</h1>
  </v-container>

  <v-container>
    <RouterLink to="/wordle">
      <h2>Play</h2>
    </RouterLink>
    <RouterLink to="/leaderboard">
      <h2>Leaderboard</h2>
    </RouterLink>
  </v-container>
</template>

<script setup lang="ts"></script>
