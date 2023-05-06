import { describe, it, expect } from 'vitest'
import { WordsService } from '@/scripts/wordsService'
import { Word } from '../word'

describe('wordsService', () => {
  it('Test against multiple valid words', () => {
    const testWord = new Word('app')
    const testArray = WordsService.validWords(testWord.text)
    expect(testArray.length).toBe(8)
  })

  it('Test against no matched valid words', () => {
    const testWord = new Word('seerr')
    const testArray = WordsService.validWords(testWord.text)
    expect(testArray.length).toBe(0)
  })

  it('Test against one single match', () => {
    const testWord = new Word('apple')
    const testArray = WordsService.validWords(testWord.text)
    expect(testArray[0]).toBe('apple')
  })
})
