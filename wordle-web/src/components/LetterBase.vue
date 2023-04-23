<template>
  <v-btn height="65" variant="outlined" :color="props.color" @click="playAudio">
    {{ props.char }}
  </v-btn>
</template>

<script setup lang="ts">
import * as tone from '@/components/audio/click.mp3'
export interface Props {
  char?: string
  color?: string
}

const props = withDefaults(defineProps<Props>(), {
  char: '?',
  color: 'grey'
})

var audio = new Audio(tone.default)
audio.volume = 0.4

function playAudio() {
  audio.play()
}
</script>
