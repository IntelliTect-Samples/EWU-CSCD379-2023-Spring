import { describe, it, expect } from 'vitest'
import { Validate, WordsService } from '@/scripts/wordsService'

describe('WordleGame', () => {
  it('should return ValidationStatus.TooShort if word is less than 5 characters', () => {
    const result = WordsService.validWords('test')
    expect(result).toBe(Validate.WrongL)
  })

  it('should return ValidationStatus.TooLong if word is more than 5 characters', () => {
    const result = WordsService.validWords('testing')
    expect(result).toBe(Validate.WrongL)
  })

  it('should return ValidationStatus.InvalidWord if word is not valid', () => {
    const result = WordsService.validWords('ppppp')
    expect(result).toBe(Validate.Invalid)
  })

  it('should return ValidationStatus.Valid if word is valid', () => {
    const result = WordsService.validWords('hello')
    expect(result).toBe(Validate.Valid)
  })
})
