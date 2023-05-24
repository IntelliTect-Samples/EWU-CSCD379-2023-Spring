<template>
  <v-responsive min-width="300px">
    <v-card>
      <v-card-title class="justify-center">Welcome To The Good Word</v-card-title>
      <v-card-item>
        <v-card-text>
          In this casual game mode you can practice your skills or just play for fun!
        </v-card-text>

        <v-card-actions class="justify-center">
          <v-btn to="/wordle" rounded="xl" elevation="16">Free Play</v-btn>
        </v-card-actions>
      </v-card-item>

      <v-card-item>
        <v-card-text> Log on daily to play our word of the day in this game mode! </v-card-text>

        <v-card-actions class="justify-center">
          <v-btn to="/wordoftheday" rounded="xl" elevation="16">Daily Word</v-btn>
        </v-card-actions>
      </v-card-item>

      <v-card-item>
        <v-card-text> View the current leaderboard or your personal stats here! </v-card-text>

        <v-card-actions class="justify-center">
          <v-btn to="/leaderboard" rounded="xl" elevation="16">Leaderboard</v-btn>
        </v-card-actions>
      </v-card-item>

      <v-card-item>
        <v-card-text>
          First time player? Or just need a refresher? Click here to view the rules of the game!
        </v-card-text>

        <v-card-actions class="justify-center">
          <v-btn to="/instructions" rounded="xl" elevation="16">How To Play</v-btn>
        </v-card-actions>
      </v-card-item>
    </v-card>
  </v-responsive>
</template>

<script setup lang="ts"></script>
