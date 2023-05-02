import { describe, it, expect } from 'vitest'
import { WordsService } from '@/scripts/wordsService'
import { Word } from '@/scripts/word'

describe('validWords', () => {
  it('Two possible word', () => {
    const guess = new Word('stinu')
    expect(WordsService.validWords(guess, 'units')).toStrictEqual(['suint', 'units'])
  })

  it('One possible word', () => {
    const guess = new Word('cigoy')
    expect(WordsService.validWords(guess, 'yogic')).toStrictEqual(['yogic'])
  })

  it('multiple possible word', () => {
    const guess = new Word('biman')
    expect(WordsService.validWords(guess, 'bemas')).toStrictEqual([
      'bemad',
      'bemas',
      'bimah',
      'bimas',
      'bomas'
    ])
  })
})
