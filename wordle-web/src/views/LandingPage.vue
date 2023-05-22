<template>
    
    
    <v-container>
        <div class="d-flex justify-center bg-secondary text-h6" style="margin:5%;">Wordle</div>
        
        <v-row style="text-align: center; margin: 16px;">
            <v-col>
                <RouterLink to="/wordle" class="d-flex justify-center">
                    <v-card style="min-width: 350px; margin: 16px;">
                        <v-card-title>Random Wordle</v-card-title>
                        <v-row style="margin: 8px;">
                            <v-card-text style="padding: 8px;">- Random Wordles</v-card-text>
                        </v-row>
                        <v-row style="margin: 8px;">
                            <v-card-text style="padding: 8px;">- Increase Your Stats</v-card-text>
                        </v-row>
                        <v-row style="margin: 8px;">
                            <v-card-text style="padding: 8px;">- Mostly For Fun</v-card-text>
                        </v-row>
                    </v-card>
                </RouterLink>
            </v-col>
            <v-col>
                <RouterLink to="/wordoftheday" class="d-flex justify-center">
                    <RouterLink to="/wordle">
                    <v-card style="min-width: 350px; margin: 16px;">
                        <v-card-title>Daily Wordle</v-card-title>
                        <v-row style="margin: 8px;">
                            <v-card-text style="padding: 8px;">- One Wordle Per Day</v-card-text>
                        </v-row>
                        <v-row style="margin: 8px;">
                            <v-card-text style="padding: 8px;">- View Daily Data</v-card-text>
                        </v-row>
                        <v-row style="margin: 8px;">
                            <v-card-text style="padding: 8px;">- Also Mostly For Fun</v-card-text>
                        </v-row>
                    </v-card>
                </RouterLink>
                </RouterLink>
            </v-col>
              
    </v-row>
    </v-container>
  </template>
  <script lang="ts" setup>
import { RouterLink } from 'vue-router';
</script>