import { describe, it, expect } from 'vitest'
import { Letter, LetterStatus } from '@/scripts/letter'

describe('Letter', () => {
  it('Gets Correct Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.correct
    expect(letter.color).toBe('green')
  })
  it('Gets Incorrect Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.incorrect
    expect(letter.color).toBe('red')
  })
  it('Gets Misplaced Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.misplaced
    expect(letter.color).toBe('yellow')
  })
  it('Gets Not Guessed Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.notGuessed
    expect(letter.color).toBe('grey')
  })
})
