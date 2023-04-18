<template>
  <v-div>
    <Navbar></Navbar>
    <GameBoard></GameBoard>
    <v-container >
      <v-row class="">

        <v-text-field class="mr-2"
          label="Guess"
          hideDetails="auto"
          variant="outlined"
          size="lg"
          :value="selectedWord || guess"
        ></v-text-field>

        <v-btn class="ml-2" @click="checkGuess">Check</v-btn>

        <ValidWordList class="ml-2"
          :validWords="validWords"
          @word-selected="handleWordSelected"/>
      </v-row>
    </v-container>
    <VirtualKeyboard :guess="guess" @key-pressed="handleKeyPress"></VirtualKeyboard>
 
    <div>
      <v-row v-for="word in game.guesses" :key="word.text">
        <v-col v-for="letter in word.letters" :key="letter.char">
          <v-btn :color="letter.color">{{ letter.char }}</v-btn>
        </v-col>
      </v-row>
    </div>
  
</v-div>
</template>


<script setup lang="ts">
import Navbar from "@/components/NavbarItem.vue";
import GameBoard from "@/components/GameBoard.vue";
import VirtualKeyboard from "@/components/VirtualKeyboard.vue";

import { WordleGame } from '@/scripts/wordleGame';
import { ref, reactive } from 'vue';
import ValidWordList from '@/components/ValidWordList.vue';
import { WordsService } from '@/scripts/wordsService';


const guess = ref('')
const game = reactive(new WordleGame())
const validWords = ref<string[]>();
const selectedWord = ref('');

function checkGuess() {
  // check the length of the guess
  if (guess.value.length !== 5) {
    alert(guess.value + ' is only ' + guess.value.length + ' letters long, too short to ride!');
    return;
  }
  // check if the guess has already been guessed
  if (game.guesses.find(g => g.text === guess.value)) {
    alert('You have already guessed ' + guess.value + ', Try something new!');
    return;
  }
  // check if the guess is in the valid words list
  if (!WordsService.getFullList().includes(guess.value)) {
  alert('Sorry.. ' + guess.value + ' is not a valid word');
  return;
  }
// submit the guess
  game.submitGuess(guess.value);
  validWords.value = WordsService.validWords(game.guesses[game.guesses.length - 1]);
  guess.value = '';
}


function handleWordSelected(word: string) {
  guess.value = word;
}

function handleKeyPress(key: string) {
  if (key === 'Backspace') {
    guess.value = guess.value.slice(0, -1); // remove the last character from the guess
  } else if (key === 'Enter') {
    checkGuess(); // submit the guess
  } else if (guess.value.length < 5 && key.length === 1 && key.match(/[a-z]/i)){
    guess.value += key; // add the pressed key to the guess
  }
}

</script>

