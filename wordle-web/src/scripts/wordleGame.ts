import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'
import { LetterStatus, Letter } from './letter'

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

  get currentGuess(): Word {
    return this.guesses[this.currentGuessIndex]
  }
  set currentGuess(word: Word) {
    this.guesses[this.currentGuessIndex] = word
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
      return
    }
    for (const letter of this.currentGuess.letters) {
      // If the letter has not been guessed yet, add it to the list of guessed letters
      if (!this.guessedLetters.some((l) => l.char === letter.char)) {
        const newLetter = new Letter(letter.char, letter.status)
        this.guessedLetters.push(newLetter)
      }
      // Else if the letter has been guessed, update the status if necessary
      else {
        const guessedLetter = this.guessedLetters.find((l) => l.char === letter.char)
        if (guessedLetter) {
          if (
            guessedLetter.status === LetterStatus.Misplaced &&
            letter.status === LetterStatus.Correct &&
            this.secretWord.indexOf(letter.char) ===
              this.currentGuess.text.indexOf(guessedLetter.char)
          ) {
            guessedLetter.status = LetterStatus.Correct
          }
        }
      }
    }
    console.log(this.guessedLetters)
    if (this.currentGuessIndex < this.guesses.length - 1) {
      this.currentGuessIndex++
    } else {
      this.status = GameState.Lost
      console.log('You lost!')
    }
  }
}
