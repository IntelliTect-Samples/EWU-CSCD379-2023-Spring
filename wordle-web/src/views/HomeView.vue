<template>
  <v-container>
    <v-card class="mx-auto" max-width="600">
      <v-card-title class="text-center">Welcome to YAWC (Yet Another Wordle Clone)!</v-card-title>
      <v-card-text>
        Wordle is a popular online word-guessing game where players try to guess a hidden
        five-letter word in a limited number of attempts. At the start of the game, a random
        five-letter word is generated and hidden from the player. The player then has six attempts
        to guess the word. Good luck!
      </v-card-text>
      <v-card-actions>
        <v-btn variant="outlined" @click="$router.push('/wordle')">Play!</v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script setup lang="ts"></script>
