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
})