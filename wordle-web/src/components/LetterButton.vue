<template>
  <LetterBase :char="props.letter.char" :color="props.letter.color"> </LetterBase>
</template>

<script setup lang="ts">
import LetterBase from '@/components/LetterBase.vue'
import type { Letter } from '@/scripts/letter'
export interface Props {
  letter: Letter
}
const props = defineProps<Props>()
</script>
