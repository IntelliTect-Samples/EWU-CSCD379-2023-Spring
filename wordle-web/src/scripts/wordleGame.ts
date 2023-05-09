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
    if (!secretWord) secretWord = WordsService.getRandomWord()
    this.numberOfGuesses = numberOfGuesses
    this.restartGame(secretWord)
    this.count = 0
  }
  guessedLetters: Letter[] = []
  guesses = new Array<Word>()
  secretWord = ''
  list = WordsService.getWordList()
  status = WordleGameStatus.Active
  guess!: Word
  numberOfGuesses = 6
  count: number
  counter: any
  // // check length of guess
  //   if (this.letters.length !== secretWord.length) {
  //     console.log('wrong length')
  //     return
  //   }

  // 5 things:
  // 1) When the user enters their username we have to start the interval
  // 2) When the user clicks the button we have to stop the interval
  // 3) When the user clicks enter we have to return a boolean stating if the game is over
  // 4) We have to display the count

  async restartGame(secretWord: string, numberOfGuesses: number = 6) {
    this.secretWord = secretWord
    this.guesses.splice(0)

    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
    this.status = WordleGameStatus.Active
  }

  submitGuess(time : any): boolean {
    let gameOver: boolean = false
    // put logic to win here.
    this.guess.check(this.secretWord)

    // Update the guessed letters
    for (const letter of this.guess.letters) {
      this.guessedLetters.push(letter)
    }

    // Changes list of valid words after each submission
    this.list = WordsService.validWords(this.guess, this.list)

    const index = this.guesses.indexOf(this.guess)

    if (this.secretWord !== this.guess.text && index < this.guesses.length - 1) {
      this.guess = this.guesses[index + 1]
    } else {
      // The game is over
      gameOver = true
      localStorage.endTime = Date.now()

      localStorage.total_time = localStorage.endTime - localStorage.startTime
      console.log("Inserting Score");
      Axios.post('Player/InsertScore', {
        Name: localStorage.name,
        NumAttempts: index + 1,
        AverageSecondsPerGame: time
      })
        .then((response) => {
          console.log(response.data)
        })
        .catch((error) => {
          console.log(error)
        })
    }
    return gameOver
  }
}
