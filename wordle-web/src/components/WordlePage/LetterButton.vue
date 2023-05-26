<!--
---- Responsible for the design of the letter buttons, and the logic behind them.
--->

<template>
  <v-btn
    label
    outlined
    style="background-image: var(--btn-gradient) !important"
    @click="playButtonSound"
    :color="letter.color"
    :height="display.xs ? '30' : display.sm ? '40' : '50'"
    :size="display.xs ? 'x-small' : display.sm ? 'small' : 'large'"
    :elevation="letter.status == LetterStatus.NotGuessed ? 2 : 4"
    :class="display.xs ? 'letter-small' : ''"
  >
    {{ letter.char.toUpperCase() }}
  </v-btn>
</template>

<script setup lang="ts">
import { Letter, LetterStatus } from '@/scripts/letter'
import { Services } from '@/scripts/services/services'
import { inject } from 'vue'
import { reactive } from 'vue'
import { useDisplay } from 'vuetify'
import Bright2 from '@/assets/sounds/Bright2.mp3'
// import FastPlastic1 from '@/assets/sounds/FastPlastic1.mp3'
// import Bright1 from '@/assets/sounds/Bright1.mp3'

// Add this to make testing work because useDisplay() throws an error when testing
// Wrap useDisplay in a function so that it doesn't get called during testing.
const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>

interface Props {
  letter: Letter
}

defineProps<Props>()

function playButtonSound() {
  const audio = new Audio(Bright2)
  audio.volume = 0.5
  audio.play()
}
</script>

<style scoped>
.v-btn {
  font-size: 1.2rem;
}
.letter-small {
  min-width: 20px;
  padding: 0;
}
</style>
