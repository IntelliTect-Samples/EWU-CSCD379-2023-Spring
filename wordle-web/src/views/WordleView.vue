<template>
  <div>
    <h1>Wordle</h1>
    <div v-if="!gameOver">
      <!-- Create a text to receive input -->
      <v-text-field
        v-model="guess"
        class="elevation-15"
        title="guess"
        @keydown.enter="submit"
      ></v-text-field>
      <!-- Have a button to submit the guess-->
      <v-btn @click="submit" color="orange">Submit</v-btn>
    </div>

    <!-- Show all the words that have been guessed -->
    <div class="">
      <h2>Guessed Words</h2>
      <div v-for="word in guessedWords" :key="word.text" class="mb-2">
        <v-btn v-for="letter in word.letters" :key="letter.char" :color="letter.color"
          >{{ letter.char }}
        </v-btn>
      </div>
    </div>

    <!-- Show the keyboard -->
    <hr />
    <h2>Letters</h2>
    <div class="d-flex flex-wrap">
      <v-btn
        v-for="letter in letters"
        :key="letter.char"
        :color="letter.color"
        size="small"
        class="ma-1 pa-0"
        @click="() => letterClicked(letter)"
        >{{ letter.char }}
      </v-btn>
    </div>

    <div v-if="gameOver">
      <div v-if="gameWon">You Guessed the Word</div>
      <div v-if="!gameWon">Better Luck Next Time</div>
      <v-btn @click="playAgain" color="green">Play Again</v-btn>
    </div>
  </div>
</template>

<script setup lang="ts">
//import { WordsService } from '@/scripts/wordsService'
import { reactive, ref } from 'vue'

// Class that represents a letter and the letter's status
class Letter {
  static defaultColor = 'grey-lighten-3'
  static wrongColor = 'grey-darken-2'
  static wrongPlaceColor = 'yellow'
  static rightColor = 'green'

  char: string
  color: string

  constructor(char: string, color?: string) {
    this.char = char
    this.color = color || Letter.defaultColor
  }
}

// Game Variables
const gameOver = ref(false)
const gameWon = ref(false)

// Make an array of 5 letter words
const words = ['apple', 'grape', 'melon', 'plumb', 'fruit', 'peach']

// Pick a random word from the array
let secretWord = pickSecretWord()
console.log(secretWord)

// Current Word that is being guessed
const guess = ref('')

// List of guessed words
const guessedWords = reactive(new Array<Word>())
const letters = reactive(new Array<Letter>())

function submit() {
  if (guess.value.length === 5) {
    console.log('Guessing: ' + guess.value)
    // Check if each letter has been guessed
    const guessedWord = new Word(guess.value)
    // Variable to indicate if the word was guessed correctly
    let winner = true
    // Create a temp variable to hold the secret word
    // We are going to replace the found letters with _ characters
    // This is an array so we can replace things easily
    // We have to do this so duplicates letters work right
    let tempSecretWord = secretWord.split('')
    let tempGuessedWord = guess.value.split('')
    // See if any letters are in the right place
    for (let index = 0; index < 5; index++) {
      if (guessedWord.letters[index].char === secretWord[index]) {
        guessedWord.letters[index].color = Letter.rightColor
        // Replace the character with _ to indicate it has been found
        tempSecretWord[index] = '_'
        tempGuessedWord[index] = '_'
        // Mark the letter on the keyboard as found
        for (let letter of letters) {
          if (letter.char === guessedWord.letters[index].char) {
            letter.color = Letter.rightColor
          }
        }
      } else {
        winner = false
      }
    }

    console.log('Letters Left: ' + tempGuessedWord)
    // Check for right letters in the wrong places
    for (let index = 0; index < 5; index++) {
      const char = tempGuessedWord[index]
      if (char !== '_') {
        const foundIndex = tempSecretWord.indexOf(char)
        if (foundIndex > -1) {
          // Set the color of the guess to the wrong place color
          guessedWord.letters[index].color = Letter.wrongPlaceColor
          // Remove this letter from the temp secret word
          tempSecretWord[foundIndex] = '_'
          // Mark the letter on the keyboard as found but in the wrong place
          for (let letter of letters) {
            if (letter.char === char && letter.color !== Letter.rightColor) {
              letter.color = Letter.wrongPlaceColor
            }
          }
        } else {
          guessedWord.letters[index].color = Letter.wrongColor
          // Mark the letter on the keyboard as found but in the wrong place
          for (let letter of letters) {
            if (letter.char === char && letter.color == Letter.defaultColor) {
              letter.color = Letter.wrongColor
            }
          }
        }
      }
    }

    // Add this guessed word to the list of guessed words
    guessedWords.push(guessedWord)

    // Set winner flags
    if (winner) {
      gameWon.value = true
      gameOver.value = true
    } else if (guessedWords.length === 6) {
      gameOver.value = true
    }
  }
  guess.value = ''
}

function pickSecretWord(): string {
  return words[Math.floor(Math.random() * words.length)]
}

function playAgain() {
  secretWord = pickSecretWord()
  guessedWords.splice(0, guessedWords.length)
  for (let letter of letters) {
    letter.color = Letter.defaultColor
  }
  gameOver.value = false
  gameWon.value = false
}

function letterClicked(letter: Letter): void {
  console.log(letter.char)
  guess.value += letter.char
}

// onMounted(() => {
//   console.log(word)
// })

class Word {
  letters = new Array<Letter>()

  constructor(word: string) {
    for (let letter of word) {
      this.letters.push(new Letter(letter))
    }
  }

  get text(): string {
    return this.letters.map((l) => l.char).join('')
  }
}

// Push all the letters onto the letters array
letters.push(new Letter('a'))
letters.push(new Letter('b'))
letters.push(new Letter('c'))
letters.push(new Letter('d'))
letters.push(new Letter('e'))
letters.push(new Letter('f'))
letters.push(new Letter('g'))
letters.push(new Letter('h'))
letters.push(new Letter('i'))
letters.push(new Letter('j'))
letters.push(new Letter('k'))
letters.push(new Letter('l'))
letters.push(new Letter('m'))
letters.push(new Letter('n'))
letters.push(new Letter('o'))
letters.push(new Letter('p'))
letters.push(new Letter('q'))
letters.push(new Letter('r'))
letters.push(new Letter('s'))
letters.push(new Letter('t'))
letters.push(new Letter('u'))
letters.push(new Letter('v'))
letters.push(new Letter('w'))
letters.push(new Letter('x'))
letters.push(new Letter('y'))
letters.push(new Letter('z'))
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
