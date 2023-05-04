import { Letter, LetterStatus } from './letter'

export class Word {
  public letters: Array<Letter> = []

  constructor(word?: string|null, numberofLetters: number = 5) {
    if(word){
      for (const letter of word) {
        this.push(letter)
      }
    }else{
      for (let i = 0; i < numberofLetters; i++) {
        const letter = new Letter()
        this.letters.push(letter)
      }
    }
  }

  push(letter: string) {
    for (let i = 0; i < this.letters.length; i++) {
      if (this.letters[i].letter === '') {
        this.letters[i] = new Letter(letter)
        break
      }
    }
  }

  pop(){
    for (let i = this.letters.length - 1; i >= 0; i--) {
      if (this.letters[i].letter !== '') {
        this.letters[i] = new Letter()
        break
      }
    }
  }

  get text() {
    return this.letters.map((letter) => letter.letter).join('')
  }

  check(secret: string): boolean {
    const guessChars = this.letters.map((letter) => letter.letter)
    const secretChars = secret.split('')

    let correct = true
    for (let i = 0; i < guessChars.length; i++) {
      if (guessChars[i] === secretChars[i]) {
        this.letters[i].status = LetterStatus.correct
        guessChars[i] = '▓'
        secretChars[i] = '▓'
      } else {
        this.letters[i].status = LetterStatus.incorrect
        correct = false
      }
    }

    for (let i = 0; i < guessChars.length; i++) {
      if (guessChars[i] !== '▓') {
        for (let j = 0; j < secretChars.length; j++) {
          if (guessChars[i] === secretChars[j]) {
            this.letters[i].status = LetterStatus.misplaced
            guessChars[i] = '▓'
            secretChars[j] = '▓'
            break
          }
        }
      }
    }

    return correct
  }
}
