import { WordleGame, WordleGameStatus } from './wordleGame'

export class WordlePlayer {
  // Play a game based on a strategy and return the number of guesses
  static playGame(word: string, strategy: GuessingStrategy): number {
    const game = new WordleGame(word, 25)

    let totalGuesses = 0
    while (game.status == WordleGameStatus.Active) {
      let guess: string
      // Pick a strategy based on strategy
      switch (strategy) {
        case GuessingStrategy.ValidWordsOnly:
          guess = game.solver.bestGuessOfValidWords
          break
        case GuessingStrategy.InvalidWordsOnly:
          guess = game.solver.bestGuessOfInvalidWords
          break
        case GuessingStrategy.Alternating:
          guess =
            totalGuesses % 2 == 0
              ? game.solver.bestGuessOfValidWords
              : game.solver.bestGuessOfInvalidWords
          break
      }
      game.guess.set(guess)
      game.submitGuess()
      totalGuesses++
    }
    return totalGuesses
  }
}

export enum GuessingStrategy {
  ValidWordsOnly,
  InvalidWordsOnly,
  Alternating
}
