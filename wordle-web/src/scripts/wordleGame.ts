import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'
import type { Letter } from './letter'

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

  // // check length of guess
  //   if (this.letters.length !== secretWord.length) {
  //     console.log('wrong length')
  //     return
  //   }

  restartGame(secretWord?: string | null, numberOfGuesses: number = 6) {
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

    // Update the guessed letters
    for (const letter of this.guess.letters) {
      this.guessedLetters.push(letter)
    }

    console.log(this.guessedLetters)

    const index = this.guesses.indexOf(this.guess)
    if (index < this.guesses.length - 1) {
      this.guess = this.guesses[index + 1]
    } else {
      // The game is over
    }
  }
  
  getAvailableWords() {
    const availableWords: string[] = [];
    const secretWordChars = this.secretWord.split('');
    const wordList = WordsService.getWordsList();

    for (const word of wordList) {
      const chars = word.split('');
      let isAvailable = true;

      for (let i = 0; i < chars.length; i++) {
        const char = chars[i];
        const index = secretWordChars.indexOf(char);

        if (index === -1) {
          isAvailable = false;
          break;
        } else {
          secretWordChars.splice(index, 1);
        }
      }

      if (isAvailable) {
        availableWords.push(word);
      }

      if (secretWordChars.length === 0) {
        break;
      } else {
        secretWordChars.splice(0);
        secretWordChars.push(...this.secretWord.split(''));
      }
    }

    return availableWords;
  }
}
