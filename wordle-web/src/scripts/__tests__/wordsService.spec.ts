import { describe, it, expect } from 'vitest'
import { WordsService } from '../wordsService'
import { Word } from '../word'

describe('wordsService', () => {
  it('will test a value that should return multiple available words', () => {
    const word = new Word('ball')
    const expected = ['balls', 'bally']
    const actual = WordsService.validWords(word.text)
    expect(expected).toStrictEqual(actual)
  })

  it('will test a value that should return one available word', () => {
    const word = new Word('pizz')
    const expected = ['pizza']
    const actual = WordsService.validWords(word.text)
    expect(expected).toStrictEqual(actual)
  })

  it('will test a value that should return no available words', () => {
    const word = new Word('zzzz')
    const actual = WordsService.validWords(word.text)
    expect(actual).toStrictEqual([])
  })
})
