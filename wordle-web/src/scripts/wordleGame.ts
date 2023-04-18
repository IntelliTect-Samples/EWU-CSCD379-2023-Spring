import { Letter, LetterStatus } from '@/scripts/letter'
import { Word } from '@/scripts/word'
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

  restartGame(secretWord?: string | null, numberOfGuesses: number = 6) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)

    for(let i = 0; i < 6; i++){
      const word = new Word();
    }    
  }

  get currentGuess() {
    return this.guesses[this.currentGuessIndex]
  }

  submitGuess() {
    this.currentGuess.check(this.secretWord)
  }
}