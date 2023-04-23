import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'
import { Letter, LetterStatus } from './letter'

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
  allGuessData: Letter[] = []
  guesses = new Array<Word>()
  secretWord = ''
  status = WordleGameStatus.Active
  guess!: Word
  numberOfGuesses = 6

  // // check length of guess
  //   if (this.letters.length !== secretWord.length) {
  //     console.log('wrong length')
  //     return
  //   }

  restartGame(secretWord?: string | null, numberOfGuesses: number = 6) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)

    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
    this.status = WordleGameStatus.Active
  }

  showPossibleWords() {
    let letterList = new Array(this.allGuessData.length)
    let indexTracker = 0
    for (const letter of this.allGuessData) {
      letterList[indexTracker] = new Array(3)
      letterList[indexTracker][0] = letter.char
      letterList[indexTracker][2] = letter.index
      if (letter.status === LetterStatus.Correct) {
        letterList[indexTracker][1] = 'Correct'
      } else if (letter.status === LetterStatus.Misplaced) {
        letterList[indexTracker][1] = 'Misplaced'
      } else {
        letterList[indexTracker][1] = 'Wrong'
      }
      indexTracker = indexTracker + 1
    }
    console.log(WordsService.validWords(letterList))
  }

  guessedLetterCheck() {
    // Update the guessed letters
    let indexCounter = 0
    for (const letter of this.guess.letters) {
      let present = false
      for (const guessLetter of this.guessedLetters) {
        if (guessLetter.char === letter.char) {
          if (guessLetter.status >= letter.status) {
            guessLetter.status = letter.status
            guessLetter.index = indexCounter
            present = true
          } else {
            present = true
          }
        }
      }
      if (!present) {
        let newLetter = new Letter(letter.char, letter.status, indexCounter)
        this.guessedLetters.push(newLetter)
      }
      let guessData = new Letter(letter.char, letter.status, indexCounter)
      this.allGuessData.push(guessData)
      indexCounter = indexCounter + 1
    }
  }

  submitGuess() {
    // put logic to win here.
    this.guess.check(this.secretWord)
    /*for (const letter of this.guess.letters) {
      console.log(letter.char)
      console.log(letter.status)
    }*/

    this.guessedLetterCheck()
    console.log('GUESSED LETTERS CHECK')
    console.log(this.guessedLetters)

    const index = this.guesses.indexOf(this.guess)
    if (index < this.guesses.length - 1) {
      this.guess = this.guesses[index + 1]
    } else {
      // The game is over
    }

    console.log('CHECK GOES HERE THIS IS WORKING')
    console.log(this.guesses[0])
  }
}
