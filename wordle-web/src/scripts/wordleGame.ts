import { Word } from '@/scripts/word'
import { WordsService, ValidationStatus } from './wordsService'
import type { Letter } from '@/scripts/letter'


export enum WordleGameStatus {
  Active,
  Won,
  Lost
}

export class WordleGame {
  constructor(secretWord?: string | null) {
    if (!secretWord) secretWord = WordsService.getRandomWord()
    this.restartGame(secretWord)
  }
  
  guessedLetters: Letter[] = []
  guesses = new Array<Word>()
  secretWord = ''
  status = WordleGameStatus.Active
  guess!: Word
  numberOfGuesses = 6

  restartGame(secretWord?: string | null, numberOfGuesses: number = 6) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)

    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
    this.status = WordleGameStatus.Active
  }

  getValidWords() {
    return WordsService.matchWords(this.guesses)
  }

  submitGuess() {
    // Check if the guess is valid
    this.guess.check(this.secretWord)
        
     // Update the guessed letters
     for (const letter of this.guess.letters) {
      this.guessedLetters.push(letter)
    }
    
    // check for valid words
    const validWords = WordsService.matchWords(this.guesses)

    const index = this.guesses.indexOf(this.guess)
    console.log('current guess index = ' + index)

    if (index < this.guesses.length - 1) {
      this.guess = this.guesses[index + 1]

      console.log('guess text = ' + this.guesses[0])
      console.log('secret word = ' + this.secretWord)
// check if the game is won
    if (this.guess.text === this.secretWord) {
      this.status = WordleGameStatus.Won
      console.log("You won!")
      this.restartGame()
    }
    else if (index === 5 && this.guess.text !== this.secretWord) {
      this.status = WordleGameStatus.Lost
        alert('You lost!')
        this.restartGame()
    }
  }
}
}

