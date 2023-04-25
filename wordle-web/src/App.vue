<template>
  <header>
    
    <div class="wrapper">
      <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
      <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
      <NavBar/>
    </div>
  </header>
  <nav-bar></nav-bar>
  <RouterView />
</template>

<script setup lang="ts">

import NavBar from '@/components/NavBar.vue'


</script>
