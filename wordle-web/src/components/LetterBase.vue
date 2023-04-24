<template>
  <v-btn :style="setGradient()">
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
  color: 'grey-darken-1'
})

function setGradient(): string {
  if (props.color == 'correct') {
    return 'background: linear-gradient(white, green)'
  } else if (props.color == 'misplaced') {
    return 'background: linear-gradient(white, rgb(246,190,0))'
  } else if (props.color == 'wrong') {
    return 'background: linear-gradient(white, red)'
  }
  return 'background: linear-gradient(white, grey)'
}
</script>

<style></style>
