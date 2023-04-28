import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'
import { Letter, LetterStatus } from './letter'

export enum WordleGameStatus {
  Active = 0,
  Won = 1,
  Lost = 2
}

export class WordleGame {
  constructor(secretWord?: string, numberOfGuesses: number = 6) {
    if (!secretWord) secretWord = WordsService.getRandomWord()
    this.numberOfGuesses = numberOfGuesses
    this.restartGame(secretWord)
  }
  guessedLetters: Letter[] = []
  guesses = new Array<Word>()
  secretWord = ''
  status = WordleGameStatus.Active
  guess!: Word
  numberOfGuesses = 6

  restartGame(secretWord?: string | null, numberOfGuesses: number = 6) {
    WordsService.loadWords()
    this.secretWord = secretWord || WordsService.getRandomWord()
    this.guesses.splice(0)

    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
    this.status = WordleGameStatus.Active
  }

  submitGuess() {
    // put logic to win here.
    this.guess.check(this.secretWord)

    WordsService.availableWords(this.guess)

    // Update the guessed letters
    for (const letter of this.guess.letters) {
      this.validateLetter(letter)
    }

    console.log(this.guessedLetters)

    const index = this.guesses.indexOf(this.guess)
    if (index < this.guesses.length - 1) {
      this.guess = this.guesses[index + 1]
    } else {
      // The game is over
    }
  }

  validateLetter(letter: Letter) {
    const currentLetter = this.guessedLetters.find(
      (guessedLetter) => guessedLetter.char == letter.char
    )

    if (currentLetter) {
      if (letter.status === LetterStatus.Misplaced && currentLetter.status == LetterStatus.Wrong)
        currentLetter.status = letter.status
      if (letter.status === LetterStatus.Correct && currentLetter.status !== LetterStatus.Correct)
        currentLetter.status = letter.status
    } else {
      this.guessedLetters.push(new Letter(letter.char, letter.status))
    }
  }
}
