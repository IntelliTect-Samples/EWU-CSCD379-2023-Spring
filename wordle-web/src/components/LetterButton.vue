<template>
  <v-btn :color="letter.color" label height="50px" width="50px" outlined>
    {{ letter.char.toUpperCase() }}
  </v-btn>
</template>

<script setup lang="ts">
import type { Letter } from '@/scripts/letter'

export interface Props {
  letter: Letter
}

defineProps<Props>()
</script>

<style scoped>
.v-btn {
  font-size: 1.2rem;
}
</style>
