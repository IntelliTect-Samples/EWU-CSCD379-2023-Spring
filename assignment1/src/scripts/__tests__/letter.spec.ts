import { describe, it, expect } from 'vitest'
import { Letter, LetterStatus } from '@/scripts/letter'

describe('Letter', () => {
    it('Gets Correct Color', () => {
        const letter = new Letter('a')
        letter.status = LetterStatus.Correct
        expect(letter.color).toBe('green')
    })

    it('Gets Misplaced Color', () => {
        const letter = new Letter('a')
        letter.status = LetterStatus.Misplaced
        expect(letter.color).toBe('gold')
    })

    it('Gets Wrong Color', () => {
      const letter = new Letter('a')
      letter.status = LetterStatus.Wrong
      expect(letter.color).toBe('black')
  })

  it('Gets Unknown Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Unknown
    expect(letter.color).toBe('grey')
})
})