import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'

export class WordleGame {
  constructor(secretWord?: string, numberOfGuesses: number = 6) {
    if (!secretWord) secretWord = WordsService.getRandomWord()
    this.numberOfGuesses = numberOfGuesses
    this.restartGame(secretWord)
  }
  guesses = new Array<Word>()
  secretWord = ''
  numberOfGuesses = 6
  validWordList = new Array<string>()
  guess!: Word

  restartGame(secretWord: string) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)
    for (let iWord = 0; iWord < this.numberOfGuesses; iWord++) {
      const word = new Word(secretWord.length)
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
  }

  removeGuess() {
    while (this.guess.text !== '') {
      this.guess.pop()
    }
  }

  selectGuess(word: string) {
    this.removeGuess()
    for (let i = 0; i < word.length; i++) {
      if (this.guess.letters[i].char === '') {
        this.guess.push(word[i])
      }
    }
  }

  submitGuess() {
    this.guess.check(this.secretWord)
    const index = this.guesses.indexOf(this.guess)
    if (index < this.guesses.length - 1) {
      this.guess = this.guesses[index + 1]
    }
  }
}
