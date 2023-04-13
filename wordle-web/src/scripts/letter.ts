//class that represents a letter in the wordle word and status of the letter
export enum LetterStatus {
    NotGuessed = 0,
    Correct,
    Misplaced,
    Wrong
}
export class Letter {
    letter: string;
    status: LetterStatus = 0;

    constructor(letter: string) {
        this.letter = letter.toUpperCase();
    }

    get color() {
        switch (this.status) {
            case LetterStatus.Correct:
                return "green";
            case LetterStatus.Misplaced:
                return "yellow";
            case LetterStatus.Wrong:
                return "red";
            default:
                return "grey";
        }
    }
}
