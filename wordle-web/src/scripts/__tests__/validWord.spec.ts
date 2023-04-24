import { describe, expect, it } from 'vitest'
import { WordsService } from '../wordsService'
import { WordleGame } from '../wordleGame'

const wordleWords = ['apple', 'pears', 'layer']
describe('ValidWord', () => {
  const game = new WordleGame('apple')

  it('Find All Valid - No Guesses', () => {
    game.restartGame('apple')
    expect(WordsService.validWords(game, wordleWords)).toEqual(wordleWords)
  })

  it('One Valid Word Guessed Complete Word - Wrong order', () => {
    game.restartGame('apple')
    game.guess.set('alppe')
    game.submitGuess()
    const valid = WordsService.validWords(game, wordleWords)
    expect(valid.length).toBe(1)
    expect(valid).toEqual(['apple'])
  })

  it('One Valid Word Guessed Complete Word - Correct order', () => {
    game.restartGame('apple')
    game.guess.set('alppe')
    game.submitGuess()
    const valid = WordsService.validWords(game, wordleWords)
    expect(valid.length).toBe(1)
    expect(valid).toEqual(['apple'])
  })

  it('No y - doesnt return layer', () => {
    game.restartGame('apple')
    game.guess.set('yxxxx')
    game.submitGuess()
    const valid = WordsService.validWords(game, wordleWords)
    expect(valid.length).toBe(2)
    expect(valid).toEqual(wordleWords.slice(0, 2))
  })

  it('Misplaced y - only return layer', () => {
    game.restartGame('layer')
    game.guess.set('yxxxx')
    game.submitGuess()
    const valid = WordsService.validWords(game, wordleWords)
    expect(valid.length).toBe(1)
    expect(valid).toEqual(['layer'])
  })

  it('Correct y - only return layer', () => {
    game.restartGame('layer')
    game.guess.set('xxyxx')
    game.submitGuess()
    const valid = WordsService.validWords(game, wordleWords)
    expect(valid.length).toBe(1)
    expect(valid).toEqual(['layer'])
  })

  it('Misplaced p - return apple and pears', () => {
    game.restartGame('apple')
    game.guess.set('xxxxp')
    game.submitGuess()
    const valid = WordsService.validWords(game, wordleWords)
    expect(valid.length).toBe(2)
    expect(valid).toEqual(wordleWords.slice(0, 2))
  })

  it('Correct p - return only apple', () => {
    game.restartGame('apple')
    game.guess.set('xpxxx')
    game.submitGuess()
    const valid = WordsService.validWords(game, wordleWords)
    expect(valid.length).toBe(1)
    expect(valid).toEqual(wordleWords.slice(0, 1))
  })
})
