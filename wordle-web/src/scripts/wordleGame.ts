//import { Letter, LetterStatus } from '@/scripts/letter'
import { Word } from '@/scripts/word'
//import { ref, reactive } from 'vue'
import { WordsService } from './wordsService'

/*
export enum WordleGameStatus {
  Active = 0, 
  Won = 1, 
  Lost = 2
}
*/
export class WordleGame {
  constructor(secretWord?: string, numberOfGuesses: number = 6) {
    if (!secretWord) secretWord = WordsService.getRandomWord()
    this.numberOfGuesses = numberOfGuesses
    this.restartGame(secretWord)
  }
  guesses = new Array<Word>()
  secretWord = ''
  numberOfGuesses = 6
  guess!: Word
  //status = 
  //currentGuessIndex = 0


  // // check length of guess
  //   if (this.letters.length !== secretWord.length) {
  //     console.log('wrong length')
  //     return
  //   }

  restartGame(secretWord: string) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)
    // create a word for each guess
    for (let iWord = 0; iWord < this.numberOfGuesses; iWord++) {
      const word = new Word(secretWord.length)
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
  }

  submitGuess() {
    // put logic to win here.
    this.guess.check(this.secretWord)
    const index = this.guesses.indexOf(this.guess)
    if (index < this.guesses.length - 1) {
      this.guess = this.guesses[index + 1]
    } else {
      // The game is over
    }

  /*
  restartGame(secretWord?: string | null, numberOfGuesses: number = 6) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)

    for(let i = 0; i < 6; i++){
      const word = new Word()
      this.guesses.push(word)
    }    
    this.currentGuessIndex = 0
  }

  get currentGuess() {
    return this.guesses[this.currentGuessIndex]
  }

  submitGuess() {
    if(this.currentGuess.check(this.secretWord)) {
      this.status = WordleGameStatus.Won
    } else if(this.currentGuessIndex >= this.guesses.length){
      this.status = WordleGameStatus.Lost
    }
    this.currentGuessIndex++
  }
  */
}