import { describe, it, expect } from 'vitest'
import { WordsService } from '@/scripts/wordsService'
import { Word } from '../word'

describe('WordsService', () => {
  it('validWords gets correct word chars', () => {
    const guess = new Word('slays')
    guess.check('slews')
    WordsService.resetService()

    const results = WordsService.validWords(guess)
    expect(results.length).toBe(18)
    expect(
      results.filter((word) => word[0] == 's' && word[1] == 'l' && word[4] == 's').length
    ).toBe(18)
    expect(results.includes('slews')).toBe(true)
  })

  it('validWords gets correct words', () => {
    const guess = new Word('mount')
    guess.check('moyas')
    WordsService.resetService()

    const results = WordsService.validWords(guess)
    expect(results.length).toBe(99)
    expect(results.includes('moyas')).toBe(true)
  })

  it('validWords misplaced gets correct words', () => {
    const guess = new Word('cloud')
    guess.check('could')
    WordsService.resetService()

    const results = WordsService.validWords(guess)
    expect(results.length).toBe(1)
    expect(results.includes('could')).toBe(true)
  })

  it('validWords returns words with no wrong letters', () => {
    const guess = new Word('qwtyu')
    const guess1 = new Word('iopas')
    const guess2 = new Word('dfghj')
    guess.check('breve')
    guess1.check('breve')
    guess2.check('breve')
    WordsService.resetService()

    WordsService.validWords(guess)
    WordsService.validWords(guess1)
    const results = WordsService.validWords(guess2)
    expect(results.length).toBe(78)
    expect(results.includes('breve')).toBe(true)
  })
})
