// Class that represents a letter in the wordle word and status
// of the letter in the wordle word
export enum LetterStatus {
    NotGuessed = 0,
    Correct,
    Misplaced,
    Wrong
}


export class Letter {
    letter: string;
    status: LetterStatus = LetterStatus.NotGuessed;

    constructor(letter: string) {
        this.letter = letter;
    }

    get color() {
        switch (this.status) {
            case LetterStatus.Correct:
                return 'green';
            case LetterStatus.Misplaced:
                return 'orange';
            case LetterStatus.Wrong:
                return 'red';
            default:
                return 'grey';
        }
    }
}