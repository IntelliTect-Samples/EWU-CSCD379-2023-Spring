<template>
    <v-dialog v-model="dialog" width="30%">
      <v-card>
        <div class="d-flex justify-center pa-2 bg-primary text-h6">
          Welcome to Wordle Mind Bender
        </div>
        <v-card-text class="d-flex flex-column align-center">
          This is the wordle game we made over the coarse of the semester. It is a game where you try to guess a word
          based on the number of letters in the word and the letters that are in the word.
        </v-card-text>
        <v-card-actions class="justify-center">
          <v-btn class="bg-primary" @click="dialog = false">Play</v-btn>
          <v-btn class="bg-primary" to="/tutorial" >Instructions</v-btn>
          <v-btn class="bg-primary" to="/leaderboard">Leaderbaord!</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </template>
  
  <script lang="ts" setup>
import { ref } from 'vue';


  var dialog = ref(true)

  </script>
  