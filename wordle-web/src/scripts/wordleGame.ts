import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'
import { LetterStatus, type Letter } from './letter'
import { Player } from './playerService'
import Axios from 'axios'

export enum WordleGameStatus {
  Active = 0,
  Won = 1,
  Lost = 2
}

export interface PlayerResult {
  playerId: number
  playerName?: string
  attempts: number
  duration: number
  success: boolean
  score?: number
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
  startTime!: number
  guessIndex = 0
  onGameEnd: ((result: PlayerResult) => void) | null = null

  async restartGame(secretWord: string, numberOfGuesses: number = 6) {
    this.secretWord = secretWord
    this.guesses.splice(0)
    this.guessedLetters.splice(0)

    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
    this.status = WordleGameStatus.Active
    this.startTime = Date.now()
  }
  /////////

  submitGuess() {
    this.guess.check(this.secretWord)

    if (this.guess.letters.every((l) => l.status == LetterStatus.Correct)) {
      this.endGame(true)
    }
    // put logic to win here.
    const correctGuess = this.guess.check(this.secretWord)
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
      this.endGame(false)
    }
  }
  async endGame(win: boolean) {
    const elapsedMs = Date.now() - this.startTime
    const guesses = this.guesses.indexOf(this.guess) + 1

    const playerResult = {
      PlayerId: Player.Id.value,
      Attempts: guesses,
      Duration: elapsedMs,
      Success: win
    }

    const response = await Axios.post('/playerresult', playerResult)
    if (this.onGameEnd) {
      this.onGameEnd(response.data as PlayerResult)
    }
  }
}
