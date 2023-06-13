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
      case LetterStatus.Correct:
        return 'correct'
      case LetterStatus.Misplaced:
        return 'misplaced'
      case LetterStatus.Wrong:
        return 'wrong'
      default:
        return 'grey-darken-1'
    }
  }
}
