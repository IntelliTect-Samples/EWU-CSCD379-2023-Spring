import { Word } from '@/scripts/word'
import { WordsService } from '@/scripts/services/wordsService'
import type { Letter } from '@/scripts/letter'
import { LetterStatus } from '@/scripts/letter'

export enum WordleGameStatus {
  Active = 0,
  Won = 1,
  Lost = 2
}

export class WordleGame {
  guessedLetters: Letter[] = []
  guesses: Word[] = new Array<Word>()
  secretWord: string = ''
  status: WordleGameStatus = WordleGameStatus.Active
  numberOfGuesses: number = 6
  guessIndex: number = 0
  startTime: number = Date.now()
  endTime: number | null = null

  constructor(secretWord?: string, numberOfGuesses: number = 6) {
    if (!secretWord) secretWord = WordsService.getRandomWord()
    this.numberOfGuesses = numberOfGuesses
    this.startNewGame(secretWord)
  }

  duration(): number {
    return (this.endTime || Date.now()) - this.startTime
  }

  get guess(): Word {
    return this.guesses[this.guessIndex]
  }

  // // check length of guess
  //   if (this.letters.length !== secretWord.length) {
  //     console.log('wrong length')
  //     return
  //   }

  async startNewGame(secretWord: string, numberOfGuesses: number = 6) {
    this.secretWord = secretWord
    this.startTime = Date.now()
    this.endTime = null
    this.guesses.splice(0)

    await WordsService.getWordListFromApi()

    // Create a word for each guess.
    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }

    this.guessIndex = 0
    this.guessedLetters.splice(0)
    this.status = WordleGameStatus.Active
  }

  submitGuess() {
    if (!this.guess.isFilled) return
    if (!WordsService.isValidWord(this.guess.text)) {
      this.guess.clear()
      console.log('Invalid word was entered')
      return
    }
    // put logic to win here.
    const correctGuess = this.guess.checkWord(this.secretWord)

    // TODO: Possibly find a better place to do this, and find a more efficient way of doing it...
    /// Updates the colors of the Game Keyboard...
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
    }

    // Update the guessed letters
    for (const letter of this.guess.letters) {
      this.guessedLetters.push(letter)
    }

    if (correctGuess) {
      this.status = WordleGameStatus.Won
      this.endTime = Date.now()
    } else if (this.guessIndex + 1 == this.guesses.length) {
      this.status = WordleGameStatus.Lost
      this.endTime = Date.now()
    } else {
      this.guessIndex++
    }
  }
}
