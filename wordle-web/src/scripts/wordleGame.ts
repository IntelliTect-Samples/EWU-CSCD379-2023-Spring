import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'
import type { Letter } from './letter'
import { LetterStatus } from './letter';

export enum WordleGameStatus {
  Active = 0,
  Won = 1,
  Lost = 2
}

export class WordleGame {
  constructor(secretWord?: string, numberOfGuesses: number = 6) {
    if (!secretWord) secretWord = WordsService.getRandomWord()
    this.numberOfGuesses = numberOfGuesses
    this.restartGame(secretWord)
  }
  guessedLetters: Letter[] = []
  guesses = new Array<Word>()
  secretWord = ''
  numberOfGuesses = 6
  status = WordleGameStatus.Active
  guess!: Word
  validWords = new Array<String>()

  

  // // check length of guess
  //   if (this.letters.length !== secretWord.length) {
  //     console.log('wrong length')
  //     return
  //   }

  async restartGame(secretWord: string, numberOfGuesses: number = 6) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)
    // create a word for each guess
    for (let iWord = 0; iWord < numberOfGuesses; iWord++) {
      const word = new Word(secretWord.length)
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
    this.status = WordleGameStatus.Active
  }

  submitGuess() {
    // put logic to win here.
    this.validWords = WordsService.validWords(this.guess, this.secretWord)
    this.guess.check(this.secretWord)

    // Update the guessed letters
    for (const letter of this.guess.letters) {
      this.guessedLetters.push(letter)
    }

    // Check if the game is won
    for (let i = 0; i < this.secretWord.length; i++) {
      if (this.guess.letters[i].status !== LetterStatus.Correct) {
        break;
      } else if (i === this.secretWord.length - 1) {
        this.status = WordleGameStatus.Won
      }
    }


    console.log(this.guessedLetters)

    const index = this.guesses.indexOf(this.guess)

    if (index < this.guesses.length) {
      this.guess = this.guesses[index + 1]
    } 
    if (index === this.numberOfGuesses - 1 && this.status !== WordleGameStatus.Won) {
      this.status = WordleGameStatus.Lost
    }





}
}
