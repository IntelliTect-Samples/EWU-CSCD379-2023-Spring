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
  nameSaved = false
  guess!: Word
  numberOfGuesses = 6

  async restartGame(secretWord?: string | null, numberOfGuesses: number = 6) {
    this.secretWord = secretWord || (await WordsService.getWordFromApi())
    this.guesses.splice(0)
    this.guessedLetters.splice(0)

    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
    this.status = WordleGameStatus.Active
  }

  submitGuess() {
    // put logic to win here.
    if (this.guess.check(this.secretWord)) {
      this.status = WordleGameStatus.Won
    }

    // Update the guessed letters
    for (const letter of this.guess.letters) {
      this.guessedLetters.push(letter)
    }

    console.log(this.guessedLetters)

    const index = this.guesses.indexOf(this.guess)
    if (index < this.guesses.length - 1) {
      this.guess = this.guesses[index + 1]
    } else {
      // The game is over
      this.status = WordleGameStatus.Lost
    }
  }
}
