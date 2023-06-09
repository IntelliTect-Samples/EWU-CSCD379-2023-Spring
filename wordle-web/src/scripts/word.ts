import { Letter, LetterStatus } from './letter'
import { WordsService } from './wordsService'

export class Word {
  public letters = Array<Letter>()
  public isScored = false
  public key =
    Math.random().toString(36).substring(2, 15) + Math.random().toString(36).substring(2, 15)

  constructor(word?: string | null, numberOfLetters: number = 5) {
    if (word) {
      if (typeof word == 'number') {
        // Add one letter for each number. With blank spots
        for (let i = 0; i < word; i++) {
          this.letters.push(new Letter(''))
        }
      } else {
        // add word letters to array
        for (const letter of word) {
          this.letters.push(new Letter(letter))
        }
      }
    } else {
      // add empty letters to array
      for (let i = this.letters.length; i < numberOfLetters; i++) {
        this.letters.push(new Letter())
      }
    }
  }

  get text() {
    return this.letters.map((l) => l.char).join('')
  }

  // See if every letter is filled
  get isFilled() {
    return this.letters.every((l) => l.char !== '')
  }

  get isValidWord() {
    return this.isFilled && WordsService.isValidWord(this.text)
  }

  // Clear the guess
  clear() {
    for (const letter of this.letters) {
      letter.char = ''
    }
  }
  set(word: string) {
    this.clear()
    for (const letter of word) {
      this.push(letter)
    }
  }

  push(char: string) {
    // Find the first empty letter and replace it
    for (const letter of this.letters) {
      if (letter.char === '') {
        letter.char = char.toLowerCase()
        return
      }
    }
  }

  // Remove the last letter
  pop() {
    for (let i = this.letters.length - 1; i >= 0; i--) {
      if (this.letters[i].char !== '') {
        this.letters[i].char = ''
        return
      }
    }
  }

  check(secretWord: string): boolean {
    //console.log(this.text)
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
        //console.log(`Letter ${i} is correct`)
      } else {
        isCorrect = false
        this.letters[i].status = LetterStatus.Wrong
        //console.log(`Letter ${i} is incorrect`)
      }
    }

    for (let i = 0; i < 5; i++) {
      if (guessChars[i] !== '_') {
        for (let j = 0; j < 5; j++) {
          if (secretChars[j] === guessChars[i]) {
            this.letters[i].status = LetterStatus.Misplaced
            guessChars[i] = '_'
            secretChars[j] = '_'
            //console.log(`Letter ${i} is misplaced`)
            break
          }
        }
      }
    }

    this.isScored = true
    return isCorrect
  }
}
