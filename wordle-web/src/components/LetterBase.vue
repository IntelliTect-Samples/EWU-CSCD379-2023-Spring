<template>
  <v-btn :color="props.color" class="rounded-0 pa-0">
    {{ props.char.toUpperCase() }}
  </v-btn>
</template>

<script setup lang="ts">
export interface Props {
  char?: string
  color?: string
}

const props = withDefaults(defineProps<Props>(), {
  char: '?',
  color: 'grey'
})
</script>
