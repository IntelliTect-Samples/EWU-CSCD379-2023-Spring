<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import HelloWorld from './components/HelloWorld.vue'
</script>

<template>
  <header>
    <nav>
      <RouterLink to="/">Home</RouterLink>
      <RouterLink to="/game">Game(s)?</RouterLink>
    </nav>
  </header>

  <RouterView />
</template>

<style scoped>
    header {
      display: flex;
      position: fixed;
      top: 0;
      width: 100%;
      align-items: center;
    }
    nav {
      color: orangered;
    }
</style>
