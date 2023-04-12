<template>
  
  <h1>Wordle Clone</h1>
  <v-text-field v-model="guess" label="Guess" variant="solo"></v-text-field>

  <v-btn @click="checkGuess">Check</v-btn>
  
  <h2>{{ guess }}</h2>
  <h3>{{ secretWord }}</h3>


</template>
<script setup lang="ts">
    import { Letter, LetterStatus } from '@/letter';

    import { ref, reactive } from 'vue'
    
    const guess = ref('');
    //const wordList = ['apple', 'peach', 'crypt', 'zesty', 'color', 'piano', 'jelly', 'silly', 'tacos', 'chips', 'chili']
    const wordList = ['apple', 'peach', 'crypt', 'zesty', 'jello']
    const secretWord = wordList[Math.floor(Math.random() * wordList.length)]
    const guesses = reactive(new Array<Letter>())
    console.log(secretWord);//log secretWord

    /*const count = ref(1)
    setInterval(() => {
        count.value++
    }, 1000)*/

    function checkGuess(){
        console.log(guess.value);

        //check length of guess
        if (guess.value.length !== secretWord.length) {
            console.log('wrong length')
            guess.value = ''
            return
        }

        //check if the letters are valid
        const results = new Array<Letter>()
        let isCorrect = true
        let guessChars = guess.value.split('')
        let secretChars = secretWord.split('')

        for(let i = 0; i < secretWord.length; i++){
            results.push(new Letter(guess.value[i]))
            if(guess.value[i] === secretWord[i]){
                results[i].status = LetterStatus.Correct
                guessChars[i] = '_'
                secretChars[i] = '_'
                console.log('Correct letter in position ${i}')
            }else{
                isCorrect = false
                console.log('Wrong Letter')
            }
        }
        console.log(guessChars)
        console.log(secretChars)
        //check for misplaced
        for (let i = 0; i < secretWord.length; i++){
            if (guessChars[i] !== '_'){
                for (let j = 0; j < secretWord.length; j++){
                    if(secretChars[j] === guessChars[i]){
                        results[i].status = LetterStatus.Misplaced
                        guessChars[i] = '_'
                        secretChars[j] = '_'
                        console.log("letter misplaced")
                        break
                    }
                }
            }
        }

    }

    //initialize values
</script>