import { describe, it, expect } from 'vitest'
import { WordsService } from '@/scripts/wordsService'

describe('WordsService', () => {
  it('should return a random word from the list', () => {
    const randomWord = WordsService.getRandomWord()
    expect(typeof randomWord).toBe('string')
    expect(WordsService.isValidWord(randomWord)).toBe(true)
  })

  it('should correctly identify valid words', () => {
    expect(WordsService.isValidWord('hello')).toBe(true)
    expect(WordsService.isValidWord('world')).toBe(true)
    expect(WordsService.isValidWord('foo')).toBe(false)
    expect(WordsService.isValidWord('bar')).toBe(false)
  })

  it('should correctly return valid words for a given guess', () => {
    expect(WordsService.validWords('aahe?')).toEqual(['aahed'])
    expect(WordsService.validWords('abac')).toEqual(['abaca', 'abaci', 'aback', 'abacs'])
    expect(WordsService.validWords('aaaa')).toEqual([])
  })
})
