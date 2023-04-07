<template>
  <main>
    <TheWelcome />
  </main>
  <v-card
        theme="dark"
      >
        <v-card-title> Home Page </v-card-title>

        <v-card-subtitle> Welcome to the home page! </v-card-subtitle>

        <v-card-actions>  

            <v-spacer />

            <v-btn
                varient="tonal"
                rounded="xl"
                color="#5865f2"
                elevation="24"
                to="/Game"
            >
             Game 
            </v-btn>

            <v-btn
                varient="tonal"
                rounded="xl"
                color="#5865f2"
                elevation="24"
                to="/about"
            >
             About 
            </v-btn>

        </v-card-actions>

      </v-card>
</template>

<script setup lang="ts">
import TheWelcome from '../components/TheWelcome.vue'
</script>
