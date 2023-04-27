import type { Letter } from '@/scripts/letter'
import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'

export class WordleGame {
  constructor(secretWord?: string, numberOfGuesses: number = 6) {
    if (!secretWord) secretWord = WordsService.getRandomWord()
    this.numberOfGuesses = numberOfGuesses
    this.restartGame(secretWord)
  }
  guesses = new Array<Word>()
  guessedLetters: Letter[] = []
  secretWord = ''
  numberOfGuesses = 6
  guess!: Word

  win: boolean = false
  continue: boolean = true
  knownLetters: string[] = ['', '', '', '', '']
  notAllowedLetters: string[] = []
  containsLetters: string[] = []
  validWordList: string[] = this.getValidWords()

  restartGame(secretWord?: string) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)
    // create a word for each guess
    for (let iWord = 0; iWord < this.numberOfGuesses; iWord++) {
      const word = new Word(this.secretWord.length)
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
    this.win = false
    this.continue = true
    this.knownLetters = ['', '', '', '', '']
    this.notAllowedLetters = []
    this.containsLetters = []
    this.guessedLetters = []
    this.validWordList = this.getValidWords()
  }

  clearCurrentGuess() {
    this.guess.clear()
  }

  endGame(): boolean {
    return this.win
  }

  getValidWords(): string[] {
    this.validWordList = WordsService.validWords(
      this.knownLetters,
      this.notAllowedLetters,
      this.containsLetters,
      this.secretWord.length
    )
    return this.validWordList
  }

  submitGuess() {
    // put logic to win here.
    this.win = this.guess.check(this.secretWord)
    // Update the guessed letters
    for (const letter of this.guess.letters) {
      if (letter.status == 1) {
        for (const guessLetter of this.guessedLetters) {
          if (guessLetter.char == letter.char) {
            guessLetter.status = 1
          }
        }
        this.guessedLetters.push(letter)
      } else {
        this.guessedLetters.push(letter)
      }
    }
    const index = this.guesses.indexOf(this.guess)
    if (index < this.guesses.length - 1) {
      this.updateRegexList()
      this.guess = this.guesses[index + 1]
    } else {
      this.continue = false
    }
  }

  inputWord(word: Word) {
    for (let i = 0; i < word.letters.length; i++) {
      const letter = word.letters[i]
      const ch = letter.char
      this.guess.push(ch)
    }
  }

  updateRegexList() {
    const word = this.guess
    const tempContainsLetters: string[] = []
    for (let i = 0; i < word.letters.length; i++) {
      const letter = word.letters[i]
      if (letter.status === 1) {
        this.knownLetters[i] = letter.char
      } else if (letter.status === 3) {
        const ch = letter.char
        if (!this.notAllowedLetters.includes(ch)) {
          this.notAllowedLetters.push(ch)
        }
      } else if (letter.status === 2) {
        const ch = letter.char
        tempContainsLetters.push(ch)
      }
    }
    if (tempContainsLetters.length > 0) {
      tempContainsLetters.sort()
      const newContainsLetters: string[] = []
      for (let i = this.containsLetters.length; i > 0; i--) {
        const ch = this.containsLetters[i]
        if (tempContainsLetters.includes(ch)) {
          tempContainsLetters.splice(tempContainsLetters.indexOf(ch), 1)
          this.containsLetters.splice(i, 1)
        }
        newContainsLetters.push(ch)
      }
      if (tempContainsLetters.length > 0) {
        for (let i = 0; i < tempContainsLetters.length; i++) {
          newContainsLetters.push(tempContainsLetters[i])
        }
      }
      if (this.containsLetters.length > 0) {
        for (let i = 0; i < this.containsLetters.length; i++) {
          newContainsLetters.push(this.containsLetters[i])
        }
      }
      this.containsLetters = newContainsLetters
      this.containsLetters.sort()
    }
    this.validWordList = this.getValidWords()
  }
}
