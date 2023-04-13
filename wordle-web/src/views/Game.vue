<template>
    <div class="game">
      <v-card>
        <v-card-title> Welcome to bear royale! </v-card-title>
        <v-card-subtitle> (game idea) </v-card-subtitle>
  
        <v-card-text>
          Be the last bear in your area in an arena of 3 bears. 
        </v-card-text>
  
        <v-card-actions>
          <v-spacer />
          <RouterLink to="/">Home<v-btn text color="primary"></v-btn> </RouterLink>
        </v-card-actions>
      </v-card>
    </div>
  </template>
  
  <style>
  @media (min-width: 1024px) {
    .about {
      min-height: 100vh;
      display: flex;
      align-items: center;
    }
  }
  </style>
  