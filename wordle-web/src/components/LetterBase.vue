<template>
  <v-btn
    class="gradient-btn"
    :color="props.color"
    :style="{ 'background-image': 'linear-gradient(to right, #ffffff38, #09476b3b) !important' }"
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
