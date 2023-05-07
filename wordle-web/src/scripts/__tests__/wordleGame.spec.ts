import { describe, it, expect } from 'vitest'
import { LetterStatus } from '@/scripts/letter'
import { Word } from '@/scripts/word'

describe('Word', () => {
  it('Gets Correct Word', () => {
    const word = new Word('apple')
    expect(word.checkWord('apple')).toBe(true)
    expect(word.letters[0].status).toBe(LetterStatus.Correct)
    expect(word.letters[1].status).toBe(LetterStatus.Correct)
    expect(word.letters[2].status).toBe(LetterStatus.Correct)
    expect(word.letters[3].status).toBe(LetterStatus.Correct)
    expect(word.letters[4].status).toBe(LetterStatus.Correct)
  })

  it('Gets Wrong Word', () => {
    const word = new Word('apple')
    expect(word.checkWord('plane')).toBe(false)
    expect(word.letters[0].status).toBe(LetterStatus.Misplaced)
    expect(word.letters[1].status).toBe(LetterStatus.Misplaced)
    expect(word.letters[2].status).toBe(LetterStatus.Wrong)
    expect(word.letters[3].status).toBe(LetterStatus.Misplaced)
    expect(word.letters[4].status).toBe(LetterStatus.Correct)
  })
})
