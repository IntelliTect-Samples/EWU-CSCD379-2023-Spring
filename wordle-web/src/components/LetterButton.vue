<template>
  <v-btn
    :color="letter.color"
    label
    outlined
    :height="display.xs ? '30' : display.sm ? '40' : '50'"
    :size="display.xs ? 'x-small' : display.sm ? 'small' : 'large'"
  >
    {{ letter.char.toUpperCase() }}
  </v-btn>
</template>

<script setup lang="ts">
import type { Letter } from '@/scripts/letter'
import { ref } from 'vue'
import { useDisplay } from 'vuetify'

const display = ref(useDisplay())

interface Props {
  letter: Letter
}

defineProps<Props>()
</script>

<style scoped>
.v-btn {
  font-size: 1.2rem;
}
</style>
