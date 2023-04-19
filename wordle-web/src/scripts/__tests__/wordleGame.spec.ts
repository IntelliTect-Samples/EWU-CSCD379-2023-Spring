import { describe, it, expect } from 'vitest'
import { LetterStatus } from '@/scripts/letter'
import { Word } from '@/scripts/word'
import { WordsService } from '../wordsService'

describe('Word', () => {
  it('Gets Correct Word', () => {
    const word = new Word('apple')
    expect(word.check('apple')).toBe(true)
    expect(word.letters[0].status).toBe(LetterStatus.Correct)
    expect(word.letters[1].status).toBe(LetterStatus.Correct)
    expect(word.letters[2].status).toBe(LetterStatus.Correct)
    expect(word.letters[3].status).toBe(LetterStatus.Correct)
    expect(word.letters[4].status).toBe(LetterStatus.Correct)
  })

  it('Gets Wrong Word', () => {
    const word = new Word('apple')
    expect(word.check('plane')).toBe(false)
    expect(word.letters[0].status).toBe(LetterStatus.Misplaced)
    expect(word.letters[1].status).toBe(LetterStatus.Misplaced)
    expect(word.letters[2].status).toBe(LetterStatus.Wrong)
    expect(word.letters[3].status).toBe(LetterStatus.Misplaced)
    expect(word.letters[4].status).toBe(LetterStatus.Correct)
  })

  it('Filters Incorrect Words From WordList', () => {
      // Arrange
      const GuessWord = new Word('apple')
      const secretWord = 'pales'
      const wordList : string[] = ["peach", "pears", "carps", "leapy", "creep", "leper"];

      
      // Act
      GuessWord.check(secretWord)
      const newList = WordsService.validWords(GuessWord, wordList)
      //Assert
      expect(newList).toBe(['peach', 'leapy', 'creep', 'leper']);

  });
})
