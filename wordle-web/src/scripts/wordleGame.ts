import { Word } from '@/scripts/word'
import { WordsService } from './Services/wordsService'
import type { Letter } from '@/scripts/letter'

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
      return
    }
    // put logic to win here.
    const correctGuess = this.guess.checkWord(this.secretWord)
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
