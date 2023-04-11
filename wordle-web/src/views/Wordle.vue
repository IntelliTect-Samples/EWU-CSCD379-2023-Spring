<template>
  <div >
      <h1>Wordle Game</h1>
      <v-text-field v-model="guess" label="Label"></v-text-field>

      <v-btn @click="checkGuess">Check</v-btn>

      <h2> 
        {{  guess }}
      </h2>
      <h3>{{  secretWord }}</h3>


  </div>
</template>

<script setup lang="ts">
import { Letter, LetterStatus } from '@/scripts/letter';
import { ref } from 'vue';

const guess = ref('')
const wordList = ["apple", "banana", "peach", "crypt", "zesty", "color", "piano", "jello", "juice", "pizza"]
const secretWord = wordList[Math.floor(Math.random() * wordList.length)]
console.log(secretWord)

function checkGuess() {
  console.log(guess.value)
  //check length of user input
  if (guess.value.length !== secretWord.length) {
    console.log('wrong length!')
    guess.value = ''
    return
  }


  //check if the letters are valid
  const results = new Array<Letter>()

  //check if the letters are in the right place
  const guessChars = guess.value.split('')
  const secretChars = secretWord.split('')

  let isCoorect = true
  for(let i = 0; i < 5; i++) {
    results.push(new Letter(guess.value[i]))
    if(guess.value[i] === secretWord[i]) {
      results[i].status = LetterStatus.Correct
      guessChars[i] = '_'
      secretChars[i] = '_'
      console.log(`Letter ${i} is correct!`)
    } else {
      isCoorect = false
      //results[i].status = LetterStatus.Misplaced
      console.log(`Letter ${i} is incorrect!`)
    }
  }

for(let i = 0; i < 5; i++) {
  if (guessChars[i] === '_') {
    continue
  }
  for(let j = 0; j < 5; j++) {
    if (secretChars[j] === guessChars[i]) {
      results[i].status = LetterStatus.Misplaced
      guessChars[i] = '_'
      secretChars[j] = '_'
      console.log(`Letter ${i} is misplaced!`)
      break
    }
  }
}

  console.log(guessChars)
  console.log(secretChars)
}

//initialize the secret word
//initialize the guess
</script>