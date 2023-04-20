import { describe, it, expect } from 'vitest'
import { Word } from '@/scripts/word'
import { WordsService } from '../wordsService'


describe('validWords', () => {
  it('Filters Incorrect Words From WordList', () => {
    // Arrange
    const GuessWord = new Word('pales')//<-----validation : m m m m w
    const secretWord = 'apple'
    const wordList: string[] = ['peach', 'pears', 'carps', 'leapy', 'creep', 'leper']

    // Act
    GuessWord.check(secretWord)
    const newList = WordsService.validWords(GuessWord, wordList)
    //Assert
    expect(newList).toStrictEqual(['leapy'])//<------correct
  })
})
describe('validWords', () => {
  it('Filters Incorrect Words From WordList test 2, removes leper', () => {
    // Arrange
    const GuessWord = new Word('apple')//<-----validation : m m w m m
    const secretWord = 'pales'
    const wordList: string[] = ['peach', 'pears', 'carps', 'leapy', 'creep', 'leper']

    // Act
    GuessWord.check(secretWord)
    const newList = WordsService.validWords(GuessWord, wordList)
    //Assert
    expect(newList).toStrictEqual(['peach', 'pears', 'carps', 'leapy', 'creep'])
    //one issue is the word leper and guess word apple
    //apple has validation like:
    //          a p p l e
    //          m m w m m
    
    // and leper has a p at index 2
    // which is fine???? maybe?
    // the misplaced letter status on apples first p says that no p's shall be in index 1
    // but is the second p in apple, which is labeled as wrong, also saying that no p's can be at index 2?????
    // if so we have problem 
    
    // we have: 
    //    if(wrong) {remove}
    //    if(misplaced && i1 == i2) { remove}
    // but this causes any word with a p, like creep, to be removed when double letters, which is wrong, 
    // only words with a p at index 2 or words with more than 1 p should be removed
    // which is why we had:
    // if(misplaced)
    //  if(i1 == i2)
    //    remove
    //  else
    //    change l1 and l2 to _
    //    break
    // but this causes problems with the word leper as it would change the p's in leper and apple to _ so we'd have le_er and a_ple and wont remove the word
    // so we might have to loop twice??? maybe?? idk that doesn't solve the problem with the word creep

    // possible solution vvvv
    // --------------------------
    // for each candidate word
    // loop once to find all instances of matching char and index
    //    if( l1 == l2 && i1 == i2)
    //      status == correct { change l1 and l2 to _ }
    //      status == misplaced { change l1 and l2 to _, isValid == false}
    //      status == wrong { change l1 and l2 to _, isValid == false }

    // loop again to find all instances of equal char but not equal index
    //  if( l1 == l2)
    //    status == correct { change l1 and l2 to _ }
    //    status == misplaced { change l1 and l2 to _}
    //    status == wrong { change l1 and l2 to _, isValid == false }
    // ---------------------------
    // ^^^^^idea seems to work^^^^^
  })
  describe('validWords', () => {
    it('Filters Incorrect Words From WordList test 3, double letter WordList word vs single letter guess word', () => {
      // Arrange
      const GuessWord = new Word('pales')//<-----validation : m m m m w
      const secretWord = 'apple'
      const wordList: string[] = ['apple']
  
      // Act
      GuessWord.check(secretWord)
      const newList = WordsService.validWords(GuessWord, wordList)
      //Assert
      expect(newList).toStrictEqual(['apple'])//<------correct
    })
  })
})