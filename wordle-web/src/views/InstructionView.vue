<template>
  <v-card>
    <v-card-title>How to Play</v-card-title>
    <v-card-text>
      <p>
        Wordle is a game where you try to guess a five letter word. You have six guesses to get the
        word.
      </p>
      <p>
        After each guess, you will be shown which letters the letters that are correct and correctly
        placed <LetterButton :letter="correct" />,
      </p>
      <p>which letters are correct but in the wrong place <LetterButton :letter="misplaced" />,</p>
      <p>and which letters are not in the word at all <LetterButton :letter="incorrect" />.</p>
      <p>Good luck!</p>
    </v-card-text>
  </v-card>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { Letter } from '@/scripts/letter'
import { LetterStatus } from '@/scripts/letter'

const correct = new Letter('a', LetterStatus.Correct)
const misplaced = new Letter('b', LetterStatus.Misplaced)
const incorrect = new Letter('c', LetterStatus.Wrong)
</script>
