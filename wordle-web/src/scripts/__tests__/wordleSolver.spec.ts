import { describe, it, expect } from 'vitest'
import { WordleGame } from '../wordleGame'
import { WordleSolver } from '../wordleSolver'

// TODO: make this test better
describe('Solve Simple', () => {
  it('Gets Correct Words', () => {
    const game = new WordleGame('apple')
    const solver = new WordleSolver(game)
    game.guess.set('peach')
    game.submitGuess()
    expect(solver.availableWords()).length(60)
    expect(solver.bestGuessOfValidWords()).toBe('apers')
    game.guess.set('paper')
    game.submitGuess()
    expect(solver.availableWords()).length(1)
    expect(solver.availableWords()[0]).toBe('apple')
  })
})
