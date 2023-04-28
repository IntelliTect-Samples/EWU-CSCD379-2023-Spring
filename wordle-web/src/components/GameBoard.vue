<template>
  <v-row class="justify-center" dense v-for="(word, r) in game.guesses" :key="r">
    <v-col cols="auto" v-for="(letter, c) in word.letters" :key="`${r}-${c}`">
      <LetterButton
        :letter="letter"
        class="elevation-0 text-h6 font-weight-black rounded-sm"
        height="3.5rem"
        min-width="3.5rem"
        style="pointer-events: none"
      />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import type { WordleGame } from '@/scripts/wordleGame'

defineProps<{
  game: WordleGame
}>()
</script>
