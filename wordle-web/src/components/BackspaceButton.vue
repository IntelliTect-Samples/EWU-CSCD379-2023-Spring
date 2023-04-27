<style scoped>
  .gradient {
    background-color: rgb(158, 158, 158);
    background-image: radial-gradient(rgba(121, 121, 121, 0), rgba(143, 143, 143, 0.2)) !important
  }
</style>
<template>
  <BackspaceIcon
    height="40px"
    width="70px"
    rounded="0"
    fill="#ffffff"
    class="gradient"
  ></BackspaceIcon>
</template>

<script setup lang="ts">
import type { Letter } from '@/scripts/letter'
import BackspaceIcon from './icons/BackspaceIcon.vue'

export interface Props {
  letter: Letter
}

const props = defineProps<Props>()
</script>
