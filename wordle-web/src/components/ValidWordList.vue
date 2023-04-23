<template>
  <v-select v-model="guessword" :items="items" :label="labelText" return object></v-select>
</template>

<script setup lang="ts">
import { ref, watchEffect } from 'vue'
const guessword = ref('')

export interface Props {
  items?: string[]
  labelText: string
}

defineProps({
  items: {
    type: Array,
    // eslint-disable-next-line vue/require-valid-default-prop
    default: ''
  },
  labelText: {
    type: String,
    default: 'Words'
  }
})

const emit = defineEmits<{
  (validguess: 'change', value: string): void
}>()
function selectF() {
  console.log('guessword', guessword.value)
  emit('change', guessword.value)
}
watchEffect(() => selectF())
</script>
