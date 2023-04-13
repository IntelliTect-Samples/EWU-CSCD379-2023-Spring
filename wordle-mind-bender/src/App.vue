<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <v-container fluid>
    <v-row>
      <v-col>
        <v-card color="grey-lighten-4" flat>
          <v-toolbar density="compact">
            <v-toolbar-title>Wordle Mind Bender</v-toolbar-title>
            <v-spacer></v-spacer>
            <v-btn to="/" class="ml-2"> Home </v-btn>
            <v-btn to="/about" class="ml-2"> About </v-btn>
            <v-btn to="/game" class="ml-2"> Game </v-btn>
          </v-toolbar>
        </v-card>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <RouterView />
      </v-col>
    </v-row>
  </v-container>
</template>