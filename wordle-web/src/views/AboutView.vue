<template>
  <v-btn><RouterLink to="/leaderboard">Leader Board</RouterLink></v-btn>
  <div class="text-h4 text-center">This is the about page</div>
</template>

<script setup lang="ts"></script>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
