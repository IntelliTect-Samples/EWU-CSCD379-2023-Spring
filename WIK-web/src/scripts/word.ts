import { Letter, LetterStatus } from './letter'

export class Word {
  public letters = Array<Letter>()
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
        return
      }
    }
  }

  check(secretWord: string): boolean {
    console.log(this.text)

    const guessChars = this.letters.map((l) => l.char)
    // if(g.length != secretWord.length){
    //     console.log('wrong length')
    //     guess.value = ""
    //     return
    // }
    const word = this.letters
    const secretChars = secretWord.split('')
    let isCorrect = true

    for (let i = 0; i < secretWord.length; i++) {
      //word.push(new Letter(guess.charAt(i)))
      if (word[i].char === secretChars[i]) {
        word[i].status = LetterStatus.Correct
        guessChars[i] = '_'
        secretChars[i] = '_'
      } else {
        isCorrect = false
      }
    }
    if (isCorrect) {
      alert('WINNER!')
    }
    for (let i = 0; i < secretWord.length; i++) {
      if (word[i].status != LetterStatus.Correct) {
        if (secretChars.includes(word[i].char)) {
          word[i].status = LetterStatus.Misplaced
          secretChars[secretChars.indexOf(word[i].char)] = '_'
        } else {
          word[i].status = LetterStatus.Wrong
        }
      }
      console.log(`Letter ${i} is ${word[i].status}`)
    }
    return isCorrect
  }
}
