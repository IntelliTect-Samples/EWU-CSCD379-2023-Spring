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
                return '--v-correct';
            case LetterStatus.Misplaced:
                return '--v-misplaced';
            case LetterStatus.Wrong:
                return '--v-wrong';
        }
        return '--v-unknown';
    }
}