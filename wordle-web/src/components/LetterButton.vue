<template>
  <LetterBase
    :char="props.letter.char"
    :color="props.letter.color"
    :style="{ background: buttonGradient }"
  ></LetterBase>
</template>

<script setup lang="ts">
import type { Letter } from '@/scripts/letter'
import LetterBase from './LetterBase.vue'
import { computed } from 'vue'

export interface Props {
  letter: Letter
}

const props = defineProps<Props>()

const buttonGradient = computed(() => {
  return `linear-gradient(45deg, ${props.letter.color} 40%, rgba(200, 100, 30, 0.8))`
})
</script>
