import { describe, it, expect } from 'vitest'
import {WordsService} from '../wordsService'

describe('ValidWords', () => {
    it('Returns All Words', () => {
        const unknown = [[]]
        expect(WordsService.validWords(unknown).length).toBe(12972)
      })
  it('Returns Minimum', () => {
    const knowns = [['a', '0', '0']]//only know that 'a' is 'correct' in position '0'
    let answer = WordsService.validWords(knowns)
    expect(answer.length).toBe(737)//letters starting with a occupy lines 100-836
    expect(answer[0]).toBe('aahed')
  })
  it('Returns Near Full Word', () => {
    const knowns = [['g', '0', '0'], ['u', '0', '1'], ['e', '0', '2'], ['s', '0', '3']]
    let answer = WordsService.validWords(knowns)
    expect(answer.length).toBe(2)
    expect(answer[0]).toBe('guess')
  })
})
