<!-- <template>

<v-card>
    <v-layout>

      <v-app-bar
        color="green"
        prominent
      >
        <v-app-bar-nav-icon variant="text" @click.stop="drawer = !drawer" ></v-app-bar-nav-icon>

        <v-toolbar-title>Better then Wordle</v-toolbar-title>

        <v-spacer></v-spacer>

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

        <v-btn variant="text" icon="mdi-dots-vertical"></v-btn>
      </v-app-bar>

      <v-navigation-drawer 
      z-index="top"
        class="opacity-100"
        color="black"
        v-model="drawer"
        location="top-start"
        temporary
      >
        <v-list
          :items="items"
        ></v-list>
      </v-navigation-drawer>

      <v-main style="height: 155px;">
        <v-card-text>
          <header>

    <div class="wrapper">
      <nav>
        
            <RouterLink to="/">Home</RouterLink> | <RouterLink to="/wordle">Wordle</RouterLink> |
            <RouterLink to="/about">About</RouterLink>
    
      </nav>
      <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
      <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
    </div>
  </header>

        </v-card-text>
      </v-main>
    </v-layout>
  </v-card>



  <RouterView />
</template> -->

<!-- <script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}

</script> -->

<!-- <script>
  export default {
    data: () => ({
      drawer: false,
      group: null,
      items: [
        {
          title: 'Home',
          value: 'Home',
        },
        {
          title: 'Better then Wordle',
          value: 'Better then Wordle',
        },
        {
          title: 'About',
          value: 'About',
        },
      
      ],
    }),

    watch: {
      group () {
        this.drawer = false
      },
    },
  }
</script> -->

<script setup lang="ts">
import { RouterView } from 'vue-router'
import NavBar from '@/components/NavigationBar.vue'
</script>

<template>
  <v-app>
    <NavBar />

    <v-main class="pb-0">
      <RouterView />
    </v-main>
  </v-app>
</template>

<style scoped>
.v-main {
  align-self: center;
  padding: 3rem 3rem;
  max-width: 60vw;
  min-width: 600px;
}
@media (min-width: 1024px) {
}
</style>