<template>
  <v-container class="fill-height" fluid>
    <v-row justify="center" align="center">
      <v-col cols="12" align="center">
        <v-icon icon="mdi-alpha-w-box-outline" :size="150" class="text-shadow"></v-icon>
      </v-col>
      <v-col cols="12" align="center">
        <h1 class="text-h1 text-shadow">Wordle</h1>
      </v-col>
      <v-col cols="12" md="6" xl="3" align="center">
        <h1 class="text-h2 text-shadow">Get 6 chances to guess a 5 letter word.</h1>
      </v-col>
      <v-col cols="12" align="center">
        <v-btn
          color="success"
          :min-width="150"
          :min-height="50"
          class="text-h6 rounded-xl elevation-0"
          to="/wordoftheday"
          >Today's Puzzle</v-btn
        >
        <v-divider vertical :thickness="20" v-if="!display.xs"></v-divider>
        <v-col cols="12" v-if="display.xs"></v-col>
        <v-btn
          color="primary"
          :min-width="150"
          :min-height="50"
          class="text-h6 rounded-xl elevation-0"
          to="/play"
          >Play</v-btn
        >
        <v-divider vertical :thickness="20" v-if="!display.xs"></v-divider>
        <v-col cols="12" v-if="display.xs"></v-col>
        <v-btn
          color="info"
          :min-width="150"
          :min-height="50"
          class="text-h6 rounded-xl elevation-0"
          to="/leaderboard"
          >Leaderboard</v-btn
        >
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { Services } from '@/scripts/services'
import { inject, reactive } from 'vue'
import { useDisplay } from 'vuetify/lib/framework.mjs'

// Add this to make testing work because useDisplay() throws an error when testing
// Wrap useDisplay in a function so that it doesn't get called during testing.
const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>
</script>
