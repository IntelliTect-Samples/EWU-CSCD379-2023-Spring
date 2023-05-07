import { Letter, LetterStatus } from './letter'

export class Word {
  public letters: Letter[] = Array<Letter>()

  constructor(word?: string | null, numberOfLetters: number = 5) {
    if (word) {
      // Add word letters to array.
      for (const letter of word) {
        this.letters.push(new Letter(letter))
      }
    } else {
      // Add empty letters to array.
      for (let i = this.letters.length; i < numberOfLetters; i++) {
        this.letters.push(new Letter())
      }
    }
  }

  get word() {
    return this.letters.map((l: Letter) => l.char).join('')
  }

  push(char: string) {
    // Find the first empty letter and replace it.
    for (const letter of this.letters) {
      if (letter.char === '') {
        letter.char = char
        return
      }
    }
  }

  pop() {
    for (let i = this.letters.length - 1; i >= 0; i--) {
      if (this.letters[i].char !== '') {
        this.letters[i].char = ''
        return
      }
    }
  }

  checkWord(secretWord: string): boolean {
    const guessChars: string[] = this.letters.map((l) => l.char)
    const secretChars: string[] = secretWord.split('')
    let isCorrect: boolean = true

    console.log(this.word)

    // Check if the letters are valid.
    for (let i = 0; i < 5; i++) {
      if (this.letters[i].char === secretWord[i]) {
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

    // Check if the letters are in the right place.
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
