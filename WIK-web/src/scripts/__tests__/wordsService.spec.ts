import { describe, it, expect } from 'vitest'
import { WordsService } from '../wordsService'

describe('ValidWords', () => {
  //simulates typing 'happy'
  it('Valid Check 1', () => {
    const guess = 'h'
    const valid = WordsService.validWords(guess)
    expect(valid.includes('apple')).toBe(false)
    expect(valid.includes('hello')).toBe(true)
    expect(valid.includes('handy')).toBe(true)
    expect(valid.includes('haply')).toBe(true)
    expect(valid.includes('happi')).toBe(true)
    expect(valid.includes('happy')).toBe(true)
  })
  it('Valid Check 2', () => {
    const guess = 'ha'
    const valid = WordsService.validWords(guess)
    expect(valid.includes('apple')).toBe(false)
    expect(valid.includes('hello')).toBe(false)
    expect(valid.includes('handy')).toBe(true)
    expect(valid.includes('haply')).toBe(true)
    expect(valid.includes('happi')).toBe(true)
    expect(valid.includes('happy')).toBe(true)
  })
  it('Valid Check 3', () => {
    const guess = 'hap'
    const valid = WordsService.validWords(guess)
    expect(valid.includes('apple')).toBe(false)
    expect(valid.includes('hello')).toBe(false)
    expect(valid.includes('handy')).toBe(false)
    expect(valid.includes('haply')).toBe(true)
    expect(valid.includes('happi')).toBe(true)
    expect(valid.includes('happy')).toBe(true)
  })
  it('Valid Check 4', () => {
    const guess = 'happ'
    const valid = WordsService.validWords(guess)
    expect(valid.includes('apple')).toBe(false)
    expect(valid.includes('hello')).toBe(false)
    expect(valid.includes('handy')).toBe(false)
    expect(valid.includes('haply')).toBe(false)
    expect(valid.includes('happi')).toBe(true)
    expect(valid.includes('happy')).toBe(true)
  })
  it('Valid Check 5', () => {
    const guess = 'happy'
    const valid = WordsService.validWords(guess)
    expect(valid.includes('apple')).toBe(false)
    expect(valid.includes('hello')).toBe(false)
    expect(valid.includes('handy')).toBe(false)
    expect(valid.includes('haply')).toBe(false)
    expect(valid.includes('happi')).toBe(false)
    expect(valid.includes('happy')).toBe(true)
  })
})
