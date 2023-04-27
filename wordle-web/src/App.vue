<template>
  <AppBar class="app-bar" :style="{ zIndex: '1000', marginBottom: '16px' }" />
  <RouterView />
</template>

<script setup lang="ts">
import AppBar from './components/AppBar.vue'
</script>
