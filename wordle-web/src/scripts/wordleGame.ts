import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'

export class WordleGame {
  constructor(secretWord?: string | null) {
    this.restartGame(secretWord)
  }
  guesses = new Array<Word>()
  secretWord = ''

  // // check length of guess
  //   if (this.letters.length !== secretWord.length) {
  //     console.log('wrong length')
  //     return
  //   }

  restartGame(secretWord?: string | null) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)
  }

  submitGuess(guess: string) {
    const word = new Word('plate')
    this.guesses.push(word)
    word.check(this.secretWord)
    const list = WordsService.getWordList()
    WordsService.validWords(word, list)
  }
}
