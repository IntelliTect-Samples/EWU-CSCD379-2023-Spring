import { describe, it, expect } from 'vitest'
import { Letter, LetterStatus } from '@/scripts/letter'

describe('Letter', () => {
  it('Gets correct String Val', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Correct
    expect(letter.char).toBe('a')
  })

  it('Gets Correct Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Correct
    expect(letter.color).toBe('correct')
  })

  it('Gets Misplaced Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Misplaced
    expect(letter.color).toBe('misplaced')
  })

  it('Gets correct Wrong Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Wrong
    expect(letter.color).toBe('wrong')
  })

  it('Gets correct not Guessed Color', () => {
    const letter = new Letter('a')
    expect(letter.color).toBe('grey')
  })
  it('Gets Correct Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Correct
    expect(letter.color).toBe('correct')
  })

  it('Gets Misplaced Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Misplaced
    expect(letter.color).toBe('misplaced')
  })
})
