import { describe, it, expect } from 'vitest'
import { Letter, LetterStatus } from '../letter.js'

describe('Letter', () => {
  it('Gets Correct Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Correct
    expect(letter.getColor()).toBe('green')
  })

  it('Gets Wrong Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Wrong
    expect(letter.getColor()).toBe('red')
  })

  it('Gets Misplaced Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Misplaced
    expect(letter.getColor()).toBe('yellow')
  })

  it('Gets Default Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.NotGuessed
    expect(letter.getColor()).toBe('grey')
  })
})
