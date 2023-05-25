<template>
  <v-card>
    <v-card-title>How to Play</v-card-title>
    <v-card-text>
      Wordle is a game where you try to guess a five letter word. You have six guesses to get the
      word.<br />
      After each guess, you will be shown which letters the letters that are correct and correctly
      placed <LetterButton :letter="correct" />,<br />
      which letters are correct but in the wrong place <LetterButton :letter="misplaced" />,<br />
      and which letters are not in the word at all <LetterButton :letter="incorrect" />.<br />
      Good luck!<br />
      <v-btn><RouterLink to="/">Play Game</RouterLink></v-btn>
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
