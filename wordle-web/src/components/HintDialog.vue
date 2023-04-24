<template>
  <div>
    <v-dialog width="auto">
      <template v-slot:activator="{ props }">
        <v-btn color="primary" v-bind="props">
          {{ game.list.length }}
        </v-btn>
      </template>

      <v-card>
        <v-row v-for="word in game.list" :key="word">
          <v-btn @click="enterWord(word)" color="primary">
            {{ word }}
          </v-btn>
        </v-row>
      </v-card>
    </v-dialog>
  </div>
</template>

<script setup lang="ts">
import type { WordleGame } from '@/scripts/wordleGame'
import { Word } from '@/scripts/word'
import type { Letter } from '@/scripts/letter'

defineProps<{
  game: WordleGame
  guessedLetters: Letter[]
}>()

function enterWord(word: string) {
  const guess = new Word(word)
  for (const letter of guess.letters) {
    letterClick(letter)
  }
}

const emits = defineEmits<{
  (event: 'letterClick', value: Letter): void
}>()

function letterClick(letter: Letter) {
  emits('letterClick', letter)
}
</script>
