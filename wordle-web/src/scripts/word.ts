import { Letter, LetterStatus } from './letter'

export class Word {
  public letters = Array<Letter>()

  constructor(word?: string | null) {
    if (word) {
      // add word letters to array
      for (const letter of word) {
        this.letters.push(new Letter(letter))
      }
    }
  }

  get text() {
    return this.letters.map((l) => l.char).join('')
  }

  push(letter: Letter) {
    this.letters.push(letter)
  }

  check(secretWord: string): boolean {
    console.log(this.text)

    // check if the letters are valid
    //const results = new Word()
    const guessChars = this.letters.map((l) => l.char)
    const secretChars = secretWord.split('')
    let isCorrect = true
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
    // check if the letters are in the right place
  }
}
