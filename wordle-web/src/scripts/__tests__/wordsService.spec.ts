import { describe, it, expect } from 'vitest'
import { WordsService } from '@/scripts/wordsService'

describe('validWords', () => {
  it('returns one valid word', () => {
    const word = 'aahed'
    let list: string[] = WordsService.validWords(word)
    expect(list.length).toEqual(1)
    expect(list[0]).toEqual(word)
  })
})
