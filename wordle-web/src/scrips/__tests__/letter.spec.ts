import { describe, it, expect } from 'vitest'

import { Letter , LetterStatus} from '../letter'


describe('Letter', () => {
  it('gets color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Correct
    expect(letter.color).toBe('green')
  })

  it('gets wrong color', () => {
    const letter = new Letter('a')
    letter.status = LetterStatus.Wrong
    expect(letter.color).toBe('black')
  })
})
