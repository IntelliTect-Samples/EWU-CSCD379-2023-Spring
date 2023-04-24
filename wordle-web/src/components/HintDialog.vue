<template>
  <div>
    <v-dialog width="300px">
      <template v-slot:activator="{ props }">
        <v-flex justify-center>
          <div class="m-5 py-3">
            <v-btn class="m-5" elevation="24" height="30px" color="primary" v-bind="props">
              {{ game.list.length }}
            </v-btn>
          </div>
        </v-flex>
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
