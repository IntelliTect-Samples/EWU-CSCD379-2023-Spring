<template>
  <v-container>
    <div class="d-flex justify-center">Welcome!</div>
    <v-card
      title="Try a random word!"
      text="This button will take you to a random wordle. You can play as many as you want, and your stats will be tracked."
      variant="outlined"
    >
      <v-card-actions>
        <router-link to="/wordle">
          <v-btn> Click Me </v-btn>
        </router-link>
      </v-card-actions>
    </v-card>
    <v-card
      title="Or try the daily word!"
      text="This button will take you to the daily wordle. You can play as many as you want, and your stats will be tracked."
      variant="outlined"
    >
      <v-card-actions>
        <router-link to="/wordoftheday">
          <v-btn> Click Me </v-btn>
        </router-link>
      </v-card-actions>
    </v-card>
  </v-container>
</template>
<script lang="ts" setup>
import { RouterLink } from 'vue-router'
</script>
