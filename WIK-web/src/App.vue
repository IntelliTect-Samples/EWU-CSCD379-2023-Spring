<template>
  <header>
    <div class="wrapper">
      <NavBar class="ma-10"></NavBar>
    </div>
  </header>

  <RouterView />
</template>

<script setup lang="ts">
import NavBar from '@/components/NavBar.vue'
</script>
