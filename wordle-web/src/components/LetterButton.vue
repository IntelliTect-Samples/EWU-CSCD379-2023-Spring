<template>
  <LetterBase
    class="gradient-btn"
    :char="props.letter.char"
    :color="props.letter.color"
  ></LetterBase>
</template>

<style>
.gradient-btn {
  background: linear-gradient(to right, #0000005d, #09476b33);
  color: white;
}
</style>

<script setup lang="ts">
import type { Letter } from '@/scripts/letter'
import LetterBase from './LetterBase.vue'

export interface Props {
  letter: Letter
}

const props = defineProps<Props>()
</script>
