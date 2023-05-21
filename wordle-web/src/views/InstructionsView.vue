<template>
  <v-card>
    <v-card-title>How To Play</v-card-title>
    <v-card-text>
      <p>Guess the Wordle in 6 tries.</p>
      <p>Each guess must be a valid 5-letter word.</p>
      <p>The color of the tiles will change to show how close your guess was to the word.</p>
    </v-card-text>
  </v-card>

  <v-card
    title="For example"
    subtitle="The letter 'W' is in the word and in the right spot."
    variant="outlined"
  >
    <v-card-text>
      <LetterButton :letter="correct" />
    </v-card-text>
  </v-card>

  <v-card subtitle="The letter 'I' is in the word but in the wrong spot." variant="outlined">
    <v-card-text>
      <LetterButton :letter="misplaced" />
    </v-card-text>
  </v-card>

  <v-card subtitle="The letter 'U' is not in the word in any spot." variant="outlined">
    <v-card-text>
      <LetterButton :letter="incorrect" />
    </v-card-text>
  </v-card>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { Letter } from '@/scripts/letter'
import { LetterStatus } from '@/scripts/letter'

const correct = new Letter('w', LetterStatus.Correct)
const misplaced = new Letter('i', LetterStatus.Misplaced)
const incorrect = new Letter('c', LetterStatus.Wrong)
</script>
