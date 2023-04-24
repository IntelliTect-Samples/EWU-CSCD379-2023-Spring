<template>
  <v-btn :class="`${useDarkText ? 'text-black' : ''}`" :size="size" elevation="8" :color="color">
    <b>{{ char }}</b>
  </v-btn>
</template>

<script setup lang="ts">
import { computed, ref } from 'vue'
import { useDisplay, useTheme } from 'vuetify'

export interface Props {
  char?: string
  color?: string
}

withDefaults(defineProps<Props>(), {
  char: '?',
  color: 'default'
})
let mobileDisplay = ref(false)
let xsDisplay = ref(false)
try {
  const { mobile, xs } = useDisplay()
  mobileDisplay.value = mobile.value
  xsDisplay.value = xs.value
} catch (e) {
  // Expected failure in Jest tests
  // "Error: Could not find Vuetify display injection"
}

let nameTheme = ref('dark')
try {
  const { name } = useTheme()
  nameTheme.value = name.value
} catch (e) {
  // Expected failure in Jest tests
  // "Error: Could not find Vuetify theme injection"
}

const size = computed(() => {
  if (mobileDisplay.value && xsDisplay.value) {
    return 'x-small'
  }
  return 'default'
})

const useDarkText = computed(() => {
  return nameTheme.value !== 'dark'
})
</script>

<style scoped>
.v-btn:hover {
  background-position: right center;
  text-decoration: none;
}
.v-btn {
  background-image: linear-gradient(
    to right,
    rgba(var(--v-theme-surface), 0.9) 0%,
    rgba(var(--v-theme-surface), 0.5) 50%,
    rgba(var(--v-theme-primary), 0.8) 100%
  );
  transition: 0.5s;
  background-size: 200% auto;
  display: block;
}
</style>
