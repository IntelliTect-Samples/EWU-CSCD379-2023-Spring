import { WordService } from '@/scripts/wordService'
import { Word } from '@/scripts/word'
//import { Letter, LetterStatus } from '@/scripts/letter'
//import { ref, reactive } from 'vue'

export class WordGame {
  constructor(secret?: string | null) {
    this.restartGame(secret)
  }

  guesses = new Array<Word>()
  secret = ''

  restartGame(secret?: string | null) {
    this.guesses.splice(0)
    this.secret = secret || WordService.getRandomWord()
  }

  submitGuess(guess: string) {
    const word = new Word(guess)
    this.guesses.push(word)
    word.check(this.secret)
  }
}
