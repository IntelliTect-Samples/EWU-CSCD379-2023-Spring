import { Letter } from "./letter";

export class Word {
    public letters =  Array<Letter>();

    constructor (word?: string | null) {
        if (word) {
            for(const letter of word) {
                this.letters.push(new Letter(letter))
            }
        }
    }

    get text() {
        return this.letters.map (1) => l.char.join('');
    }

    push(letter: Letter) {
        this.letters.push(letter)
    }
}
