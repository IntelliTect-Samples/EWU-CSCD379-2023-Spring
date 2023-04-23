import { describe, expect, it } from 'vitest'
import { Letter, LetterStatus } from '../letter'
import { WordsService } from '../wordsService'

const wordleWords = ['apple', 'pears', 'layer']
describe('ValidWord', () => {
  it('Find All Valid - No Guesses', () => {
    expect(WordsService.validWords([], wordleWords)).toEqual(wordleWords)
  })

  it('One Valid Word Guessed Complete Word - Wrong order', () => {
    const valid = WordsService.validWords([
      new Letter('a', LetterStatus.Correct),
      new Letter('p', LetterStatus.Misplaced),
      new Letter('p', LetterStatus.Correct),
      new Letter('l', LetterStatus.Misplaced),
      new Letter('e', LetterStatus.Correct)
    ], wordleWords)
    expect(valid.length).toBe(1)
    expect(valid).toEqual(['apple'])
  })

  it('One Valid Word Guessed Complete Word - Correct order', () => {
    const valid = WordsService.validWords([
      new Letter('p', LetterStatus.Correct),
      new Letter('a', LetterStatus.Correct),
      new Letter('p', LetterStatus.Correct),
      new Letter('e', LetterStatus.Correct),
      new Letter('l', LetterStatus.Correct)
    ], wordleWords)
    expect(valid.length).toBe(1)
    expect(valid).toEqual(['apple'])
  })

  it('No y - doesnt return layer', () => {
    const valid = WordsService.validWords([new Letter('y', LetterStatus.Wrong)], wordleWords)
    expect(valid.length).toBe(2)
    expect(valid).toEqual(wordleWords.slice(0, 2))
  })

  it('Misplaced y - only return layer', () => {
    const valid = WordsService.validWords([new Letter('y', LetterStatus.Misplaced)], wordleWords)
    expect(valid.length).toBe(1)
    expect(valid).toEqual(['layer'])
  })

  it('Correct y - only return layer', () => {
    const valid = WordsService.validWords([new Letter('y', LetterStatus.Correct)], wordleWords)
    expect(valid.length).toBe(1)
    expect(valid).toEqual(['layer'])
  })

  it('Misplaced p - return apple and pears', () => {
    const valid = WordsService.validWords([new Letter('p', LetterStatus.Misplaced)], wordleWords)
    expect(valid.length).toBe(2)
    expect(valid).toEqual(wordleWords.slice(0, 2))
  })

  it('Correct p - return apple and pears', () => {
    const valid = WordsService.validWords([new Letter('p', LetterStatus.Correct)], wordleWords)
    expect(valid.length).toBe(2)
    expect(valid).toEqual(wordleWords.slice(0, 2))
  })
})
