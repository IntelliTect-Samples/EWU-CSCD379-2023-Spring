// Class that represents a letter in the game grid, with its position, status, and value
export enum LetterStatus {
    NotGuessed = 0,
    Correct,
    Misplaced,
    Incorrect
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
                return "green";
            case LetterStatus.Misplaced:
                return "orange";
            case LetterStatus.Incorrect:
                return "red";
            default:
                return "grey";
        }
    }
}

