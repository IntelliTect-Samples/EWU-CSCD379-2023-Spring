<template>
  <div class="mt-5 pt-5 mb-3">
    <v-row class="justify-center" dense v-for="(word, r) in game.guesses" :key="r">
      <v-col cols="auto" v-for="(letter, c) in word.letters" :key="`${r}-${c}`">
        <LetterButton
          height="50px"
          width="50px"
          min-height="20px"
          min-width="20px"
          :letter="letter"
          @click="letterClick(letter)"
          :elevation="10"
        />
      </v-col>
    </v-row>
  </div>
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
