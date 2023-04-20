import { Letter, LetterStatus } from './letter'
import { Word } from './word'
import { ref, reactive } from 'vue'
import { WordsService } from './wordsService'

export class WordleGame {
  constructor(secretWord?: string | null) {
    this.restartGame(secretWord)
  }

  currentGuessIndex = 0
  guesses = new Array<Word>()
  secretWord = ''

  // // check length of guess
  //   if (this.letters.length !== secretWord.length) {
  //     console.log('wrong length')
  //     return
  //   }

  get currentGuess(){
    return this.guesses[this.currentGuessIndex]
  }

  restartGame(secretWord?: string | null, guessNum: number = 6) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)
    this.currentGuessIndex = 0

    for(let i = 0; i < guessNum; i++){
      const word = new Word()
      this.guesses.push(word)
    }
  }

  submitGuess() {
    this.currentGuess.check(this.secretWord)
    this.currentGuessIndex += 1
  }
}
