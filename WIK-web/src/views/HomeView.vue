<template>
  <v-container class="text-center">
    <h1>Just One Question...</h1>
  </v-container>

  <v-container class="text-center">
    <v-btn>
      <RouterLink to="/wikgame"> <h2>Will It Kill?</h2></RouterLink>
    </v-btn>
  </v-container>
  <v-container class="text-center">
    <v-btn
      ><RouterLink to="/leaderboard">
        <h2>Leaderboard</h2>
      </RouterLink>
    </v-btn>
  </v-container>
</template>

<script setup lang="ts"></script>
