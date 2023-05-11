import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'
import type { Letter } from './letter'
import Axios from 'axios'

export enum WordleGameStatus {
  Active = 0,
  Won = 1,
  Lost = 2
}

export class WordleGame {
  constructor(secretWord?: string, numberOfGuesses: number = 6) {
    //if (!secretWord) secretWord = WordsService.getRandomWord()
    this.numberOfGuesses = numberOfGuesses
    this.restartGame('defal')
  }
  guessedLetters: Letter[] = []
  guesses = new Array<Word>()
  secretWord = ''
  numberOfSeconds = 0
  status = WordleGameStatus.Active
  guess!: Word
  numberOfGuesses = 6
  finalTime = 0
  finalGuesses = 0
  //useName = ''
  //displayName = 'Guest'
  interval = setInterval(() => this.secondsPassed(), 1000)

  // // check length of guess
  //   if (this.letters.length !== secretWord.length) {
  //     console.log('wrong length')
  //     return
  //   }

  async restartGame(secretWord: string, numberOfGuesses: number = 6) {
    //this.secretWord = secretWord
    this.secretWord = await WordsService.getWordFromApi()
    this.guesses.splice(0)
    this.numberOfSeconds = 0

    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
    this.status = WordleGameStatus.Active
  }

  secondsPassed() {
    this.numberOfSeconds += 1
    console.log('Second passed')
    console.log(this.numberOfSeconds)
  }

  submitGuess() {
    // put logic to win here.
    var isCorrect = this.guess.check(this.secretWord)
    if (isCorrect) {
      this.status = WordleGameStatus.Won
    } else {
      this.status = WordleGameStatus.Active
    }

    // Update the guessed letters
    for (const letter of this.guess.letters) {
      this.guessedLetters.push(letter)
    }

    console.log(this.guessedLetters)

    const index = this.guesses.indexOf(this.guess)
    if (index < this.guesses.length - 1 && this.status == WordleGameStatus.Active) {
      this.guess = this.guesses[index + 1]
    } else {
      // The game is over
      console.log('Game Over')
      if (this.status != WordleGameStatus.Won) {
        //display dialog for collecting information
        this.status = WordleGameStatus.Lost
      }
      this.finalGuesses = index + 1
      this.finalTime = this.numberOfSeconds
    }
  }
}
