// Class that represents a letter in the wordle word and status
// of the letter in the wordle word
export enum LetterStatus {
  NotGuessed = 0,
  Correct = 1,
  Misplaced = 2,
  Wrong = 3
}

export class Letter {
  char: string
  status: LetterStatus = LetterStatus.NotGuessed

  constructor(char: string, status?: LetterStatus) {
    this.char = char
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
