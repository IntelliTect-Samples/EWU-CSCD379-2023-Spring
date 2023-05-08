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
import { reactive, ref } from 'vue'
import { useDisplay } from 'vuetify'

// Add this to make testing work because useDisplay() throws an error when testing
let displayContent: ReturnType<typeof useDisplay>
try {
  displayContent = useDisplay()
} catch (e) {
  displayContent = { xs: ref(false), sm: ref(false) } as ReturnType<typeof useDisplay>
}
const display = reactive(displayContent)

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
