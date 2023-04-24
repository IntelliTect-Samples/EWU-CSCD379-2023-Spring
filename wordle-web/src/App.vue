<template>
  <div>
    <NavBar class="ma-10" />

    <RouterView />
  </div>
</template>

<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import HelloWorld from './components/HelloWorld.vue'
import NavBar from '@/components/NavBar.vue'
</script>
