<template>
  <WordleGame :isWordOfTheDay="false" :wordOfTheDayDate="date"></WordleGame>
</template>

<script setup lang="ts">
import WordleGame from '@/components/WordleGame.vue'

const date = '' //fixes error in build
</script>
