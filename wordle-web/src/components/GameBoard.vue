<template>
  <v-row dense class="justify-center" v-for="word in game.guesses" :key="word.text">
    <v-col cols="auto" v-for="letter in word.letters" :key="letter.char">
      <LetterButton :letter="letter" @click="letterClick(letter)"></LetterButton>
    </v-col>
  </v-row>
  <v-row>
    <v-col />
  </v-row>
</template>

<script setup lang="ts">
/** __vue_virtual_code_placeholder */
import type { WordleGame } from '@/scripts/wordleGame'
import LetterButton from '@/components/LetterButton.vue'
import type { Letter } from '@/scripts/letter'

export interface GameBoardProps {
  game: WordleGame
}

const props = defineProps<GameBoardProps>()

const emits = defineEmits<{
  (event: 'letterClick', value: Letter): void
}>()

function letterClick(letter: Letter) {
  emits('letterClick', letter)
}
</script>
