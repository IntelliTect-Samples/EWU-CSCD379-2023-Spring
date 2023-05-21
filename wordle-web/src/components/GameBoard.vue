<template>
  <GameBoardRow v-for="(word, rowIndex) in game.guesses" :key="`row-${rowIndex}`" :word="word" />
</template>

<script setup lang="ts">
import type { WordleGame } from '@/scripts/wordleGame'
import GameBoardRow from '@/components/GameBoardRow.vue'

defineProps<{
  game: WordleGame
}>()
</script>
