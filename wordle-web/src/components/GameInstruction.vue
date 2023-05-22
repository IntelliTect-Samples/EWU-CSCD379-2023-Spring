<template>
<v-app-bar-nav-icon @click="instruction = !instruction" icon="mdi-alert-circle-outline"> </v-app-bar-nav-icon>

<v-dialog v-model="instruction" width="500" > 
<v-card class="pa-md-4 mx-lg-auto">
    <h2><strong>How To Play</strong></h2>
    <h3>Guess the Wordle in 6 tries.</h3>
    <li>Each guess must be a valid 5-letter word.</li>
    <li>The color of the tiles will change to show how close your guess was to the word.</li>
    <h3><strong>Examples</strong></h3>

    <v-row dense>
    <v-col v-for="(word, c) in firstword" :key="`${c}`" cols="auto">
      <LetterBase :char="word" :color="rightword(c)"/>
    </v-col>
    </v-row>

    <p><strong>U</strong> is in the word and in the correct spot.</p>
    <br/>

    <v-row dense>
    <v-col v-for="(word, c) in secondword" :key="`${c}`" cols="auto">
      <LetterBase :char="word" :color="misplaceword(c)"/>
    </v-col>
    </v-row>

    <p><strong>G</strong> is in the word but in the wrong spot.</p>
    <br/>

    <v-row dense>
    <v-col v-for="(word, c) in thirdword" :key="`${c}`" cols="auto">
      <LetterBase :char="word" :color="wrongword(c)"/>
    </v-col>
    </v-row>

    <p><strong>U</strong> is not in the word in any spot.</p>
    <br/>

  <v-card-actions class="justify-center">
    <v-btn @click="instruction = false" :color="'primary'">Close</v-btn>
  </v-card-actions>
</v-card>
</v-dialog>

</template>

<script setup lang="ts">
import { ref } from 'vue';
import LetterBase from './LetterBase.vue';

const instruction = ref(false)

const firstword = ref(['D', 'U', 'C', 'A', 'T'])
const secondword = ref(['U', 'R', 'G', 'O', 'T'])
const thirdword = ref(['L', 'O', 'T', 'U', 'S'])


function rightword(index : number){
    if(index == 0)
    return 'correct'
}

function misplaceword(index : number){
  if(index == 2)
    return 'misplaced'
}

function wrongword(index : number){
  if(index == 3)
    return 'wrong'
}

</script>
