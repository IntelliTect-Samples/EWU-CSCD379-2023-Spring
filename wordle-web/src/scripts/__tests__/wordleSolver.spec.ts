import { describe, it, expect } from 'vitest'
import { WordleGame } from '../wordleGame'
import { WordsService } from '../wordsService'
import { GuessingStrategy, WordlePlayer } from '../wordlePlayer'

// TODO: make this test better
describe('Solve Simple', () => {
  it('Gets Correct Words', () => {
    const game = new WordleGame('apple')
    game.guess.set('peach')
    game.submitGuess()
    expect(game.solver.availableWords).length(60)
    expect(game.solver.bestGuessOfValidWords).toBe('apers')
    game.guess.set('paper')
    game.submitGuess()
    expect(game.solver.availableWords).length(1)
    expect(game.solver.availableWords[0]).toBe('apple')
  })
})

// This is a bad test because it will likely fail at some point because of the random words
// describe('Best Solver Technique', () => {
//   it('on 100 words guessing outside the word is faster', () => {
//     let totalInWordGuesses = 0
//     let totalOutWordGuesses = 0
//     //let totalAlternatingGuesses = 0
//     for (let i = 0; i < 100; i++) {
//       const word = WordsService.getRandomWord()
//       totalInWordGuesses += WordlePlayer.playGame(word, GuessingStrategy.ValidWordsOnly)
//       totalOutWordGuesses += WordlePlayer.playGame(word, GuessingStrategy.InvalidWordsOnly)
//       //totalAlternatingGuesses += WordlePlayer.playGame(word, GuessingStrategy.Alternating)
//     }

//     // This is not what I expected. I thought that picking words that were
//     // made from letters not yet guessed, but in the list of possible words would
//     // be the best solution, but it doesn't appear that way.
//     // (unless logic is wrong, which is totally possible)
//     //expect(totalOutWordGuesses).toBeLessThan(totalInWordGuesses)
//     expect(totalInWordGuesses).toBeLessThan(totalOutWordGuesses)
//     //expect(totalAlternatingGuesses).toBeLessThan(totalOutWordGuesses)
//     //expect(totalAlternatingGuesses).toBeLessThan(totalInWordGuesses)
//   })
//})
