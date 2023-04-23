<template>
  <h1>Wordle Mind Bender</h1>
  <v-text-field v-model="guess" label="Guess" variant="solo"></v-text-field>

  <v-btn @click="checkGuess">Check</v-btn>
  <div>
    <v-row v-for="word in game.guesses" :key="word.text">
      <v-col v-for="letter in word.letters" :key="letter.char">
        <LetterButton :letter="letter"></LetterButton>
      </v-col>
    </v-row>
  </div>

    <div>
      <v-dialog
        width="auto"
      >
        <template v-slot:activator="{ props }">
          <v-btn
            color="primary"
            v-bind="props"
          >
            {{ game.list.length }}
          </v-btn>
        </template>

        <v-card>
          <v-row v-for="word in game.list" :key="word">
            <v-btn
            @click="enterWord"
            color="primary"
            >
              {{ word }}
            </v-btn>
          </v-row>
        </v-card>
      </v-dialog>
    </div>

  <!--<h2>{{ guess }}</h2> -->
  <!--<h3>{{ game.secretWord }}</h3> -->
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive } from 'vue'

const guess = ref('')
const game = reactive(new WordleGame())
console.log(game.secretWord)

function checkGuess() {
  game.submitGuess(guess.value)
}

function enterWord(){ 
  game.submitGuess(guess.value)
}

</script>

