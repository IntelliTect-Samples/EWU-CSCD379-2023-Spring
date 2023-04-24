import { describe, it, expect } from 'vitest'
import { WordsService } from '../wordsService'
import { WordleGame } from '../wordleGame'
import { Word } from '../word'

describe('isValidWord', () => {
  it('returns true for a valid word input', () => {
    expect(WordsService.isValidWord('aahed')).toBe(true)
    expect(WordsService.isValidWord('crypt')).toBe(true)
    expect(WordsService.isValidWord('ashes')).toBe(true)
    expect(WordsService.isValidWord('peach')).toBe(true)
  })

  it('returns false for an invalid word input', () => {
    expect(WordsService.isValidWord('aahedf')).toBe(false)
    expect(WordsService.isValidWord('cryptf')).toBe(false)
    expect(WordsService.isValidWord('ashesf')).toBe(false)
    expect(WordsService.isValidWord('peachf')).toBe(false)
  })

  // All the words starting with aa
  //    secret=aarti, guess=aahed => res a(g) a(g) h(r) e(r) d(r)
  // 'aahed',
  // 'aalii',
  // 'aargh',
  // 'aarti',

  describe('validWords', () => {
    it('got correct valid words array after guess - tests correct letters (status 1), and incorrect letters (status 3)', () => {
      const wg = new WordleGame('aarti')
      const word = new Word('aahed')
      wg.inputWord(word)
      wg.submitGuess()
      expect(wg.getValidWords()).toStrictEqual(['aalii', 'aarti'])
    })

    it('got correct valid words array after guesses - tests misplaced words (status 2)', () => {
      const wg = new WordleGame('aahed')
      const word = new Word('aalii')
      wg.inputWord(word)
      wg.submitGuess()
      expect(wg.getValidWords()).toStrictEqual(['aahed', 'aargh'])
      const word2 = new Word('aargh')
      wg.inputWord(word2)
      wg.submitGuess()
      expect(wg.getValidWords()).toStrictEqual(['aahed'])
    })
  })
})
