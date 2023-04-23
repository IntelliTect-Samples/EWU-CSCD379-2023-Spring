import type {Letter} from "@/scripts/letter";
import {LetterStatus} from "@/scripts/letter";

export default class Word {
    public static ValidWords(words: string[], guesses: Letter[]) {
        let validList:string[] = [];

        const correctGuesses = guesses.filter(g=>g.status === LetterStatus.Correct || g.status === LetterStatus.Misplaced);
        words.forEach((word) => {
            let valid = true;
            correctGuesses.forEach((guess) => {
                if(!word.includes(guess.letter)) {
                    valid = false;
                }
            });
            if(valid) {
                validList.push(word);
            }
        });
        guesses.forEach((guess) => {
            if(guess.status === LetterStatus.Wrong) {
                validList = validList.filter((word) => !word.includes(guess.letter))
            }
        });
        return validList;
    }
}