<template>
  <v-row class="justify-center" dense v-for="(word, r) in game.guesses" :key="r">
    <v-col cols="auto" v-for="(letter, c) in word.letters" :key="`${r}-${c}`">
      <LetterButton
        :letter="letter"
        @click="letterClick(letter)"
        :width="btnSize"
        :height="btnSize"
        :variant="getVariant(letter)"
        class="text-h4 rounded-0"
      />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { LetterStatus, type Letter } from '@/scripts/letter'
import type { WordleGame } from '@/scripts/wordleGame'
import { computed } from 'vue'
import { useDisplay } from 'vuetify/lib/framework.mjs'

function getVariant(letter: Letter) {
  return letter.status === LetterStatus.NotGuessed ? 'outlined' : 'flat'
}
const props = defineProps<{
  game: WordleGame
}>()

const display = useDisplay()

const btnSize = computed(() => {
  let baseY = 52
  let maxY = display.width.value / (props.game.secretWord.length + 1)
  if (display.height.value > 700) {
    let scaledY = baseY * (display.height.value / 700)
    scaledY = Math.min(scaledY, maxY)
    return scaledY
  }
  return baseY
})

const emits = defineEmits<{
  (event: 'letterClick', value: Letter): void
}>()

function letterClick(letter: Letter) {
  emits('letterClick', letter)
}
</script>
