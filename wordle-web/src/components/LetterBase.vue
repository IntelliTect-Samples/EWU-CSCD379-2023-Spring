<template>
  <v-btn id="gradient">
    {{ props.char }}
  </v-btn>
</template>

<style scoped>
#gradient{
  background: linear-gradient(to right, #2E3192, #1BFFFF)
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
