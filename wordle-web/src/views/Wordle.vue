<template>
  <Navbar></Navbar>
  <v-text-field
    v-model="guess"
    label="Guess"
    variant="solo"
    :value="selectedWord || guess"
  ></v-text-field>
  <v-btn @click="checkGuess">Check</v-btn>
  <div>
    <v-row v-for="word in game.guesses" :key="word.text">
      <v-col v-for="letter in word.letters" :key="letter.char">
        <v-btn :color="letter.color">{{ letter.char }}</v-btn>
      </v-col>
    </v-row>
  </div>

  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>
  <ValidWordList :validWords="validWords" @word-selected="handleWordSelected" />

</template>

<script setup lang="ts">
import Navbar from "@/components/NavbarItem.vue";
import { WordleGame } from '@/scripts/wordleGame';
import { ref, reactive } from 'vue';
import ValidWordList from '@/components/ValidWordList.vue';
import { WordsService } from '@/scripts/wordsService';

const guess = ref('')
const game = reactive(new WordleGame())
const validWords = ref<string[]>();
const selectedWord = ref('');

function checkGuess() {
  game.submitGuess(guess.value);
  validWords.value = WordsService.validWords(game.guesses[game.guesses.length - 1]);
}

function handleWordSelected(word: string) {
  guess.value = word;
}
</script>
