<template>
  <v-btn :color="props.color" :style="{ 'background-image': 'var(--btn-gradient) !important' }">
    {{ props.char.toUpperCase() }}
  </v-btn>
</template>

<script setup lang="ts">
import { defineProps, withDefaults } from 'vue'

export interface Props {
  char?: string
  color?: string
}

const props = withDefaults(defineProps<Props>(), {
  char: '?',
  color: 'notGuessed'
})
</script>
