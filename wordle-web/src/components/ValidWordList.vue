<template>
  <v-select :items="items" :label="labelText"></v-select>
</template>

<script setup lang="ts">
export interface Props {
  items?: string[]
  labelText: string
}

const props = defineProps({
  items: {
    type: Array,
    default: []
  },
  labelText: {
    type: String,
    default: 'Valid Words'
  }
})
</script>
