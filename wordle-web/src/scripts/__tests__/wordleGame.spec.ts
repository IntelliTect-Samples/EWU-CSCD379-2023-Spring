import { describe, it, expect } from 'vitest'
import { LetterStatus } from '@/scripts/letter'
import { WordleGame } from '../wordleGame'
import { Word } from '../word'

describe('wordleGame Restarts correctly', () => {
  it('Gets Correct Word', () => {
    const wg = new WordleGame('apple')
    const word = new Word('peach')
    wg.inputWord(word)
    wg.submitGuess()
    wg.restartGame('crypt')
    expect(wg.secretWord).toBe('crypt')
  })

  it('wordleGame is able to determine if the player has correctly guessed the secret word', () => {
    const wg = new WordleGame('peach')
    const guess = new Word('apple')
    wg.inputWord(guess)
    wg.submitGuess()
    const word = wg.guesses[0]
    expect(word.letters[0].status).toBe(LetterStatus.Misplaced)
    expect(word.letters[1].status).toBe(LetterStatus.Misplaced)
    expect(word.letters[2].status).toBe(LetterStatus.Wrong)
    expect(word.letters[3].status).toBe(LetterStatus.Wrong)
    expect(word.letters[4].status).toBe(LetterStatus.Misplaced)
    expect(wg.win).toBe(false)
    const guess2 = new Word('peach')
    wg.inputWord(guess2)
    wg.submitGuess()
    const word2 = wg.guesses[1]
    expect(word2.letters[0].status).toBe(LetterStatus.Correct)
    expect(word2.letters[1].status).toBe(LetterStatus.Correct)
    expect(word2.letters[2].status).toBe(LetterStatus.Correct)
    expect(word2.letters[3].status).toBe(LetterStatus.Correct)
    expect(word2.letters[4].status).toBe(LetterStatus.Correct)
    expect(wg.win).toBe(true)
  })
})
