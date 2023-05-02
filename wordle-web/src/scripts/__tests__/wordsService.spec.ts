import { describe, it, expect } from 'vitest'
import { Word } from '@/scripts/word'
import { WordsService } from '../wordsService'

describe('validWords', () => {
  it('Filters Incorrect Words From WordList', () => {
    // Arrange
    const GuessWord = new Word('pales') //<-----validation : m m m m w
    const secretWord = 'apple'
    const wordList: string[] = ['peach', 'pears', 'carps', 'leapy', 'creep', 'leper']

    // Act
    GuessWord.check(secretWord)
    const newList = WordsService.validWords(GuessWord, wordList)
    //Assert
    expect(newList).toStrictEqual(['leapy']) //<------correct
  })
})
describe('validWords', () => {
  it('Filters Incorrect Words From WordList test 2, removes leper', () => {
    // Arrange
    const GuessWord = new Word('apple') //<-----validation : m m w m m
    const secretWord = 'pales'
    const wordList: string[] = ['peach', 'pears', 'carps', 'leapy', 'creep', 'leper']

    // Act
    GuessWord.check(secretWord)
    const newList = WordsService.validWords(GuessWord, wordList)
    //Assert
    expect(newList).toStrictEqual(['peach', 'pears', 'carps', 'leapy', 'creep'])
  })
})

describe('validWords', () => {
  it('Filters Incorrect Words From WordList test 3, double letter WordList word vs single letter guess word', () => {
    // Arrange
    const GuessWord = new Word('pales') //<-----validation : m m m m w
    const secretWord = 'apple'
    const wordList: string[] = ['apple']

    // Act
    GuessWord.check(secretWord)
    const newList = WordsService.validWords(GuessWord, wordList)
    //Assert
    expect(newList).toStrictEqual(['apple']) //<------correct
  })
})
