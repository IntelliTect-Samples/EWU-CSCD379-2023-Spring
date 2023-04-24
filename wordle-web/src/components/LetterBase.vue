<template>
  <v-card :color="props.color">
    <v-btn id="gradient" :elevation="10" @click="playSound">
      {{ props.char }}
    </v-btn>
  </v-card>
</template>

<style scoped>
#gradient {
  background-image: linear-gradient(
    to bottom right,
    rgba(0, 0, 0, 0.25),
    rgba(255, 255, 255, 0.25)
  );
  background-color: transparent;
}
</style>

<script setup lang="ts">
export interface Props {
  char?: string
  color?: string
}

function playSound() {
  //Sound Effect by UNIVERSFIELD from Pixabay
  const audio = new Audio(
    'https://cdn.pixabay.com/download/audio/2023/04/17/audio_b34c0f2e71.mp3?filename=soft-notice-146623.mp3'
  )
  audio.play()
}

const props = withDefaults(defineProps<Props>(), {
  char: '?',
  color: 'grey'
})
</script>

<script lang="ts">
export default {
  data: () => ({
    overlay: true
  })
}
</script>
