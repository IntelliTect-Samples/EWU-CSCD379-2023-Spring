<!-- LetterBase.vue -->
<template>
  <v-btn class="shadow-5 elevation-10" :style="{ background: keyGradient }">
    {{ props.char }}
  </v-btn>
</template>

<script setup lang="ts">
import { computed } from 'vue'

const keyGradient = computed(() => {
  switch (props.color) {
    case 'correct':
      return 'linear-gradient(to right, rgba(0, 128, 0, 0.3), rgba(0, 128, 0, 0.6))'
    case 'misplaced':
      return 'linear-gradient(to right, rgba(255, 255, 0, 0.3), rgba(255, 255, 0, 0.6))'
    case 'wrong':
      return 'linear-gradient(to right, rgba(255, 0, 0, 0.3), rgba(255, 0, 0, 0.6))'
    default:
      return 'linear-gradient(to right, rgba(128, 128, 128, 0.3), rgba(128, 128, 128, 0.6))'
  }
})

export interface Props {
  char?: string
  color?: string
}

const props = withDefaults(defineProps<Props>(), {
  char: '?',
  color: 'grey'
})
</script>
