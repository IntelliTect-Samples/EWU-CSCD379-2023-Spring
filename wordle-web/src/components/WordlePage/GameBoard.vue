<!--
---- The area of the screen where the user's guesses are displayed.
--->

<template>
  <GameBoardRow v-for="word in game.guesses" :key="word.key" :word="word" />
</template>

<script setup lang="ts">
import type { WordleGame } from '@/scripts/wordleGame'
import GameBoardRow from '@/components/WordlePage/GameBoardRow.vue'

defineProps<{
  game: WordleGame
}>()
</script>
