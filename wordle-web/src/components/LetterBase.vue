<template>
  <v-btn :class="`${useDarkText ? 'text-black' : ''}`" :size="size" elevation="8" :color="props.color">
    <b>{{ props.char }}</b>
  </v-btn>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import {useDisplay, useTheme} from 'vuetify'

export interface Props {
  char?: string
  color?: string
}

const props = withDefaults(defineProps<Props>(), {
  char: '?',
  color: 'grey'
})

const { mobile, xs } = useDisplay()
const { name } = useTheme();

const size = computed(() => {
  if (mobile.value && xs.value) {
    return 'x-small'
  }
  return 'default'
})

const useDarkText = computed(() => {
  return name.value !== 'dark'
})
</script>

<style scoped>
.v-btn:hover {
  background-position: right center;
  text-decoration: none;
}
.v-btn {
  background-image: linear-gradient(to right, rgba(var(--v-theme-surface), 0.9) 0%, rgba(var(--v-theme-surface), 0.5) 50%, rgba(var(--v-theme-primary), 0.8) 100%);
  transition: 0.5s;
  background-size: 200% auto;
  display: block;
}
</style>
