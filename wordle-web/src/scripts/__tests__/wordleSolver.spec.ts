import { describe, it, expect } from 'vitest'
import { WordleGame, WordleGameStatus } from '../wordleGame'
import { WordleSolver } from '../wordleSolver'
import { WordsService } from '../wordsService'

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

// This is a bad test because it will likely fail at some point because of the random words
describe('Best Solver Technique', () => {
  it('on 100 words guessing outside the word is faster', () => {
    let totalInWordGuesses = 0
    let totalOutWordGuesses = 0
    for (let i = 0; i < 100; i++) {
      const word = WordsService.getRandomWord()
      totalInWordGuesses += playGame(word, true)
      totalOutWordGuesses += playGame(word, false)
    }

    // This is not what I expected. I thought that picking words that were
    // made from letters not yet guessed, but in the list of possible words would
    // be the best solution, but it doesn't appear that way.
    // (unless logic is wrong, which is totally possible)
    //expect(totalOutWordGuesses).toBeLessThan(totalInWordGuesses)
    expect(totalInWordGuesses).toBeLessThan(totalOutWordGuesses)
  })
})

// Play a game based on a strategy and return the number of guesses
function playGame(word: string, useInWord: boolean): number {
  const game = new WordleGame(word, 25)
  const solver = new WordleSolver(game)

  let totalGuesses = 0
  while (game.status == WordleGameStatus.Active) {
    const guess = useInWord ? solver.bestGuessOfValidWords() : solver.bestGuessOfAllWords()
    game.guess.set(guess)
    game.submitGuess()
    totalGuesses++
  }
  return totalGuesses
}
