import { Letter, LetterStatus } from '@/scripts/letter'
import { Word } from '@/scripts/word'
import { ref, reactive } from 'vue'
import { WordsService } from './wordsService'

export enum WordleGameStatus {
  Active = 0, 
  Won = 1, 
  Lost = 2
}

export class WordleGame {
  constructor(secretWord?: string | null) {
    this.restartGame(secretWord)
  }
  currentGuessIndex = 0
  guesses = new Array<Word>()
  secretWord = ''
  status = 

  // // check length of guess
  //   if (this.letters.length !== secretWord.length) {
  //     console.log('wrong length')
  //     return
  //   }

  restartGame(secretWord?: string | null, numberOfGuesses: number = 6) {
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)

    for(let i = 0; i < 6; i++){
      const word = new Word()
      this.guesses.push(word)
    }    
    this.currentGuessIndex = 0
  }

  get currentGuess() {
    return this.guesses[this.currentGuessIndex]
  }

  submitGuess() {
    if(this.currentGuess.check(this.secretWord)) {
      this.status = WordleGameStatus.Won
    } else if(this.currentGuessIndex >= this.guesses.length){
      this.status = WordleGameStatus.Lost
    }
    this.currentGuessIndex++
  }
}