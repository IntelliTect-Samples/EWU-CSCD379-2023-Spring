<template>
  <div class="d-flex align-center justify-center">
    <h1>How To Play</h1>
  </div>
  <div>
    <p class="d-flex align-center justify-center">
      The goal of the game is to guess the five letter word within six guesses.
    </p>
    <p class="d-flex align-center justify-center" style="text-align: center">
      After each guess, the game will tell you which letters are correct and which letters are in
      the wrong position. You have six guesses to find the word and each guess will give you some
      clues to find the correct word.
    </p>
  </div>
  <div class="d-flex align-center justify-center">
    <p>
      A guess with a letter in the correct position will be colored like this.
      <!-- <LetterButtonVue  :letter="new Letter(char='A')" /> -->
      <v-btn
        size="large"
        class="mr-1 letter-large"
        :key="index"
        :color="letter == 'X' ? 'wrong' : letter !== '?' ? 'correct' : 'unknown'"
      ></v-btn>
    </p>
  </div>
  <br />
  <div class="d-flex align-center justify-center">
    <p>
      A guess with a letter in the wrong position will be colored like this.
      <v-btn
        size="large"
        class="mr-1 letter-large"
        :key="index"
        :color="letter == 'X' ? 'wrong' : letter !== '?' ? 'misplaced' : 'unknown'"
      ></v-btn>
    </p>
  </div>
  <br />
  <div class="d-flex align-center justify-center">
    <p>
      A guess with a letter that is not in the word will be colored like this.
      <v-btn
        size="large"
        class="mr-1 letter-large"
        :key="index"
        :color="letter == 'X' ? 'wrong' : letter !== '?' ? 'wrong' : 'unknown'"
      ></v-btn>
    </p>
  </div>
  <br />
  <div>
    <p style="text-align: center">
      If a word has multiple of the same letter, letters may appear as both correct and misplaced or
      wrong when guessed.
    </p>
    <p class="d-flex align-center justify-center">
      Use these clues to find the correct word. Good luck!
    </p>
    <div class="d-flex align-center justify-center">
      <v-btn class="mt-3" @click="goToHomePage">Back to Home</v-btn>
    </div>
  </div>
</template>
<script setup lang="ts">
import { useRouter } from 'vue-router'
import { ref } from 'vue'

const index = ref(0)
const letter = ref('A')

const router = useRouter()

const goToHomePage = () => {
  router.push('/')
}
</script>
