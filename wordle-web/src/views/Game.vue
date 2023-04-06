<template>
    <div class="game">
      <v-card>
        <v-card-title> Welcome to bear royal! </v-card-title>
        <v-card-subtitle> (game idea) </v-card-subtitle>
  
        <v-card-text>
          Be the last bear in your area in an arena of 3 bears. 
        </v-card-text>
  
        <v-card-actions>
          <v-spacer />
          <v-btn text color="warning">Cancel</v-btn>
          <v-btn text color="primary">OK</v-btn>
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
  