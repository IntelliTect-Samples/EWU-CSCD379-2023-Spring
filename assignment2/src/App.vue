<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <nav>
    <v-btn prepend-icon="mdi-castle" variant="plain" to="/"> Wordle </v-btn>
    <v-btn icon="mdi-menu" variant="plain" to="/game" class="right"></v-btn>
    <v-btn icon="mdi-cog" variant="plain" to="/game" class="right"></v-btn>
  </nav>

  <RouterView />
</template>

<style scoped>
    nav {
      position: fixed;
      top: 0;
      left: 9%;
      width: 82%;
      border-bottom: 1px solid white;
      padding-top: 1rem;
      padding-bottom: .25rem;
    }
    nav a {
      font-size: 1.5rem;
      color: orangered;
      /*border-radius: 10%;*/
    }
    nav a:hover {
      background-color: black;
    }
    .right{
      float: right;
    }
</style>
