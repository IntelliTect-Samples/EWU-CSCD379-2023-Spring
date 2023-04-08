<template>
    <nav>
      <v-app-bar app color="Secondary" dark>
        <v-toolbar-title>
          <p class="text-h6 mb-1">Wor·dle</p>
        </v-toolbar-title>
  
        <!-- Home Button -->
        <v-toolbar-item>
          <v-btn to="/" icon>
            <v-icon>mdi-home</v-icon>
          </v-btn>
        </v-toolbar-item>
  
        <!-- Help Menu -->
        <v-toolbar-item>
          <HelpMenu></HelpMenu>
        </v-toolbar-item>
  
        <!-- Leaderboard -->
        <v-toolbar-item>
          <Leaderboard></Leaderboard>
        </v-toolbar-item>
      </v-app-bar>
    </nav>
  </template>
  
  <script lang="ts">
  import { defineComponent } from "vue";
  import HelpMenu from "@/components/HelpMenu.vue";
  import Leaderboard from "@/components/Leaderboard.vue";
  
  export default defineComponent({
    components: {
      HelpMenu,
      Leaderboard,
    },
  });
  </script>
  