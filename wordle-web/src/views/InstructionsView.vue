<template>
  <v-responsive min-width="300px">
    <v-card>
      <v-card-item>
        <v-card-title>How To Play</v-card-title>
      </v-card-item>

      <v-card-item>
        <v-card-text>
          The Good Word is a guessing game where the goal of the game is to guess a randomly
          selected 5 letter word. You can use a keyboard to type, or you can use the interactive
          keyboard on the screen to click buttons. You get a total of 6 guesses in order to find the
          correct word. If a letter guessed is correct then it will change colors to GREEN, if a
          letter guessed is correct but in the wrong location it will change colors to YELLOW, if a
          letter guessed is incorrect it will change colors to RED. After guessing the correct word
          or after guessing incorrectly 6 times the game will end and your score will be recorded
          and saved. Are you ready to start guessing?
        </v-card-text>
      </v-card-item>
    </v-card>
  </v-responsive>

  <br />

  <v-responsive min-width="300px">
    <v-card>
      <v-card-item>
        <v-card-title>Wildcards (?) And The Valid-Guesses Tool </v-card-title>
      </v-card-item>

      <v-card-item>
        <v-card-text>
          Wildcards and the Valid-Guesses tool are designed to help you solve the correct word.
        </v-card-text>
      </v-card-item>

      <v-card-item>
        <v-card-text>
          The Valid-Guesses tool is used to help you find valid words based on the letters that are
          input. Once one or more letters are input into a guess, you can click the valid guesses
          bar. The valid guesses bar will then display all the possible valid words based off of the
          letters that were input. If you select one of the words it will automatically input it as
          your guess but it will NOT submit it.
        </v-card-text>
      </v-card-item>

      <v-card-item>
        <v-card-text>
          Wildcards, otherwise know as a question mark (?), are used to substitute for letters you
          are uncertain about. For example, if you know the correct location of 3 letters but are
          not sure what the last two letters are, you can input a question mark (?) for the two
          letters thats are uncertain. From there you can use the Valid-Guesses tool in order to
          determine what the secret word is.
        </v-card-text>
      </v-card-item>
    </v-card>
  </v-responsive>
</template>

<script setup lang="ts"></script>
