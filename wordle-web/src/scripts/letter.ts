// Class that represents a letter in wordle (in guess and on keyboard)
export enum LetterStatus {
  NotGuessed = 0,
  Correct,
  Misplaced,
  Wrong
}
export class Letter {
  char: string
  status: LetterStatus = LetterStatus.NotGuessed

  constructor(letter: string = '', status?: LetterStatus) {
    this.char = letter
    this.status = status ?? LetterStatus.NotGuessed
  }

  get color() {
    switch (this.status) {
      case LetterStatus.NotGuessed:
        return 'grey'
      case LetterStatus.Correct:
        return 'green'
      case LetterStatus.Misplaced:
        return 'yellow'
      case LetterStatus.Wrong:
        return 'red'
      default:
        return 'grey'
    }
  }
}
