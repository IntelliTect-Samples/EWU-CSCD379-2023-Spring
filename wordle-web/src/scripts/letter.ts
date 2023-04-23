// Class that represents a letter in the wordle word and status
// of the letter in the wordle word
export enum LetterStatus {
  NotGuessed = 0,
  Correct,
  Misplaced,
  Wrong
}

export class Letter {
  char: string
  status: LetterStatus = LetterStatus.NotGuessed
  index: number = NaN

  constructor(char: string = '', status?: LetterStatus, index?: number) {
    this.char = char
    this.status = status ?? LetterStatus.NotGuessed
    this.index = index ?? NaN
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
        return 'grey'
    }
  }
}
