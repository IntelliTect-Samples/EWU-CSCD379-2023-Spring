import { describe, it, expect } from 'vitest'
import { WordleGame } from '../wordleGame'
import { WordsService } from '../wordsService'

function expectWordsDoNotContainLetter(words: string[], letter: string) {
  words.forEach((word) => {
    expect(word.split('')).not.toContain(letter)
  })
}

function expectWordsDoContainLetter(words: string[], letter: string) {
  words.forEach((word) => {
    expect(word.split('')).toContain(letter)
  })
}

describe('misplaced', () => {
  const game = new WordleGame('glubs')
  game.guess.set('quick')
  game.submitGuess()
  const validWords = WordsService.validWords(game)

  it('Has no words with u at index 1', () => {
    validWords.forEach((word) => {
      expect(word[1]).not.toBe('u')
    })
  })
})

describe('Valid Words Single Guess', () => {
  const game = new WordleGame('tribe')

  game.guess.set('knife')
  game.submitGuess()
  const validWords = WordsService.validWords(game)

  it('Contains Words', () => {
    expect(validWords.length).greaterThanOrEqual(1)
  })

  it('Have "i" and "e" in correct spot', () => {
    validWords.forEach((word) => {
      expect(word[2]).toBe('i')
      expect(word[4]).toBe('e')
    })
  })

  it('Do not contain letter "k"', () => {
    expectWordsDoNotContainLetter(validWords, 'k')
  })
})

describe('Valid Words Two Guesses', () => {
  const game = new WordleGame('tribe')
  game.guess.set('knife')
  game.submitGuess()
  game.guess.set('bribe')
  game.submitGuess()
  const validWords = WordsService.validWords(game)

  it('Letters I and E in correct spot', () => {
    validWords.forEach((word) => {
      expect(word[2]).toBe('i')
      expect(word[4]).toBe('e')
    })
  })

  it('Do not contain letter K', () => {
    expectWordsDoNotContainLetter(validWords, 'k')
  })

  it('Does contain letter B', () => {
    expectWordsDoContainLetter(validWords, 'b')
  })
})

describe('Valid Words Three Guesses', () => {
  const game = new WordleGame('tribe')
  game.guess.set('rieer')
  game.submitGuess()
  let validWords = WordsService.validWords(game)

  it('Contain correct letters BIER', () => {
    expectWordsDoContainLetter(validWords, 'r')
    expectWordsDoContainLetter(validWords, 'i')
    expectWordsDoContainLetter(validWords, 'e')
  })

  it('Do not contain letter T'),
    () => {
      expectWordsDoNotContainLetter(validWords, 't')
    }

  game.guess.set('natos')
  game.submitGuess()
  validWords = WordsService.validWords(game)

  it('Do not contain letters NAOS', () => {
    expectWordsDoNotContainLetter(validWords, 'n')
    expectWordsDoNotContainLetter(validWords, 'a')
    expectWordsDoNotContainLetter(validWords, 'o')
    expectWordsDoNotContainLetter(validWords, 's')
  })

  game.guess.set('trash')
  game.submitGuess()
  validWords = WordsService.validWords(game)

  it('Have T and R in correct spot', () => {
    validWords.forEach((word) => {
      expect(word[0]).toBe('t')
      expect(word[1]).toBe('r')
    })
  })

  it('Do not contain letter H', () => {
    expectWordsDoNotContainLetter(validWords, 'h')
  })
})
