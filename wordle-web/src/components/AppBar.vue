<template>
    <v-app-bar >

      <img alt="books logo" class="logo" src="@/assets/books.png" width="50" height="50" color="white" />

      <v-app-bar-title>The Good Word</v-app-bar-title>

      <v-btn icon="mdi-arrow-right-bold-hexagon-outline" @click.stop="settings = !settings"></v-btn>

      <v-app-bar-nav-icon @click.stop="menu = !menu"></v-app-bar-nav-icon>

    </v-app-bar>

    <v-navigation-drawer title="Settings" v-model="settings" location="left" app>

      <v-list>
          <v-list-item title="Themes"></v-list-item>
      </v-list>

      <v-divider></v-divider>
      
      <v-list density="compact">
          <v-list-item>
              <v-btn>Light Mode</v-btn>
          </v-list-item>
              
          <v-list-item>
              <v-btn>Dark Mode</v-btn>
          </v-list-item>

          <v-list-item>
              <v-btn>Cowboy</v-btn>
          </v-list-item>

          <v-list-item>
              <v-btn>Aqua</v-btn>
          </v-list-item>

      </v-list>

    </v-navigation-drawer>

    <v-navigation-drawer v-model="menu" location="right" app>
      <v-list>
          <v-list-item title="Menu"></v-list-item>
      </v-list>

      <v-divider></v-divider>

      <v-list density="compact">
          <v-list-item>
              <v-btn to="/">Home</v-btn>
          </v-list-item>
              
          <v-list-item>
              <v-btn to="/about">About</v-btn>
          </v-list-item>

          <v-list-item>
              <v-btn to="/wordle">Play Game</v-btn>
          </v-list-item>
      </v-list>
      
    </v-navigation-drawer>
    
</template>


<script lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs';


  const theme = useTheme()

  function toggleCowboy() {
    theme.global.name.value = 'cowboy'
  }

  function toggleAqua() {
    theme.global.name.value = 'aqua'
  }

  function toggleDark() {
    theme.global.name.value = 'dark'
  }

  function toggleLight() {
    theme.global.name.value = 'light'
  }

  export default {
      data: () => ({
          menu: false,
          settings: false,
      }),

      watch: {
          group () {
              this.menu = false
              this.settings = false
          }
      }
  }
  
</script>