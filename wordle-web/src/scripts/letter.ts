// Class that represents a letter in the wordle word and status

export enum letterStatus {
  NotGuessed = 0,
  Correct,
  Misplaced,
  Wrong
}

export class Letter {
  letter: string
  status: letterStatus = letterStatus.NotGuessed

  constructor(letter: string) {
    this.letter = letter
  }

  get color() {
    switch (this.status) {
      case letterStatus.Correct:
        return 'green'
      case letterStatus.Misplaced:
        return 'Yellow'
      case letterStatus.Wrong:
        return 'Red'
      default:
        return 'Grey'
    }
  }
}
