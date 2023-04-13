<template>
  <h1>Wordle Mind Bender</h1>
  <v-text-field v-model="guess" label="Guess" variant="solo"></v-text-field>

  <v-btn @click="checkGuess">Check</v-btn>
  <div>
    <v-row v-for="word in guesses">
      <v-col v-for="letter in word" :key="letter.letter">
        <v-card :color="letter.color">
          <v-card-title>{{ letter.letter }}</v-card-title>
        </v-card>
      </v-col>
    </v-row>
  </div>

  <h2>{{ guess }}</h2>
  <h3>{{ secretWord }}</h3>
</template>

<script setup lang="ts">
import { Letter, LetterStatus } from '@/scripts/letter'
import { ref, reactive } from 'vue'

const guess = ref('')
const wordList = ['apple', 'peach', 'crypt', 'zesty', 'jello']
const secretWord = wordList[Math.floor(Math.random() * wordList.length)]
const guesses = reactive(new Array<Array<Letter>>())
console.log(secretWord)

function checkGuess() {
  console.log(guess.value)
  // check length of guess
  if (guess.value.length !== secretWord.length) {
    console.log('wrong length')
    guess.value = ''
    return
  }

  // check if the letters are valid
  const results = new Array<Letter>()
  const guessChars = guess.value.split('')
  const secretChars = secretWord.split('')
  let isCorrect = true
  for (let i = 0; i < 5; i++) {
    results.push(new Letter(guess.value[i]))
    if (guess.value[i] === secretWord[i]) {
      results[i].status = LetterStatus.Correct
      guessChars[i] = '_'
      secretChars[i] = '_'
      console.log(`Letter ${i} is correct`)
    } else {
      isCorrect = false
      results[i].status = LetterStatus.Wrong
      console.log(`Letter ${i} is incorrect`)
    }
  }

  for (let i = 0; i < 5; i++) {
    if (guessChars[i] !== '_') {
      for (let j = 0; j < 5; j++) {
        if (secretChars[j] === guessChars[i]) {
          results[i].status = LetterStatus.Misplaced
          guessChars[i] = '_'
          secretChars[j] = '_'
          console.log(`Letter ${i} is misplaced`)
          break
        }
      }
    }
  }

  console.log(guessChars)
  console.log(secretChars)
  console.log(results)
  console.log(isCorrect)
  guesses.push(results)
  console.log(guesses)
  // check if the letters are in the right place
}
</script>
