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
  possibleWords = new Array<string>()
  possibleGuess = new Array<string>()
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

  getPossibleWords() {
    //console.log('In getPossibleWords')
    //console.log(this.possibleWords.length)
    return this.possibleWords.length
  }

  getPossibleGuesses() {
    //console.log('In getPossibleGuesses')
    //console.log(this.possibleGuess.length)
    return this.possibleGuess.length
  }

  restartGame(secretWord?: string | null, numberOfGuesses: number = 6) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)

    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
    this.possibleWords = WordsService.getAll()
    this.possibleGuess = WordsService.getAll()
    this.status = WordleGameStatus.Active
  }

  showWorkingWords() {
    let guessSplit = this.guess.text.split('')
    let letterList = new Array(guessSplit.length)

    for (let i = 0; i < guessSplit.length; i++) {
      letterList[i] = guessSplit[i]
    }
    //console.log('Testing current words')
    //console.log(letterList)
    this.possibleGuess = WordsService.currentWords(letterList, this.possibleWords)
    //console.log(this.possibleGuess)
  }

  showPossibleWords() {
    let letterList = new Array(this.allGuessData.length)
    let indexTracker = 0
    for (const letter of this.allGuessData) {
      letterList[indexTracker] = new Array(3)
      letterList[indexTracker][0] = letter.char
      letterList[indexTracker][2] = letter.index
      if (letter.status === LetterStatus.Correct) {
        letterList[indexTracker][1] = '0'
      } else if (letter.status === LetterStatus.Misplaced) {
        letterList[indexTracker][1] = '1'
      } else {
        letterList[indexTracker][1] = '2'
      }
      indexTracker = indexTracker + 1
    }
    this.possibleWords = WordsService.validWords(letterList)
    //console.log(this.possibleWords.length)
    //console.log(this.possibleWords)
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
    this.showPossibleWords()

    console.log('GUESSED LETTERS CHECK')
    console.log(this.guessedLetters)

    const index = this.guesses.indexOf(this.guess)
    if (index < this.guesses.length - 1) {
      this.guess = this.guesses[index + 1]
    } else {
      // The game is over
    }
    this.showWorkingWords()
    console.log('CHECK GOES HERE THIS IS WORKING')
    console.log(this.guesses[0])
  }
}
