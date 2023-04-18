import { describe, it, expect } from 'vitest'
import { letter, LetterStatus } from '@/scripts/letter'

describe('Letter', () => {
    it('Gets Correct Color', () => {
        const Letter = new letter('a')
        Letter.status = LetterStatus.Correct
        expect(Letter.color).toBe('green')
    })

    it('Gets Misplaced Color', () => {
        const Letter = new letter('a')
        Letter.status = LetterStatus.Misplaced
        expect(Letter.color).toBe('gold')
    })

    it('Gets Wrong Color', () => {
      const Letter = new letter('a')
      Letter.status = LetterStatus.Wrong
      expect(Letter.color).toBe('black')
  })

  it('Gets Unknown Color', () => {
    const Letter = new letter('a')
    Letter.status = LetterStatus.Unknown
    expect(Letter.color).toBe('grey')
})
})