<template>
  <header>
    <div class="wrapper"></div>
  </header>
  <div class="ma-16"><NavigationBar /></div>
  <div><RouterView /></div>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router'
import NavigationBar from './components/NavigationBar.vue'
</script>

<style scoped>
header {
  line-height: 1.5;
  max-height: 100vh;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

nav {
  width: 100%;
  font-size: 12px;
  text-align: center;
  margin-top: 2rem;
}

nav a.router-link-exact-active:hover {
}

nav a {
  display: inline-block;
  padding: 0 1rem;
}
</style>
