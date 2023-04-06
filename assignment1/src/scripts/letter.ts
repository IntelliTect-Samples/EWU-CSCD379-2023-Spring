//Class that represents a letter in the bootleg wordle game
export enum LetterStatus {
    Unknown = 0,
    Correct,
    Misplaced,
    Wrong
}
export class letter {
    letter: string;
    status: LetterStatus = LetterStatus.Unknown;

    constructor(letter: string){
        this.letter = letter;
    }

    get color(){
        switch(this.status){
            case LetterStatus.Correct:
                return 'green';
            case LetterStatus.Misplaced:
                return 'gold';
            case LetterStatus.Wrong:
                return 'black';
        }
        return 'grey';
    }
}