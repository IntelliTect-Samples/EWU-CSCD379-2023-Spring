<template>
  <v-btn
    elevation="10"
    :color="props.color"
    style="background-image: var(--btn-gradient) !important"
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
