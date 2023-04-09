import { describe, it, expect } from 'vitest'
import { letter, LetterStatus } from '@/scripts/letter.ts'

describe('Letter', () => {
    it('Gets Correct Color', () => {
        const Letter = new letter('a')
        letter.status = LetterStatus.Correct
        expect(letter.color).toBe('green')
    })

    it('Gets Misplaced Color', () => {
        const Letter = new letter('a')
        letter.status = LetterStatus.Misplaced
        expect(letter.color).toBe('gold')
    })

    it('Gets Wrong Color', () => {
      const Letter = new letter('a')
      letter.status = LetterStatus.Wrong
      expect(letter.color).toBe('black')
  })

  it('Gets Unknown Color', () => {
    const Letter = new letter('a')
    letter.status = LetterStatus.Unknown
    expect(letter.color).toBe('grey')
})
})