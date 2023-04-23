<template>
  <div class="text-center">
    <v-dialog v-model="dialog" width="auto">
      <template v-slot:activator="{ props }">
        <v-btn v-bind="props" icon>
          <v-icon>mdi-information-outline</v-icon>
        </v-btn>
      </template>

      <v-card max-width="650px">
        <v-card-item class="justify-end">
          <v-btn icon dark @click="dialog = false">
            <v-icon>mdi-close</v-icon>
          </v-btn>
        </v-card-item>
        <v-card-item>
          <v-card-title class="text-center">How To Play</v-card-title>
          <v-card-subtitle class="text-center">Guess the given word!</v-card-subtitle>
        </v-card-item>

        <v-card-text>
          In the game of wordle the objective is to guess the given 5 letter word. You can do this
          by clicking on the letters in the wordle. If you guess the word incorrectly you will
          notice by the letter color changing red. If you guess the word incorrectly 6 times you
          will lose the game. If you guess the word correctly once you will win the game. Good luck!
        </v-card-text>

        <v-card-subtitle>Examples: </v-card-subtitle>

        <v-card-item>
          <div class="d-flex flex-row mb-6">
            <v-btn
              class="charButton"
              elevation="8"
              size="small"
              height="50"
              variant="outlined"
              color="grey"
            >
              A
            </v-btn>
            <v-card-text>
              - This button is example of a letter that has not bein played yet
            </v-card-text>
          </div>

          <div class="d-flex flex-row mb-6">
            <v-btn
              class="charButton"
              elevation="8"
              size="small"
              height="50"
              variant="outlined"
              color="correct"
            >
              A
            </v-btn>
            <v-card-text>
              - This button is example of a correct letter where the letter is in the word and in
              the correct position
            </v-card-text>
          </div>

          <div class="d-flex flex-row mb-6">
            <v-btn
              class="charButton"
              elevation="8"
              size="small"
              height="50"
              variant="outlined"
              color="misplaced"
            >
              A
            </v-btn>
            <v-card-text>
              - This button is example of a misplaced letter where the letter is in the word and but
              is in the wrong position
            </v-card-text>
          </div>

          <div class="d-flex flex-row mb-6">
            <v-btn
              class="charButton"
              elevation="8"
              size="small"
              height="50"
              variant="outlined"
              color="wrong"
            >
              A
            </v-btn>
            <v-card-text>
              - This button is example of a correct letter where the letter is not in the word
            </v-card-text>
          </div>
        </v-card-item>
      </v-card>
    </v-dialog>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

var dialog = ref(true)
</script>
