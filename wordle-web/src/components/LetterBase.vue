<template>
  <v-btn
    :color="props.color"
    style="background-image: linear-gradient(to right, rgba(0,0,0,0.3), rgba(255,255,255,0.3) !important"
    elevation="5"
  >
    {{ props.char }}
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
