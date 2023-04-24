<template>
  <LetterBase
    :char="props.letter.char"
    :color="props.letter.color"
    class="gradient-key"
  ></LetterBase>
</template>

<script setup lang="ts">
import type { Letter } from '@/scripts/letter'
import LetterBase from './LetterBase.vue'

export interface Props {
  letter: Letter
}

const props = defineProps<Props>()
</script>

<style>
.gradient-key {
  background: linear-gradient(to right, grey, blue);
}
</style>
