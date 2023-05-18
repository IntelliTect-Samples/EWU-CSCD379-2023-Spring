<template>
  <div style="display: flex; justify-content: center; margin-top: 1em">
    <v-card style="max-width: 900px"
      ><v-card-title>INSTRUCTIONS</v-card-title
      ><v-card-text
        >Welcome to Wordle!! Here are a few tips and instructions on how to play:

        <ul style="margin: 20px; display: flex; flex-direction: column; gap: 1em">
          <li>
            <v-card-text style="padding: 0">
              You have six tries to guess the five-letter Wordle of the day.</v-card-text
            >
          </li>
          <li>
            <v-card-text style="padding: 0">
              Type in your guess and submit your word by hitting the “enter” key or clicking
              submit.</v-card-text
            >
          </li>
          <li>
            <v-card-text style="padding: 0">
              After submitting your word, the tile colors will alter.A red tile signifies the letter
              is not in the word. A yellow tile signifies the correct letter chosen but placed
              incorrectly. A green tile signifies the correct letter chosen and placed correctly. A
              gray tile denotes that the chosen letter is not part of the word at all.</v-card-text
            >
          </li>
          <li>
            <v-card-text style="padding: 0">
              Continue until you solve the Wordle or run out of guesses. Good luck!</v-card-text
            >
          </li>
        </ul>
        Tip: Be sure to save your name using the dialog on the top right corner of the screen so you
        can save and later view your scores on the leaderboard.
      </v-card-text>
    </v-card>
  </div>
</template>

<style />
