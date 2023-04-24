<template>
  <v-btn class="shadow-5, elevation-10" id="gradient" :color="props.color">
    {{ props.char }}
  </v-btn>
</template>

<style scoped>
#gradient {
  background: linear-gradient(to right, #e1e1e1, #747474);
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
