import { describe, it, expect } from 'vitest'
import { Letter, LetterStatus } from '@/scripts/letter'

describe('Letter', () => {
    it('gets correct color', () => {
        const letter = new Letter('a')
        letter.status = LetterStatus.Correct
        expect(letter.color).toBe('green')
    })
    it('gets misplaced color', () => {
        const letter = new Letter('a')
        letter.status = LetterStatus.Misplaced
        expect(letter.color).toBe('orange')
    })
    it('gets wrong color', () => {
        const letter = new Letter('b')
        letter.status = LetterStatus.Wrong
        expect(letter.color).toBe('red')
    })
    it('gets not guessed color', () => {
        const letter = new Letter('c')
        letter.status = LetterStatus.NotGuessed
        expect(letter.color).toBe('grey')
    })
})