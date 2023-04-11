import { describe, it, expect } from 'vitest'
import { Letter, LetterStatus } from '@/scripts/letter'

describe('Letter', () => {
    it('Gets correct String Val', () => {
        const letter = new Letter('a')
        letter.status = LetterStatus.Correct
        expect(letter.letter).toBe('a')
    })

    it('Gets Correct Color', () => {
        const letter = new Letter('a')
        letter.status = LetterStatus.Correct
        expect(letter.color).toBe('green')
    })

    it('Gets Misplaced Color', () => {
        const letter = new Letter('a')
        letter.status = LetterStatus.Misplaced
        expect(letter.color).toBe('orange')
    })

    it('Gets correct Wrong Color', () => {
        const letter = new Letter('a')
        letter.status = LetterStatus.Wrong
        expect(letter.color).toBe('red')
    })

    it('Gets correct not Guessed Color', () => {
        const letter = new Letter('a')
        expect(letter.color).toBe('grey')
    })
})
