import { describe, it, expect } from 'vitest'
import { WordsService } from '@/scripts/wordsService'
import { Word } from '@/scripts/word'

describe('WordsService', () => {
  it('Input "pea" should return 17 valid words', () => {
    const words = new Word('pea')
    const wordArray = WordsService.validWords(words.text)
    expect(wordArray.length).toBe(17)
  })
})

describe('WordsService', () => {
  it('Input "wordd" should return no valid words', () => {
    const words = new Word('wordd')
    const wordArray = WordsService.validWords(words.text)
    expect(wordArray.length).toBe(0)
  })
})
