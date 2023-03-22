import { WordsService } from '@/scripts/wordsService'
import { describe, test, expect } from 'vitest'

describe('Word Service', () => {
  test('Get a word', () => {
    const word = WordsService.getRandomWord()
    expect(word).not.toBeNull()
    expect(word).toHaveLength(5)
    expect(word).not.toHaveLength(4)
  })

  test('Words are private', () => {
    expect((WordsService as any).words).toBeUndefined()
  })
})
describe('Search Results Test', () => {
  test('Finds correct results', () => {
    let cAndWords = WordsService.validWords('z')
    expect(cAndWords.length === 1 && cAndWords[0] === 'zebra')
    cAndWords = WordsService.validWords('zeb')
    expect(cAndWords.length === 1 && cAndWords[0] === 'zebra')
    cAndWords = WordsService.validWords('??z')
    expect(cAndWords.length === 4 && cAndWords.includes('hazel'))
    cAndWords = WordsService.validWords('?z?z')
    expect(cAndWords.length === 0)
    cAndWords = WordsService.validWords('qv')
    expect(cAndWords.length === 0)
    cAndWords = WordsService.validWords('')
    expect(cAndWords.length === 631)
  })
})
