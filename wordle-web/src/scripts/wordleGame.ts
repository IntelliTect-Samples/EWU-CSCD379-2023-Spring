import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'
import { Letter, LetterStatus } from '@/scripts/letter'

export enum WordleGameStatus {
  Active = 0,
  Won = 1,
  Lost = 2
}

export class WordleGame {
  guessedLetters: Letter[] = []
  guesses: Word[] = new Array<Word>()
  guessAttempts: number = 0
  secretWord: string = ''
  status: WordleGameStatus = WordleGameStatus.Active
  guess!: Word
  numberOfGuesses: number = 6

  constructor(secretWord?: string, numberOfGuesses: number = 6) {
    this.numberOfGuesses = numberOfGuesses

    if (!secretWord) {
      secretWord = 'null'
    }

    this.startNewGame(secretWord)
  }

  async startNewGame(secretWord: string, numberOfGuesses: number = 6) {
    this.secretWord = secretWord || (await WordsService.getWordFromApi())
    await WordsService.getWordListFromApi()
    this.guesses.splice(0)

    // Create a word for each guess.
    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }

    this.guess = this.guesses[0]
    this.status = WordleGameStatus.Active
  }

  submitGuess() {
    const correctlyGuessed: boolean = this.guess.checkWord(this.secretWord)
    this.guessAttempts++
    // TODO: Go back and fix possible problems pointed out by Meg in Assignment 1 or 2...
    // Update the guessed letters.
    for (const guessLetter of this.guess.letters) {
      for (const guessedLetter of this.guessedLetters) {
        if (guessLetter.char === guessedLetter.char) {
          if (guessedLetter.status === LetterStatus.Correct) {
            /* empty */
          } else if (
            guessedLetter.status === LetterStatus.Misplaced &&
            guessLetter.status === LetterStatus.Correct
          ) {
            this.guessedLetters.splice(this.guessedLetters.indexOf(guessedLetter), 1)
          } else if (
            guessedLetter.status === LetterStatus.Misplaced &&
            guessLetter.status === LetterStatus.Wrong
          ) {
            /* empty */
          } else if (
            guessedLetter.status === LetterStatus.Wrong &&
            guessLetter.status === LetterStatus.Misplaced
          ) {
            this.guessedLetters.splice(this.guessedLetters.indexOf(guessedLetter), 1)
          } else if (
            guessedLetter.status === LetterStatus.Wrong &&
            guessLetter.status === LetterStatus.Correct
          ) {
            this.guessedLetters.splice(this.guessedLetters.indexOf(guessedLetter), 1)
          } else {
            this.guessedLetters.splice(this.guessedLetters.indexOf(guessedLetter), 1)
          }
        }
      }
      this.guessedLetters.push(guessLetter)
    }

    console.log(this.guessedLetters)

    const index: number = this.guesses.indexOf(this.guess)
    if (index < this.guesses.length - 1 && !correctlyGuessed) {
      this.guess = this.guesses[index + 1]
    } else {
      this.gameOver(correctlyGuessed)
    }
  }

  // TODO: Find a way to disable not just input, but the ability to backspace.
  gameOver(correctlyGuessed: boolean) {
    if (correctlyGuessed) {
      this.status = WordleGameStatus.Won
      console.log('You Win!')
    } else {
      this.status = WordleGameStatus.Lost
      console.log('You Lose!')
    }
  }
}
