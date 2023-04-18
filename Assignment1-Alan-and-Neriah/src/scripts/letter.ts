export enum LetterStatus {
  correct,
  incorrect,
  notGuessed,
  misplaced
}

export class Letter {
  public letter: string
  public status: LetterStatus = LetterStatus.notGuessed

  constructor(letter: string) {
    this.letter = letter
  }

  get color() {
    switch (this.status) {
      case LetterStatus.correct:
        return 'green'
      case LetterStatus.incorrect:
        return 'red'
      case LetterStatus.misplaced:
        return 'yellow'
      default:
        return 'grey'
    }
  }
}
