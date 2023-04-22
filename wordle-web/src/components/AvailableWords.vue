<!-- AvailableWords.vue -->
<template>
    <div>
      <h2>Available Words:</h2>
      <ul>
        <li v-for="(word, index) in availableWords" :key="index">
          {{ word }}
        </li>
      </ul>
    </div>
  </template>
  
  <script setup lang="ts">
  import { ref, watch } from "vue";
  import { WordsService } from "@/scripts/wordsService";
  import type { Letter } from "@/scripts/letter";
  
  const props = defineProps<{
    guessedLetters: Letter[];
  }>();
  
  const availableWords = ref<string[]>([]);
  
  watch(
    () => props.guessedLetters,
    (guessedLetters) => {
      const guessedChars = guessedLetters.map((letter) => letter.char);
      availableWords.value = WordsService.getWords().filter((word) =>
        guessedChars.every((char) => word.includes(char))
      );
    },
    { immediate: true }
  );
  </script>
  