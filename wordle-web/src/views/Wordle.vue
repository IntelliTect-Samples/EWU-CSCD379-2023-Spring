<template>
    <h1>Wordle Mind Bender</h1>
    <v-text-field v-model="guess" label="Guess" variant="solo"></v-text-field>

    <v-btn @click="checkGuess">Check</v-btn>

    <h2>{{ guess }}</h2>
    <h3>{{ secretWord }}</h3>

</template>

<script setup lang="ts">
import { Letter, LetterStatus } from '../scripts/letter';
import {ref} from 'vue'

const guess = ref('')
const wordList = ["apple", "peach", "crypt", "zesty", "jelly",]

const secretWord = wordList[Math.floor(Math.random() * wordList.length)]
console.log(secretWord)
function checkGuess(){
    console.log(guess.value)
    //check length of guess
    if(guess.value.length !== secretWord.length){
        console.log('wrong length')
        guess.value =''
        return
    }
}
//check if letters are valid
const results = new Array<Letter>()
const guessChars = guess.value.split('')
const secretChars = secretWord.split('')
let isCorrect = true
for(let i = 0; i < 5; i++){
    results.push(new Letter(guess.value[i]))
    if(guess.value[i] === secretWord[i]){
        results[i].status = LetterStatus.Correct
        guessChars[i] = '-'
        secretChars[i] = '-'
        console.log('Letter ${i} is correct')
    }else{
        isCorrect = false
        results[i].status = LetterStatus.Wrong
        console.log('Letter ${i} is incorrect')
    }
}

for(let i = 0; i < 5; i++){
    if(guessChars[i] !== '_'){
        for(let j = 0; j < 5; j++){
            if(secretChars[j] === guessChars[j]){
                results[i].status = LetterStatus.Misplaced
                guessChars[i] = '-'
                secretChars[j] = '-'
                console.log('letter ${i} misplaced')
                break
            }
        }
    }
}

console.log(guessChars)
console.log(secretChars)
console.log(results)
console.log(isCorrect)

</script>