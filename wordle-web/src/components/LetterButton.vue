<template>
  <v-btn
    :color="letter.color"
    label
    outlined
    :height="display?.xs ? '30' : display?.sm ? '40' : '50'"
    :size="display?.xs ? 'x-small' : display?.sm ? 'small' : 'large'"
  >
    {{ letter.char.toUpperCase() }}
  </v-btn>
</template>

<script setup lang="ts">
import type { Letter } from '@/scripts/letter'
import { inject } from 'vue'
import { reactive } from 'vue'
import { useDisplay } from 'vuetify'

// Add this to make testing work because useDisplay() throws an error when testing
// Wrap useDisplay in a function so that it doesn't get called during testing.
const display = inject('display', () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>

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
