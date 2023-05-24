<template>
  <v-container>
    <div class="justify-center text-h4 text-center" style="color: #272727">
      Lets Play Wordle!
      <v-row style="text-align: center; margin: 16px">
        <v-col>
          <RouterLink to="/wordle" class="d-flex justify-center">
            <v-card class="bg-primary" style="min-width: 350px; margin: 16px">
              <v-card-title class="text-h5">Play Random Wordle</v-card-title>
              <v-row style="margin: 8px">
                <v-card-text class="text-h6" style="padding: 8px">-Words are random</v-card-text>
              </v-row>
              <v-row style="margin: 8px">
                <v-card-text class="text-h6" style="padding: 8px"
                  >-Boost yourself up the leaderboard</v-card-text
                >
              </v-row>
              <v-row style="margin: 8px">
                <v-card-text class="text-h6" style="padding: 8px">-Unlimted attempts</v-card-text>
              </v-row>
            </v-card>
          </RouterLink>
        </v-col>
        <v-col>
          <RouterLink to="/wordoftheday" class="d-flex justify-center">
            <v-card class="bg-primary" style="min-width: 350px; margin: 16px">
              <v-card-title class="text-h5">Daily Wordle</v-card-title>
              <v-row style="margin: 8px">
                <v-card-text class="text-h6" style="padding: 8px">-One word a day </v-card-text>
              </v-row>
              <v-row style="margin: 8px">
                <v-card-text class="text-h6" style="padding: 8px"
                  >-See your daily results</v-card-text
                >
              </v-row>
              <v-row style="margin: 8px">
                <v-card-text class="text-h6" style="padding: 8px"
                  >-Can you guess the word 10 days in a row?</v-card-text
                >
              </v-row>
            </v-card>
          </RouterLink>
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>
<script lang="ts" setup>
import { RouterLink } from 'vue-router'
</script>
