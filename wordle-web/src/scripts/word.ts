import { Letter, LetterStatus } from './letter'

export class Word {
  public letters: Letter[] = Array<Letter>()

  constructor(word?: string | null, numberOfLetters: number = 5) {
    if (word) {
      for (const letter of word) {
        this.letters.push(new Letter(letter))
      }
    } else {
      for (let i = this.letters.length; i < numberOfLetters; i++) {
        this.letters.push(new Letter())
      }
    }
  }

  get text(): string {
    return this.letters.map((l) => l.char).join('')
  }

  push(char: string) {
    for (const letter of this.letters) {
      if (letter.char === '') {
        letter.char = char
        break
      }
    }
  }

  pop() {
    for (let i = this.letters.length - 1; i >= 0; i--) {
      if (this.letters[i].char !== '') {
        this.letters[i].char = ''
        break
      }
    }
  }

  check(secretWord: string): boolean {
    console.log(this.text)

    // check if the letters are valid
    const guessChars = this.letters.map((l) => l.char)
    const secretChars = secretWord.toUpperCase().split('')
    let isCorrect = true
    for (let i = 0; i < 5; i++) {
      if (this.letters[i].char === secretChars[i]) {
        this.letters[i].status = LetterStatus.Correct
        guessChars[i] = '_'
        secretChars[i] = '_'
        console.log(`Letter ${i} is correct`)
      } else {
        isCorrect = false
        this.letters[i].status = LetterStatus.Wrong
        console.log(`Letter ${i} is incorrect`)
      }
    }
    for (let i = 0; i < 5; i++) {
      if (guessChars[i] !== '_') {
        for (let j = 0; j < 5; j++) {
          if (secretChars[j] === guessChars[i]) {
            this.letters[i].status = LetterStatus.Misplaced
            guessChars[i] = '_'
            secretChars[j] = '_'
            console.log(`Letter ${i} is misplaced`)
            break
          }
        }
      }
    }

    console.log(guessChars)
    console.log(secretChars)
    console.log(isCorrect)

    return isCorrect
  }
}
