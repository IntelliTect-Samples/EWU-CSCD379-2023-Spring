<style scoped>
.gradient {
  background-image: radial-gradient(rgba(121, 121, 121, 0), rgba(143, 143, 143, 0.2)) !important;
}
</style>
<template>
  <LetterBase
    height="40px"
    rounded="0"
    :char="props.letter.char"
    :color="props.letter.color"
    class="gradient"
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
