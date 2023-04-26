<template>
  <v-btn class="removeMin">
    <span class="font-weight-bold"> {{ props.char.toUpperCase() }} </span>
  </v-btn>
</template>

<script setup lang="ts">
export interface Props {
  char?: string
  color?: string
}
const props = withDefaults(defineProps<Props>(), {
  char: '?',
  color: 'default'
})
</script>

<style scoped>
.removeMin {
  min-width: 0;
}
</style>
