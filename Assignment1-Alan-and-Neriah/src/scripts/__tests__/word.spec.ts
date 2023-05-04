import { describe, it, expect } from 'vitest'
import { Word } from '@/scripts/word'

describe('Word', () => {
  it('Gets Text', () => {
    const word = new Word('word')
    expect(word.text).toBe('word')
  })

  it('Checks Correct', () => {
    const word = new Word('word')
    expect(word.check('word')).toBe(true)
  })

  it('Checks Incorrect', () => {
    const word = new Word('word')
    expect(word.check('wore')).toBe(false)
  })
})
