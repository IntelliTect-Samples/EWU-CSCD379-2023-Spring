<template>
  <v-dialog transition="dialog-bottom-transition">
    <template v-slot:activator="{ props }">
      <v-btn
        color="teal"
        v-bind="props"
        style="background-image: var(--btn-gradient)"
        class="elevation-7"
        v-on:keydown.enter.prevent
        >{{ WordsService.possibleWords.size }}</v-btn
      >
    </template>
    <template v-slot:default="{ isActive }">
      <v-card class="mx-auto">
        <v-card-title color="correct" title="Available Words"></v-card-title>
        <v-card-text>
          <v-list density="compact">
            <v-list-item v-for="(word, i) in WordsService.possibleWords" :key="i" :value="word">
              <v-list-item-title @click=";(isActive.value = false), sendGuess(word)">
                {{ word }}
              </v-list-item-title>
            </v-list-item>
          </v-list>
        </v-card-text>
        <v-card-actions class="justify-end">
          <v-btn variant="text" @click="isActive.value = false">Close</v-btn>
        </v-card-actions>
      </v-card>
    </template>
  </v-dialog>
</template>

<script setup lang="ts">
import { WordsService } from '@/scripts/wordsService'

const emits = defineEmits<{
  (event: 'inputGuess', value: string): void
}>()

function sendGuess(word: string) {
  emits('inputGuess', word)
}
</script>
