<template>
  <v-btn 
     class="charButton"
     elevation="8"
     min-size="x-small"
     size="small"
     height="50"
     width="75"
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
  color: 'primary'
})
</script>
