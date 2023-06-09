<template>
  <WordleGame :isWordOfTheDay="true" :wordOfTheDayDate="date"></WordleGame>
</template>

<script setup lang="ts">
import WordleGame from '@/components/WordleGame.vue'
import { computed } from 'vue'
import { useRoute } from 'vue-router'

const route = useRoute()

const date = computed(() => {
  let date = route.query.date as string
  return date ?? null
})
</script>
