import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'
import { LetterStatus, type Letter } from './letter'

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
  startTime!: number
  currentTime!: number
  startingPoints = 60
  elapsedTime = 0
  timerInterval: any = null
  finalScore = 0

  // // check length of guess
  //   if (this.letters.length !== secretWord.length) {
  //     console.log('wrong length')
  //     return
  //   }

  async restartGame(secretWord?: string | null, numberOfGuesses: number = 6) {
    console.log('Starting new game...')
    this.secretWord = secretWord || (await WordsService.getWordFromApi())
    this.guesses.splice(0)
    this.guessedLetters.splice(0)

    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
    this.status = WordleGameStatus.Active
    this.startTime = Date.now()
    this.startingPoints = 60
    if (this.timerInterval) {
      this.stopTimer()
    }
    this.startTimer()
  }

  submitGuess() {
    // put logic to win here.
    this.guess.check(this.secretWord)
    if (this.guess.letters.every((l) => l.status == LetterStatus.Correct)) {
      console.log('you Win!')

      const finalTime = (Date.now() - this.startTime) / 1000
      const remainingGuesses = this.numberOfGuesses - this.guesses.indexOf(this.guess) - 1
      this.finalScore = this.getScore(finalTime, remainingGuesses)
      console.log('final score = ' + this.finalScore)

      // this.gameResult = { finalScore: finalScore, finalTime: finalTime, remainingGuesses: remainingGuesses, secretWord: this.secretWord }
      this.status = WordleGameStatus.Won
      this.stopTimer()
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
      // the game is over, restart it.
      console.log('game over')
      this.status = WordleGameStatus.Lost
      this.restartGame()
    }
  }

  getScore(finalTime: number, remainingGuesses: number) {
    const baseScore = this.startingPoints - (6 - remainingGuesses) * 10
    const finalScore = baseScore * remainingGuesses - finalTime
    return finalScore
  }

  startTimer() {
    this.timerInterval = setInterval(() => {
      this.elapsedTime = Math.floor((Date.now() - this.startTime) / 1000)
    }, 1000)
  }

  stopTimer() {
    clearInterval(this.timerInterval)
  }

  // report score to server
}
