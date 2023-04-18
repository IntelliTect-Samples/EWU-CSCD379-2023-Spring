import { Letter, LetterStatus } from './letter'

export class Word {
  public letters: Array<Letter> = []

  constructor(word: string) {
    for (let i = 0; i < word.length; i++) {
      this.letters.push(new Letter(word[i]))
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
