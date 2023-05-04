import { describe, it, expect } from 'vitest'
import { WordsService } from '@/scripts/wordsService'

describe('validWords', () => {
  it('returns 4 valid words starting with aa', () => {
    const word = 'aahed'
    const guesses = ['aa---']
    const list: string[] = WordsService.validWords(guesses, word)
    expect(list.length).toEqual(4)
  }),
    it('returns one valid word', () => {
      const word = 'aahed'
      const guesses = ['aahed']
      const list: string[] = WordsService.validWords(guesses, word)
      expect(list.length).toEqual(1)
      expect(list[0]).toEqual('aahed')
    }),
    it('returns valid words based on previous guesses', () => {
      // Incorrect letter case
      const word = 'aahed'
      let guesses = ['aa---', 'aa-g-']
      let list: string[] = WordsService.validWords(guesses, word)
      expect(list.length).toEqual(3)

      // Incorrectly placed case
      guesses = ['aa---', 'aai--']
      list = WordsService.validWords(guesses, word)
      expect(list.length).toEqual(2)
    })
})
