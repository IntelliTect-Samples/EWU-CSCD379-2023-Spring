<template>
  <LetterBase :char="letter.char" :color="letter.color" />
</template>

<script setup lang="ts">
import type { Letter } from '@/scripts/letter'
import LetterBase from './LetterBase.vue'

export interface Props {
  letter: Letter
}

defineProps<Props>()
</script>
