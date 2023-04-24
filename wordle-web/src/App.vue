<template>
  <header>
    <div class="wrapper">
      <nav>
        <NavBar class="ma-10"></NavBar>
      </nav>
    </div>
  </header>

  <RouterView />
</template>

<script setup lang="ts">
import NavBar from './components/NavBar.vue'
</script>
