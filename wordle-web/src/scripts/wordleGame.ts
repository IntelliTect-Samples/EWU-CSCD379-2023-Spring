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
  currentPlayer = 'Guest'
  amountOfGuesses = 0

  // // check length of guess
  //   if (this.letters.length !== secretWord.length) {
  //     console.log('wrong length')
  //     return
  //   }

  async restartGame(secretWord?: string | null, numberOfGuesses: number = 6) {
    this.secretWord = secretWord || (await WordsService.getWordFromApi())
    this.guesses.splice(0)

    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
    this.status = WordleGameStatus.Active
  }

  submitGuess() {
    // put logic to win here.
    this.amountOfGuesses++
    if (this.guess.check(this.secretWord)) {
      this.postPlayerToApi(this.currentPlayer, this.amountOfGuesses)
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
    }
  }

  setPlayerName(name: string) {
    if (name != '' || name != null) {
      this.currentPlayer = name
    } else {
      this.currentPlayer = 'Guest'
    }
  }

  postPlayerToApi(name: string, attempts: number) {
    Axios.post('https://wordlewebapp2023.azurewebsites.net/Player', {
      playerName: name,
      gameCount: 1,
      averageAttempts: attempts
    })
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
  }
}
