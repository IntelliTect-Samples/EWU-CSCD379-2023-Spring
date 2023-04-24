<style>
.charButton {
  background: rgb(0, 0, 0);
  background: radial-gradient(circle, #252525, #161616, #000000);
}
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
