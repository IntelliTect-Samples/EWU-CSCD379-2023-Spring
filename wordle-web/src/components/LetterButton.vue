<template>
  <LetterBase :char="props.letter.char" :color="props.letter.color" v-bind="$attrs"></LetterBase>
</template>

<script lang="ts">
export default {
  inheritAttrs:false
}
</script>

<script setup lang="ts">
import type { Letter} from '@/scripts/letter'
import LetterBase from './LetterBase.vue'


export interface Props {
  letter: Letter
}

const props = defineProps<Props>()

</script>
