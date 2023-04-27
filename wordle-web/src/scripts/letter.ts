export enum LetterStatus {
  NotGuessed = 0,
  Correct,
  Misplaced,
  Wrong
}
export class Letter {
  char: string
  status: LetterStatus = 0

  constructor(char: string = '', status?: LetterStatus) {
    this.char = char.toUpperCase()
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
        return 'grey'
    }
  }
}