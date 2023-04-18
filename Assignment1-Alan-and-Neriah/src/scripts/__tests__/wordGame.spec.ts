import { describe, it, expect } from 'vitest'
import { WordGame } from '@/scripts/wordGame'

describe('WordGame', () => {
  it('submits a guess', () => {
    const wordGame = new WordGame('word')
    wordGame.submitGuess('word')
    expect(wordGame.guesses.length).toBe(1)
  })
  it('restarts the game', () => {
    const wordGame = new WordGame('word')
    wordGame.submitGuess('word')
    wordGame.restartGame('word')
    expect(wordGame.guesses.length).toBe(0)
  })
})
