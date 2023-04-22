import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'
import type { Letter } from './letter'

export enum GameState {
  Active = 0,
  Won = 1,
  Lost = 2
}

export class WordleGame {
  constructor(secretWord?: string | null) {
    this.restartGame(secretWord)
  }

  status = GameState.Active
  guesses = new Array<Word>()
  guessedLetters = new Array<Letter>()
  currentGuessIndex = 0
  secretWord = ''

  get currentGuess() {
    return this.guesses[this.currentGuessIndex]
  }

  restartGame(secretWord?: string | null, numberOfGuesses: number = 6) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)
    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }
    console.log(this.guesses)
    this.currentGuessIndex = 0
    this.status = GameState.Active
  }

  submitGuess() {
    console.log(this.currentGuess.text)
    if (this.currentGuess.check(this.secretWord)) {
      this.status = GameState.Won
      console.log('You won!')
    } else if (this.currentGuessIndex >= this.guesses.length - 1) {
      this.status = GameState.Lost
      console.log('You lost!')
    }
    for (const letter of this.currentGuess.letters) {
      this.guessedLetters.push(letter)
    }
    this.currentGuessIndex++
  }
}
