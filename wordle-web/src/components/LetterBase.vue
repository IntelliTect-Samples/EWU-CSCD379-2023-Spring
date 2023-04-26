<template>
  <v-btn
    elevation="10"
    :color="props.color"
    style="background-image: var(--btn-gradient) !important"
    @click="playButtonSound"
  >
    {{ props.char }}
  </v-btn>
</template>

<script setup lang="ts">
export interface Props {
  char?: string
  color?: string
}

import FastPlastic1 from '@/assets/sounds/FastPlastic1.mp3'
import Bright1 from '@/assets/sounds/Bright1.mp3'
import Bright2 from '@/assets/sounds/Bright2.mp3'

function playButtonSound() {
  const audio = new Audio(Bright2)
  audio.volume = 0.5
  audio.play()
}

const props = withDefaults(defineProps<Props>(), {
  char: '?',
  color: 'grey'
})
</script>
