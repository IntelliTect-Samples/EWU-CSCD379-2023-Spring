<template>
  <div>
    <v-row dense class="justify-center" v-for="(word, r) in game.guesses" :key="r">
      <v-col cols="auto" v-for="(letter, c) in word.letters" :key="`${r}-${c}`">
        <LetterButton :letter="letter" height="60px" width="55px" />
      </v-col>
    </v-row>
  </div>
</template>

<script setup lang="ts">
import type { WordleGame } from '@/scripts/wordleGame'
import LetterButton from '@/components/LetterButton.vue'

defineProps<{
  game: WordleGame
}>()
</script>
