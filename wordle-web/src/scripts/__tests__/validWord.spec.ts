import {describe, expect, it} from 'vitest'
import {Letter, LetterStatus} from "../letter";
import Word from '../Word';

const wordleWords = [
    'apple',
    'pears',
    'layer',
]
describe('ValidWord', () => {
    it('Find All Valid - No Guesses', () => {
        expect(Word.ValidWords(wordleWords, [])).toEqual(wordleWords)
    })

    it('One Valid Word Guessed Complete Word - Wrong order', () => {
        const valid = Word.ValidWords(wordleWords, [
            new Letter('a', LetterStatus.Correct),
            new Letter('p', LetterStatus.Correct),
            new Letter('p', LetterStatus.Correct),
            new Letter('l', LetterStatus.Correct),
            new Letter('e', LetterStatus.Correct),
        ])
        expect(valid.length).toBe(1)
        expect(valid).toEqual(['apple'])
    })

    it('One Valid Word Guessed Complete Word - Correct order', () => {
        const valid = Word.ValidWords(wordleWords, [
            new Letter('p', LetterStatus.Correct),
            new Letter('a', LetterStatus.Correct),
            new Letter('p', LetterStatus.Correct),
            new Letter('e', LetterStatus.Correct),
            new Letter('l', LetterStatus.Correct),
        ])
        expect(valid.length).toBe(1)
        expect(valid).toEqual(['apple'])
    })

    it('No y - doesnt return layer', () => {
        const valid = Word.ValidWords(wordleWords, [
            new Letter('y', LetterStatus.Correct),
        ])
        expect(valid.length).toBe(2)
        expect(valid).toEqual(wordleWords.slice(0, 2))
    })

    it('Misplaced y - only return layer', () => {
        const valid = Word.ValidWords(wordleWords, [
            new Letter('y', LetterStatus.Misplaced),
        ])
        expect(valid.length).toBe(1)
        expect(valid).toEqual(['layer'])
    })

    it('Correct y - only return layer', () => {
        const valid = Word.ValidWords(wordleWords, [
            new Letter('y', LetterStatus.Correct),
        ])
        expect(valid.length).toBe(1)
        expect(valid).toEqual(['layer'])
    })

    it('Misplaced p - return apple and pears', () => {
        const valid = Word.ValidWords(wordleWords, [
            new Letter('p', LetterStatus.Misplaced),
        ])
        expect(valid.length).toBe(2)
        expect(valid).toEqual(wordleWords.slice(0, 2))
    })

    it('Correct p - return apple and pears', () => {
        const valid = Word.ValidWords(wordleWords, [
            new Letter('p', LetterStatus.Correct),
        ])
        expect(valid.length).toBe(2)
        expect(valid).toEqual(wordleWords.slice(0, 2))
    })
})
