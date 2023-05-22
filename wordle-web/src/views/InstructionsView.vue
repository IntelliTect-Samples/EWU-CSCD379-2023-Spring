<template>
  <div style="display: flex; justify-content: center">
    <v-card style="width: 75%"
      ><v-card-title>INSTRUCTIONS</v-card-title
      ><v-card-text
        >This is Wordle Web, a website built to simulate the New York Times Game Wordle. Below are
        some instructions on playing:
        <div style="margin: 15px">
          <v-card-text style="padding: 5px"
            >You have six tries to guess the five-letter Wordle of the day.</v-card-text
          >
          <v-card-text style="padding: 5px">
            Either with your keyboard, or by typing, select letters to add to the word to
            guess.</v-card-text
          >
          <v-card-text style="padding: 5px">
            Once you press the submit button, or the enter key, your word's letters will be
            highlighted with colors as feedback:</v-card-text
          >
          <v-card-text style="padding: 15px">
            The colors meanings vary based on the color theme, but on the default theme, a green
            letter is one that is in the correct place.
          </v-card-text>
          <v-card-text style="padding: 15px">
            A yellow letter is one that is in the word but one that does not match the placement of
            that letter in your guess.
          </v-card-text>
          <v-card-text style="padding: 15px">
            Otherwise, the letter is unused in the word.
          </v-card-text>

          <v-card-text style="padding: 5px">
            A tip: Try your best to vary letters used - using a letter that you already know is
            green yields no additional information!
          </v-card-text>
        </div>
      </v-card-text>
    </v-card>
  </div>
</template>

<script setup lang="ts"></script>
