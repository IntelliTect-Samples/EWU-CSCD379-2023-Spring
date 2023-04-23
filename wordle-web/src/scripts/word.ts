import type {Letter} from "@/scripts/letter";
import {LetterStatus} from "@/scripts/letter";

export default class Word {
    public static ValidWords(words: string[], guesses: Letter[]) {
        const validGuesses = guesses
            .filter(guess => guess.status === LetterStatus.Correct || guess.status === LetterStatus.Misplaced)
            .map(guess => guess.letter);

        const invalidGuesses = guesses
            .filter(guess => guess.status === LetterStatus.Wrong)
            .map(guess => guess.letter);

        return words.filter(word => {
            const letters = word.split('');
            return letters.every(letter => {
                return !invalidGuesses.includes(letter) //&& validGuesses.includes(letter);
            })
        })
    }
}