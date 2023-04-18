export abstract class WordService {
    static readonly #words: string[] = this.getWords();
    static getWords(): string[]{
        const fs = require('fs');

        // Returns the path to the word list which is separated by `\n`
        const wordListPath = require('word-list');

        const wordArray = fs.readFileSync(wordListPath, 'utf8').split('\n');
        //=> […, 'abmhos', 'abnegate', …]
        const wordleWords: string[] = [];
        for (let i=0; i<wordArray.length; i++){
            if(wordArray[i].length === 5){
                wordleWords.push(wordArray[i]);
            }
        }
        return wordleWords;
    }

    static getRandomWord(): string {
        return this.#words[Math.floor(Math.random() * this.#words.length)];
    }

    static isValidWord(word: string): boolean {
        return this.#words.includes(word);
    }
}