<template>
  <v-row class="justify-center mt-3" dense v-for="(word, r) in game.guesses" :key="r">
    <v-col cols="auto" v-for="(letter, c) in word.letters" :key="`${r}-${c}`">
      <LetterButton  :letter="letter" @click="letterClick(letter)" />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import type { Letter } from '@/scripts/letter'
import type { WordleGame } from '@/scripts/wordleGame'

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
