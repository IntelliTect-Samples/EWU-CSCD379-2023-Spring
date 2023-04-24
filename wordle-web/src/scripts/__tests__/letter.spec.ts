import { describe, it, expect } from 'vitest'
import { Letter, LetterStatus } from '../letter.js'

describe('Letter', () => {
  it('Gets Correct Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Correct
    expect(letter.color).toBe('green')
  })

  it('Gets Wrong Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Wrong
    expect(letter.color).toBe('#424242') //grey-darken-3
  })

  it('Gets Misplaced Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Misplaced
    expect(letter.color).toBe('yellow')
  })

  it('Gets Default Color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.NotGuessed
    expect(letter.color).toBe('grey')
  })
})
