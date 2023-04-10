<template>
    <div class="about">
      <v-card>
        <v-card-title> Word Golf </v-card-title>
        <v-card-subtitle> Connect words with letter substitution </v-card-subtitle>
  
        <v-card-text>
          Connect a word to another word through letter substitution
          <v-icon icon="mdi:mdi-abacus" />
        </v-card-text>
  
        <v-card-actions>
          <v-spacer />
          <v-btn text color="warning"><RouterLink to="/">Home Page</RouterLink></v-btn>
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
  