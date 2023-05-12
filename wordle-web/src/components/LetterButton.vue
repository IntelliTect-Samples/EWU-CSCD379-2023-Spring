<template>
  <v-btn
    :color="letter.color"
    label
    outlined
    :height="display.xs ? '30' : display.sm ? '40' : '50'"
    :size="display.xs ? 'x-small' : display.sm ? 'small' : undefined"
    :elevation="letter.status == LetterStatus.NotGuessed ? 2 : 4"
    :class="display.xs ? 'letter-small' : ''"
  >
    {{ letter.char.toUpperCase() }}
  </v-btn>
</template>

<script setup lang="ts">
import { Letter, LetterStatus } from '@/scripts/letter'
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
  letter: Letter
}

defineProps<Props>()
</script>

<style scoped>
.v-btn {
  font-size: 1.2rem;
}

.letter-small {
  min-width: 20px;
  padding: 0;
}
</style>
