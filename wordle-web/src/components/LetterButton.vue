<template>
  <LetterBase
    :char="props.letter.char"
    :color="props.letter.color"
    :style="{ background: buttonGradient }"
  >
  </LetterBase>
</template>

<script setup lang="ts">
import LetterBase from '@/components/LetterBase.vue'
import type { Letter } from '@/scripts/letter'
import { computed } from 'vue'
export interface Props {
  letter: Letter
}
const props = defineProps<Props>()

const buttonGradient = computed(() => {
  return `linear-gradient(180deg, ${props.letter.color} 50%, rgba(120, 242, 44, 0.339))`
})
</script>
