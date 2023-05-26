<template>
  <v-container>
    <div class="d-flex justify-center">Welcome!</div>
    <v-card
      class="text-center"
      title="Try a random word!"
      text="This button will take you to a random wordle. You can play as many as you want, and your stats will be tracked."
      variant="outlined"
    >
      <v-card-actions class="justify-center">
        <router-link to="/wordle">
          <v-btn> Wordle </v-btn>
        </router-link>
      </v-card-actions>
    </v-card>

    <v-card
      class="text-center"
      title="Or try the daily word!"
      text="This button will take you to the daily wordle. You can play as many as you want, and your stats will be tracked."
      variant="outlined"
    >
      <v-card-actions class="justify-center">
        <router-link to="/wordoftheday">
          <v-btn> Daily Word </v-btn>
        </router-link>
      </v-card-actions>
    </v-card>

    <v-card
      class="text-center"
      title="Read the instructions"
      text="This button will take you to the instructions page. You can read about how to play the game."
      variant="outlined"
    >
      <v-card-actions class="justify-center">
        <router-link to="/instructions">
          <v-btn> How To Play</v-btn>
        </router-link>
      </v-card-actions>
    </v-card>
  </v-container>
</template>
<script lang="ts" setup>
import { RouterLink } from 'vue-router'
</script>
