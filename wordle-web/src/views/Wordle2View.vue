<template>
  <div>
    <h1>Wordle</h1>
    <!-- Create a text to receive input -->
    <div>
      <v-text-field v-model="guess"></v-text-field>
    </div>
    <v-btn @click="submit">Submit</v-btn>

    <!-- Show all the words that have been guessed -->
    <div class="">
      <h2>Guessed Words</h2>
      <div v-for="word in wordleGame.words" :key="word.text" class="mb-2">
        <v-btn v-for="letter in word.letters" :key="letter.char" :class="letter.letterColor"
          >{{ letter.char }}
        </v-btn>
      </div>
    </div>

    <div v-if="wordleGame.gameOver">
      <div v-if="wordleGame.state == GameState.Won">You Win</div>
      <div v-if="wordleGame.state == GameState.Lost">You Lost</div>
      <v-btn @click="playAgain">Play Again</v-btn>
    </div>
  </div>
</template>

<script setup lang="ts">
import { WordleGame, GameState } from '@/scripts/wordleGame'
import { WordsService } from '@/scripts/wordsService'
import { reactive, ref } from 'vue'

const word = WordsService.getRandomWord()
console.log(word)
const wordleGame = reactive(new WordleGame(word))
const guess = ref('')

function submit() {
  if (guess.value.length === 5) {
    for (let letter of guess.value) {
      wordleGame.currentWord.addLetter(letter)
    }
    wordleGame.submitWord()
  }
}

function playAgain() {
  location.reload()
}

// onMounted(() => {
//   console.log(wordleGame.currentWord)
// })
</script>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }

  .success {
    background-color: green;
  }
  .warning {
    background-color: yellow;
  }
}
</style>
