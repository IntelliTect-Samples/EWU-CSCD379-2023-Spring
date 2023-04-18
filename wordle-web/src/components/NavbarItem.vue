<template>
    <nav>
      <v-app-bar app color="Secondary" dark>
        <v-app-bar-title>
          <p class="text-h6 mb-1">Wor·dle</p>
        </v-app-bar-title>

        <!-- Home Button -->
        <v-app-bar-nav-icon>
          <v-btn to="/" icon>
            <v-icon>mdi-home</v-icon>
          </v-btn>
        </v-app-bar-nav-icon>
  
        <!-- Help Menu -->
        <v-app-bar-nav-icon>
          <HelpMenu></HelpMenu>
        </v-app-bar-nav-icon>
  
        <!-- Leader board -->
        <v-app-bar-nav-icon>
          <LeaderBoard></LeaderBoard>
        </v-app-bar-nav-icon>

        <!-- Settings -->
        <v-app-bar-nav-icon>
            <v-icon>mdi-hamburger</v-icon>
        </v-app-bar-nav-icon>
      </v-app-bar>
    </nav>
  </template>
  
  <script lang="ts">
  import { defineComponent } from "vue";
  import HelpMenu from "./HelpMenuItem.vue"
  import LeaderBoard from "./LeaderBoardItem.vue";
  import { VAppBar, VAppBarTitle, VAppBarNavIcon } from "vuetify/components";
  
  export default defineComponent({
    components: {
      HelpMenu,
      LeaderBoard,
      VAppBar,
      VAppBarTitle,
      VAppBarNavIcon
    },
  });
  </script>
  