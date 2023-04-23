import { describe, it, expect } from 'vitest'
import { WordsService } from '../wordsService'

describe('WordsService', () => {
  it('Returns True Given "Real" Word', () => {
    const validWords = WordsService.validWords('APPLE')
    expect(validWords.length === 1).toBe(true)
  })

  it('Returns Empty Given Non-Word', () => {
    const validWords = WordsService.validWords('APPLX')
    expect(validWords.length === 0).toBe(true)
  })

  it('Recognized all words as options given nothing', () => {
    const validWords = WordsService.validWords('')
    expect(validWords.length === 12972).toBe(true)
  })

  it('Contains potential potential words given current guess', () => {
    const partialGuess = 'STO'
    const validWords = WordsService.validWords(partialGuess)
    expect(validWords.some((word) => word.text === 'STORE')).toBe(true)
    expect(validWords.some((word) => word.text === 'STOIC')).toBe(true)
    expect(validWords.some((word) => word.text === 'STOMP')).toBe(true)
    expect(validWords.some((word) => word.text === 'STOOD')).toBe(true)
    expect(validWords.some((word) => word.text === 'STOUT')).toBe(true)
    expect(validWords.some((word) => word.text === 'STOOP')).toBe(true)
    // Should not be in list
    expect(validWords.some((word) => word.text === 'STAMP')).toBe(false)
    expect(validWords.some((word) => word.text === 'STUCK')).toBe(false)
    expect(validWords.some((word) => word.text === 'STEEP')).toBe(false)
  })
})
