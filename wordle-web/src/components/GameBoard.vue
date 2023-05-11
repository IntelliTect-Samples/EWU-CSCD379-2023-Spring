<template>
  <h1 class="text-center">Timer: {{ timer }}</h1>
  <v-row
    class="justify-center"
    v-for="(word, rowIndex) in game.guesses"
    :key="`row-${rowIndex}`"
    dense
  >
    <v-col v-for="(letter, colIndex) in word.letters" :key="`col-${colIndex}`" cols="auto">
      <LetterResult :letter="letter" @click="letterClick(letter)" />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import LetterResult from '@/components/LetterResult.vue'
import type { Letter } from '@/scripts/letter'
import type { WordleGame } from '@/scripts/wordleGame'
import Axios from 'axios'
import type { VueCookies } from 'vue-cookies'

defineProps<{
  game: WordleGame
}>()

const emits = defineEmits<{
  (event: 'letterClick', value: Letter): void
}>()

function letterClick(letter: Letter) {
  emits('letterClick', letter)
}
</script>
