<template>
  <v-row
    class="justify-center"
    v-for="(word, rowIndex) in game.guesses"
    :key="`row-${rowIndex}`"
    dense
  >
    <v-col v-for="(letter, colIndex) in word.letters" :key="`col-${colIndex}`" cols="auto">
      <LetterResult :letter="letter" @click="emitLetterClick(letter)" />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import LetterResult from '@/components/LetterResult.vue'
import type { Letter } from '@/scripts/letter'
import type { WordleGame } from '@/scripts/wordleGame'

defineProps<{
  game: WordleGame
}>()

const emit = defineEmits<{
  (event: 'letterClick', value: Letter): void
}>()

function emitLetterClick(letter: Letter) {
  emit('letterClick', letter)
}
</script>
