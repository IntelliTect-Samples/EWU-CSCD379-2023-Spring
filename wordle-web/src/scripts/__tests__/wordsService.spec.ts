import { describe, it, expect } from 'vitest'
import { WordsService } from '../services/wordsService'

describe('wordsService', () => {
  it('Makes list of valid words, 1 char(s)', () => {
    const list = WordsService.validWords('a')
    list.forEach((element) => {
      expect(element[0]).toBe('a')
    })
  })

  it('Makes list of valid words, 2 char(s)', () => {
    const list = WordsService.validWords('ab')
    list.forEach((element) => {
      expect(element[0]).toBe('a')
      expect(element[1]).toBe('b')
    })
  })

  it('Makes list of valid words, 3 char(s)', () => {
    const list = WordsService.validWords('zym')
    list.forEach((element) => {
      expect(element[0]).toBe('z')
      expect(element[1]).toBe('y')
      expect(element[2]).toBe('m')
    })
  })

  it('Makes list of valid words, 4 char(s)', () => {
    const list = WordsService.validWords('abri')
    list.forEach((element) => {
      expect(element[0]).toBe('a')
      expect(element[1]).toBe('b')
      expect(element[2]).toBe('r')
      expect(element[3]).toBe('i')
    })
  })

  it('Makes list of valid words, 5 char(s)', () => {
    const list = WordsService.validWords('above')
    list.forEach((element) => {
      expect(element[0]).toBe('a')
      expect(element[1]).toBe('b')
      expect(element[2]).toBe('o')
      expect(element[3]).toBe('v')
      expect(element[4]).toBe('e')
    })
  })

  it('Makes list of valid words, 6+ char(s)', () => {
    const list = WordsService.validWords('abcdef')
    expect(list.length == 0).toBe(true)
  })
})
