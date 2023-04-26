<style scoped>
  .charButton {
    background: rgb(22,21,21);
    background: linear-gradient(345deg, rgba(22,21,21,1) 69%, rgba(75,75,75,1) 100%);  }
</style>

<template>
  <v-btn
    class="charButton"
    elevation="8"
    min-size="x-small"
    size="small"
    height="50"
    variant="outlined"
    :color="props.color"
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
