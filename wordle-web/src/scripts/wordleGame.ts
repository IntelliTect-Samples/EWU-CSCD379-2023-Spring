import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'
import type { Letter } from './letter'

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
  status = WordleGameStatus.Active
  numberOfGuesses = 6
  guessIndex = 0

  get guess(): Word {
    return this.guesses[this.guessIndex]
  }

  // // check length of guess
  //   if (this.letters.length !== secretWord.length) {
  //     console.log('wrong length')
  //     return
  //   }

  async restartGame(secretWord: string, numberOfGuesses: number = 6) {
    this.secretWord = secretWord
    this.guesses.splice(0)

    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }
    this.guessIndex = 0
    this.guessedLetters = []
    this.status = WordleGameStatus.Active
  }

  submitGuess() {
    if (!this.guess.isFilled) return
    if (!WordsService.isValidWord(this.guess.text)) {
      this.guess.clear()
      return
    }
    // put logic to win here.
    const correctGuess = this.guess.check(this.secretWord)
    // Update the guessed letters
    for (const letter of this.guess.letters) {
      this.guessedLetters.push(letter)
    }

    if (correctGuess) {
      this.status = WordleGameStatus.Won
    } else if (this.guessIndex + 1 == this.guesses.length) {
      this.status = WordleGameStatus.Lost
    } else {
      this.guessIndex++
    }
  }
}
