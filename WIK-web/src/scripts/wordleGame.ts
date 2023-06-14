import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'
import type { Letter } from './letter'
import Axios from 'axios'
import { Player } from './player'

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
  guess!: Word
  numberOfGuesses = 6
  currentPlayer = localStorage.getItem('name') || 'Guest'
  amountOfGuesses = 0

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
    this.guess = this.guesses[0]
    this.status = WordleGameStatus.Active
  }

  submitGuess(route: string, seconds: number): boolean {
    // put logic to win here.
    this.amountOfGuesses++
    if (this.guess.check(this.secretWord)) {
      if (route === '/wordoftheday') {
        this.postScoreToDaily(seconds)
        return true
      } else {
        this.postPlayerToApi(this.currentPlayer, this.amountOfGuesses, seconds)
        return true
      }
    }

    // Update the guessed letters
    for (const letter of this.guess.letters) {
      this.guessedLetters.push(letter)
    }

    console.log(this.guessedLetters)

    const index = this.guesses.indexOf(this.guess)
    if (index < this.guesses.length - 1) {
      this.guess = this.guesses[index + 1]
      return false
    } else {
      // The game is over
      return true
    }
  }

  setPlayerName(name: string) {
    if (name != '' || name != null) {
      localStorage.setItem('name', name)
      this.currentPlayer = name
    } else {
      localStorage.setItem('name', 'Guest')
      this.currentPlayer = 'Guest'
    }
  }

  postPlayerToApi(name: string, attempts: number, seconds: number) {
    Axios.post(
      '/leaderboard?name='.concat(name, '&attempts=', attempts.toString()),
      name.concat(',', attempts.toString(), ',', attempts.toString())
    )
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
  }
  postScoreToDaily(seconds: number) {
    console.log(seconds.toString())
    Axios.post(
      '/leaderboard/daily?word=' +
        this.secretWord +
        '&attempts=' +
        this.amountOfGuesses.toString() +
        '&seconds=' +
        seconds.toString()
    )
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
    Axios.post('/Leaderboard/completion?name=' + this.currentPlayer + '&word=' + this.secretWord)
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
  }
}