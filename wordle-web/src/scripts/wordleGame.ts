import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'

export class WordleGame {
  constructor(secretWord?: string | null) {
    this.restartGame(secretWord)
  }

  guesses = new Array<Word>()
  secretWord = ''

  restartGame(secretWord?: string | null) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)
  }

  submitGuess(guess: string) {
    const word = new Word(guess)
    this.guesses.push(word)
    word.check(this.secretWord)
  }
}
