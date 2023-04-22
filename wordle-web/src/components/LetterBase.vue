<template>
  <v-btn height="65" variant="outlined" :color="props.color" @click="playAudio">
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

var audio = new Audio('../src/assets/zapsplat_multimedia_button_click_bright_003_92100.mp3')
audio.volume = 0.4

function playAudio() {
  audio.play()
}
</script>
