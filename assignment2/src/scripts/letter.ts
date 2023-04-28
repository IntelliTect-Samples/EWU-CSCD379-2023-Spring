export enum LetterStatus {
    NotGuessed = 0,
    Correct,
    Misplaced,
    Wrong
  }
  
  export class letter {
    char: string
    status: LetterStatus = LetterStatus.NotGuessed
  
    constructor(char: string = '', status?: LetterStatus) {
      this.char = char
      this.status = status ?? LetterStatus.NotGuessed
    }
}