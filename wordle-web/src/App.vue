<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import NavBar from '@/components/NavBar.vue'
</script>

<template>
  <div class="main">
    
    <NavBar />

    <div class="content">
      <RouterView />
    </div>

  </div>

</template>

<style scoped>

  
.main {
  display: flex;
  flex-direction: column;

  min-height: 100vh;
  width: auto;
  text-align: center;
}

.content {
  align-self: center;
  padding: 3rem 3rem;
  max-width: 80vw;
  min-width: 600px;
}

@media (min-width: 1024px) {

}
</style>
