<template>
  <header>
    <div class="wrapper">
      <NavBar class="ma-10"></NavBar>
      
    </div>
  </header>

  <RouterView />
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()



import {NavBar} from '@/components/NavBar.vue'
</script>
