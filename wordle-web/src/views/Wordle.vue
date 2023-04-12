
<template>
  <main>
    <v-text-field v-model="guess" label="Guess" variant="solo"></v-text-field>
    <v-btn @click="checkGuess(guess)">Submit</v-btn>
    <v-container> {{ guess }} </v-container>
    <!-- <v-container> {{ count }} </v-container> -->

  </main>
</template>

<script setup lang="ts">
import { Letter, LetterStatus } from '@/scripts/letter';
import { ref } from 'vue'

const guess = ref('')
const guesses = Reactive(new Array<Array<Letter>>)
const wordList = ['apple', 'color', 'train', 'mouse', 'house', 'jelly', 'piano', 'silly', 'sugar', 'water', 'paper']
const secretWord = wordList[Math.floor(Math.random() * wordList.length)]

console.log(secretWord)
// const count = ref(1)

function checkGuess(guess: string): void {
  //input validation
  if (guess.length < 5) {
    alert('Please enter a word with at least 5 letters')
    return
  }

  //check if letter are valid

  const guessChars = guess.split('')
  const secretChars = secretWord.split('')
  const results = new Array<Letter>

  let isCorrect = true
  for (let i = 0; i < guess.length; i++) {
    results.push(new Letter(guess[i]))
    if (guess[i] === secretWord[i])  {
      alert(`Letter ${guess[i]} is correct!`)
      results[i].status = LetterStatus.Correct
      guessChars[i] = '_'
      secretChars[i] = '_'
      return
    } else {
      isCorrect = false
      results[i].status = LetterStatus.Wrong
      alert(`Letter ${guess[i]} is incorrect!`)
      return
    }
  }

  for (let i = 0; i < 5; i++){
    if (guessChars[i] !== '_'){
      for (let j = 0; i < 5; j++){
        if (secretChars[j] === guessChars[i]){
          results[i].status = LetterStatus.Misplaced
          secretChars[j] = '_'
          guessChars[i] = '_'
          continue
        }
      }
      if (guessChars[i] === secretChars[i]){
        alert(`Letter ${guessChars[i]} is correct!`)
        results[i].status = LetterStatus.Correct
        guessChars[i] = '_'
        secretChars[i] = '_'
        return
      }
    }
  }
  console.log(guessChars)
  console.log(secretChars)
}

// setInterval(() => {
//   count.value++
// }, 1000)
// 
function Reactive(arg0: Letter[][]) {
throw new Error('Function not implemented.');
}
</script>