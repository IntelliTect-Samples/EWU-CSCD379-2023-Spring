<template>
  <h1>Word Editor</h1>
  <v-card>
    <UpdateWordList />
    <WordFlag />
    <WordList />
  </v-card>
</template>

<script setup lang="ts">
import UpdateWordList from '../components/UpdateWordList.vue'
import WordList from '../components/WordList.vue'
import WordFlag from '../components/WordFlag.vue'
</script>
