import { describe, it, expect } from 'vitest'
import { WordsService } from '@/scripts/wordsService'

describe('validWords', () => {
  it('returns 4 valid words starting with aa', () => {
    const word = 'aahed'
    const guess = 'aa---'
    const list: string[] = WordsService.validWords(guess, word)
    expect(list.length).toEqual(4)
  }),
  it('returns one valid word', () => {
    const word = 'aahed'
    const guess = 'aahed'
    const list: string[] = WordsService.validWords(guess, word)
    expect(list.length).toEqual(1)
    expect(list[0]).toEqual('aahed')
  })
})
