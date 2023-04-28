import { describe, it, expect } from 'vitest'
import { WordsService } from '../wordsService'

describe('WordsService', () => {
  it('Displays a single word if 5 letters are entered an word is in wordlist', () => {
    const validWords = WordsService.validWords('PEACH')
    expect(validWords.length === 1).toBe(true)
  })

  it('If word not found in wordlist entered, display no words', () => {
    const validWords = WordsService.validWords('BEZZS')
    expect(validWords.length === 0).toBe(true)
  })

  it('If no letters entered, display all words', () => {
    const validWords = WordsService.validWords('')
    expect(validWords.length === 12972).toBe(true)
  })

  it('Checks partial guesses based on letters already entered', () => {
    const partialGuess = 'PEA'
    const validWords = WordsService.validWords(partialGuess)
    expect(validWords.some((word) => word.text === 'PEACH')).toBe(true)
    expect(validWords.some((word) => word.text === 'PEARL')).toBe(true)
    // Incorrect tests
    expect(validWords.some((word) => word.text === 'PEEPS')).toBe(false)
    expect(validWords.some((word) => word.text === 'PROPS')).toBe(false)
  })
})
