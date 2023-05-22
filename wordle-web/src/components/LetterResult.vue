<template>
  <v-btn
    :color="color"
    label
    outlined
    :height="display.xs ? '30' : display.sm ? '40' : '50'"
    :size="display.xs ? 'x-small' : display.sm ? 'small' : 'large'"
    :elevation="status == LetterStatus.NotGuessed ? 0 : 4"
  >
    {{ char.toUpperCase() }}
  </v-btn>
</template>

<script setup lang="ts">
import { LetterStatus } from '@/scripts/letter'
import { Services } from '@/scripts/services'
import { inject } from 'vue'
import { reactive } from 'vue'
import { useDisplay } from 'vuetify'

// Add this to make testing work because useDisplay() throws an error when testing
// Wrap useDisplay in a function so that it doesn't get called during testing.
const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>

interface Props {
  char: string
  color: string
  status: LetterStatus
}

defineProps<Props>()
</script>

<style scoped>
.v-btn {
  font-size: 1.2rem;
}
</style>
