<template>
  <v-btn class="gradient-btn" :color="props.color">
    {{ props.char }}
  </v-btn>
</template>

<style>
.gradient-btn {
  background: linear-gradient(to right, #0000005d, #09476b33);
}
</style>

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
