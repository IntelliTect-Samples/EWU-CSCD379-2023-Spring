<template>
  <v-container class="d-flex justify-center align-center">
    <v-card width="500px">
      <div class="bg-primary text-h5 pa-3 text-center">How To Play</div>
      <v-card-text>
        <div
          class="d-flex justify-start bg-secondary text-h6"
          style="padding-left: 5px; padding-right: 5px"
        >
          Guess a 5 Letter Word
        </div>
        <v-card-text class="d-flex flex-column align-Right">
          Your guess can be any word
          <br/>
          You can type your guess or click on the letters
        </v-card-text>
        <div
          class="d-flex justify-start bg-secondary text-h6"
          style="padding-left: 5px; padding-right: 5px"
        >
          Green letters are in the correct place
        </div>
        <v-card-text class="d-flex flex-column align-Right"> </v-card-text>
        <div
          class="d-flex justify-start bg-secondary text-h6"
          style="padding-left: 5px; padding-right: 5px"
        >
          Yellow letters are in the wrong place
        </div>
        <v-card-text class="d-flex flex-column align-Right"> 
          *If a letter appears as yellow in one position but green in another, it means there is at least one more of the green letter in the word, but not in the yellow letter's position
        </v-card-text>
        <div
          class="d-flex justify-start bg-secondary text-h6"
          style="padding-left: 5px; padding-right: 5px"
        >
          Red letters are not in the word
        </div>
        <v-card-text class="d-flex flex-column align-Right">
          *If a letter appears as red in one position but green in another, it means that the letter only appears once for each green letter
        </v-card-text>
        <div
          class="d-flex justify-start bg-secondary text-h6"
          style="padding-left: 5px; padding-right: 5px"
        >
          Example Wordle:
        </div>
        <v-row dense>
        <v-col
        style="margin-top: 6px;"
          class="justify-center"
          v-for="(letter, index) in letters"
          :key="index"
          cols="auto"
          :class="{ 'ml-1 px-0': display.xs }"
          
          >
          <LetterButton :letter="letter"/>
        </v-col>
        
        </v-row>
        
        <v-card-text class="d-flex flex-column align-Right"> 
          In this example, "C" is a correct letter in the correct spot, "R", "U", and "L" are misplaced, and "E" is not in the word
        </v-card-text>
        
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script lang="ts" setup>
import { Letter } from '@/scripts/letter'
import LetterButton from '@/components/LetterButton.vue'
import { LetterStatus } from '@/scripts/letter';
import { Services } from '@/scripts/services';
import { inject, reactive } from 'vue';
import { useDisplay } from 'vuetify/lib/framework.mjs';

const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>
  const letters: Letter[] = []
  letters[0] = new Letter('C', LetterStatus.Correct)
  letters[1] = new Letter('R', LetterStatus.Misplaced)
  letters[2] = new Letter('U', LetterStatus.Misplaced)
  letters[3] = new Letter('E', LetterStatus.Wrong)
  letters[4] = new Letter('L', LetterStatus.Misplaced)

</script>