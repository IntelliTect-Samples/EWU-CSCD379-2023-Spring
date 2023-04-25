<template>
    <v-card
      class="mx-auto"
      max-width="500"
      variant="outlined"
    >
      <v-card-item>
        <div>
          <div class="text-overline mb-1">
            Help
          </div>
          <div class="text-h6 mb-1">
            Guess the word of the load! 
          </div>
          <div class="text-caption">5 attempts to guess the word or you lose!</div>
        </div>
      </v-card-item>
  
      <v-card-actions>
        <v-btn variant="outlined" to="/wordle">
          Back to Game
        </v-btn>
      </v-card-actions>
    </v-card>
  </template>