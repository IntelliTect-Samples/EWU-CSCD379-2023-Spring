<template>
    <div class="game">
        <v-btn to="/game" color="blue" class="btn">
               <v-icon icon="mdi:mdi-controller" class="icon"/> Click here to play <v-icon icon="mdi:mdi-controller" class="icon"/>
        </v-btn>
    </div>
  </template>
  
  <style>
  .icon {
    margin: 8px;
  }
  @media (min-width: 1024px) {
    .game {
      min-height: 100vh;
      display: flex;
      align-items: center;
      justify-content: center;
    }
  }
  </style>