<template>
  <v-card class="d-flex align-center justify-center" max-width="100%" min-height="100%">
    <div>
      <v-card-title>How to Play</v-card-title>
      <v-card-text>
        Wordle is a game where you try to guess a five letter word. You have six guesses to get the
        word.<br />
        After each guess, you will be shown which letters the letters that are correct and correctly
        placed <LetterButton :letter="correct" /> ,<br />
        which letters are correct but in the wrong place
        <LetterButton :letter="misplaced" /> ,<br />
        and which letters are not in the word at all <LetterButton :letter="incorrect" /> .<br />
        Good luck!<br />
        <v-btn color="correct"
          ><RouterLink to="/game" style="color: white">Play Game</RouterLink></v-btn
        >
      </v-card-text>
    </div>
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
