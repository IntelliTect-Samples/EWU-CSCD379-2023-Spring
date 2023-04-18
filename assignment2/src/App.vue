<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <header>
    <nav>
      <RouterLink to="/">Home</RouterLink>
      <RouterLink to="/game">Game(s)</RouterLink>
    </nav>
  </header>

  <RouterView />
</template>

<style scoped>
    header{
      position: fixed;
      top: 0;
      width: 100%;
    }
    /* nav {
      width: 100%;
      font-size: 12px;
      text-align: center;
    }
    nav a.router-link-exact-active {
      color: orangered;
    }
    nav a.router-link-exact-active:hover {
      background-color: black;
    }
    nav a:hover {
      background-color: black;
    }
    nav a {
      color: orangered;
      display: inline-block;
      padding: 0 1rem;
      border-left: 1px solid var(--color-border);
    }
    nav a:first-of-type {
      border: 0;
    } */
</style>
