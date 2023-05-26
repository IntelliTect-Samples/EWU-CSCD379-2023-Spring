<template>
  <v-container>
    <!-- <div class="d-flex justify-center">Welcome!</div> -->

    <!-- <v-card
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

    <v-card
      title="Read the instructions"
      text="This button will take you to the instructions page. You can read about how to play the game."
      variant="outlined"
    >
      <v-card-actions>
        <router-link to="/instructions">
          <v-btn> Click Me </v-btn>
        </router-link>
      </v-card-actions>
    </v-card> -->

    <v-card
      title="Welcome!"
      text="We are so glad you could make it! This is a word game called Wordle. You can play a random wordle, or you can play the daily wordle. You can play as many as you want, and your stats will be tracked."
      variant="outlined"
    >
      <v-card-actions>
        <router-link to="/instructions">
          <v-btn> How To Play </v-btn>
        </router-link>

          <router-link to="/wordoftheday">
          <v-btn> Play Daily Word </v-btn>
        </router-link>

          <router-link to="/wordle">
          <v-btn> Play Random Word</v-btn>
        </router-link>
      </v-card-actions>
    </v-card>

  </v-container>
</template>
<script lang="ts" setup>
import { RouterLink } from 'vue-router'
</script>
