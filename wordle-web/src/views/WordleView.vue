<template>
  <WordleGame :isWordOfTheDay="isWordOfTheDay" :wordOfTheDayDate="wordOfTheDayDate"></WordleGame>
</template>

<script setup lang="ts">
import WordleGame from '@/components/WordleGame.vue'

const isWordOfTheDay = false;
const wordOfTheDayDate = null as string | null;
</script>
