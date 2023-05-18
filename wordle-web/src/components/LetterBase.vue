<template>
  <v-btn
    elevation="10"
    :color="props.color"
    style="background-image: var(--btn-gradient) !important"
    @click="playButtonSound"
    :height="display.xs ? '30' : display.sm ? '40' : '50'"
    :size="display.xs ? 'x-small' : display.sm ? 'small' : undefined"
    :class="display.xs ? 'letter-small' : ''"
  >
    {{ props.char }}
  </v-btn>
</template>

<script setup lang="ts">
export interface Props {
  char?: string
  color?: string
}

// import FastPlastic1 from '@/assets/sounds/FastPlastic1.mp3'
// import Bright1 from '@/assets/sounds/Bright1.mp3'
import Bright2 from '@/assets/sounds/Bright2.mp3'
import { Services } from '@/scripts/services'
import { inject, reactive } from 'vue'
import { useDisplay } from 'vuetify/lib/framework.mjs'

const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>

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

<style scoped>
.v-btn {
  font-size: 12pt;
}

.letter-small {
  min-width: 20px;
  padding: 0;
}
</style>