import { describe, it, expect } from 'vitest'

import { Letter, LetterStatus } from '@/scripts/letter'

describe('Letter', () => {
  it('Gets Correct Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Correct
    expect(letter.Color).toBe('green')
  })

  it('Gets NotGuessed Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.NotGuessed
    expect(letter.Color).toBe('grey')
  })

  it('Gets Misplaced Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Misplaced
    expect(letter.Color).toBe('orange')
  })

  it('Gets Wrong Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Wrong
    expect(letter.Color).toBe('red')
  })
})