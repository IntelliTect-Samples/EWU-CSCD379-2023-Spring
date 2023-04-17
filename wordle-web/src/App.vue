<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import NavBar from '@/components/NavBar.vue'
</script>

<template>
  <v-app>
    
    <NavBar />
    
    <v-main>
      <RouterView />
    </v-main>
    
  </v-app>
</template>

<style scoped>
.v-main {
  align-self: center;
  padding: 3rem 3rem;
  max-width: 70vw;
  min-width: 600px;
}

@media (min-width: 1024px) {

}
</style>
