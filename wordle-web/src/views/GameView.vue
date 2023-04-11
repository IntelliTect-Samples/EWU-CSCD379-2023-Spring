
import { VSpacer } from 'vuetify/lib/components';

<template>
  <div class="game">
    <VCard variant="tonal">
        <VCardTitle>
            WordleCopy
        </VCardTitle>
          <v-divider :thickness="5"></v-divider>
        
          <v-combobox
          label="WordGuess"
          clearable
          :items="['should be dictionary']"
        ></v-combobox>
      <VCardActions>
        <VSpacer></VSpacer>
        <v-btn variant="tonal">
          <RouterLink to="/">Home</RouterLink>
        </v-btn>
      </VCardActions>
    </VCard>
  </div>
  </template>
  
  <style>
    @media (min-width: 1024px) {
      .game {
        min-height: 100vh;
        display: flex;
        align-items: center;
      }
    }
  </style>
  