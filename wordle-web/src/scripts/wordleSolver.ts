import { LetterStatus } from './letter'
import { LetterUsages } from './letterUsages'
import type { Word } from './word'
import type { WordleGame } from './wordleGame'
import { WordsService } from './wordsService'

export class WordleSolver {
  constructor(game: WordleGame) {
    this.game = game
  }
  game: WordleGame
  availableWords: string[] = []
  letterUsages: LetterUsages = new LetterUsages()
  bestGuessOfValidWords: string = ''
  bestGuessOfInvalidWords: string = ''

  calculate() {
    this.letterUsages = this.getLetterUsages()
    this.availableWords = this.getAvailableWords()
    this.bestGuessOfValidWords = this.getBestGuessOfValidWords()
    this.bestGuessOfInvalidWords = this.getBestGuessOfInvalidWords()
  }

  // Calculate the available words based on the current state of the game
  getAvailableWords(testWord?: Word, wordList?: string[]): string[] {
    // Get a letter map which is map of each letter that has been guessed with an array
    // of locations the letter either is absolutely 'C', can't be 'X', or might be '?'.
    const map = testWord ? this.getLetterUsages(testWord) : this.letterUsages
    const availableWords = new Array<string>()

    const wordsToCheck = wordList || WordsService.allWords()
    // Iterate over all the possible words
    for (const word of wordsToCheck) {
      // Create a variable to track if this word is valid based on guessed words.
      let isGood = true
      // Iterate over each of the letter maps.
      for (const letterUsage of map) {
        // If the word doesn't match the letter map, mark it as bad and bail from the loop.
        if (!letterUsage.matchWord(word)) {
          isGood = false
          break
        }
      }
      // If the word made it through all the letter maps, add it to the list of available words.
      if (isGood) availableWords.push(word)
    }
    return availableWords
  }

  getLetterUsages(testWord?: Word) {
    // Create an array of each letter that has been guessed with an array of locations
    // the letter either is absolutely 'C', can't be 'X', or might be ' ? '.
    const letterUsages = new LetterUsages()
    const myGuesses = this.game.guesses.filter((g) => g.isScored)
    if (testWord) myGuesses.push(testWord)
    // Iterate all the guesses
    for (const guess of myGuesses) {
      //console.log(guess.text)
      // Clear the current letter counts for this word
      letterUsages.clearCurrentCounts()
      // Iterate all the letters in the guess
      for (const [index, letter] of guess.letters.entries()) {
        // Make sure the guess is a letter and not blank
        if (letter.char === '') continue
        // If the letter hasn't been added to the array yet, add it with all unknowns
        const letterUsage = letterUsages.getOrAdd(letter.char, this.game.secretWord.length)
        if (letterUsage.currentCount == null) letterUsage.currentCount = 0
        if (letter.status == LetterStatus.Correct) {
          // If this letter is correct, mark it as correct in the array for this index
          letterUsage.usages[index] = 'C'
          letterUsage.currentCount++
          if (letterUsage.wasMaxCountFound) {
            // If the max count was already found, mark all the unknowns as X
            letterUsage.usages.forEach((value, index) => {
              if (value == '?') {
                letterUsage!.usages[index] = 'X'
              }
            })
          }
        } else if (letter.status == LetterStatus.Misplaced) {
          // Misplaced indexes are marked with a X
          letterUsage.usages[index] = 'X'
          letterUsage.currentCount++
        } else {
          // The value is incorrect
          // If there is already an X in the array that means this letter has been misplaced
          // once already as the result of a misplaced letter. Just change this one index
          // to X because we don't know for sure that this letter is totally wrong in all
          // locations
          if (letterUsage.usages.indexOf('X') > -1) {
            letterUsage.usages[index] = 'X'
          } else {
            // If the letter is incorrect, replace any unknowns with X.
            // Any subsequent correct guesses will override this.
            letterUsage.usages.forEach((value, index) => {
              if (value == '?') {
                letterUsage!.usages[index] = 'X'
              }
            })
          }
          // Is this letter is wrong, we found the max.
          letterUsage.wasMaxCountFound = true
        }
      }
      letterUsages.updateOccurrencesFromCurrentCounts()
    }
    return letterUsages
  }

  getBestGuessOfValidWords() {
    const availableWords = this.availableWords
    // Count all the letters in the available words
    const letterCounts = new Map<string, number>()
    'abcedfgihjklmnopqrstuvwxyz'.split('').forEach((char) => letterCounts.set(char, 0))
    for (const word of availableWords) {
      for (const char of word) {
        letterCounts.set(char, letterCounts.get(char)! + 1)
      }
    }

    let bestWord = ''
    let bestWordCount = 0

    if (availableWords.length <= 2) {
      // There is only one or two words left.
      bestWord = availableWords[0]
    } else {
      for (const word of availableWords) {
        let count = 0
        let chars = ''
        for (const char of word) {
          if (chars.indexOf(char) == -1) {
            chars += char
            count += letterCounts.get(char)!
          } else {
            //count += letterCounts.get(char)! * 0.25
          }
        }
        if (bestWordCount < count) {
          bestWord = word
          bestWordCount = count
        }
      }
    }
    return bestWord
  }

  getBestGuessOfInvalidWords() {
    const availableWords = this.availableWords
    if (availableWords.length <= 2) return availableWords[0]
    // Count all the letters in the available words
    const letterCounts = new Map<string, number>()
    'abcedfgihjklmnopqrstuvwxyz'.split('').forEach((char) => letterCounts.set(char, 0))
    for (const word of availableWords) {
      for (const char of word) {
        letterCounts.set(char, letterCounts.get(char)! + 1)
      }
    }

    const usages = this.getLetterUsages()
    //Remove letters that are already guessed
    for (const [letter, count] of letterCounts) {
      if (usages.filter((u) => u.char == letter).length > 0) {
        letterCounts.delete(letter)
      }
    }

    // Convert to array so we can sort it
    const unusedLetters = Array.from(letterCounts, ([char, count]) => ({ char, count })).sort(
      (a, b) => b.count - a.count
    )

    const maxLength = unusedLetters.length >= 5 ? 5 : unusedLetters.length

    // Grab the top 5, 4, 3, 2, 1 letters and see if we have words that will eliminate the most letters
    const validWords = new Array<string>()
    for (let i = maxLength; i > 0; i--) {
      const letters = unusedLetters.slice(0, i).map((l) => l.char)
      // Iterate all words and see if a word contains them all
      for (const word of WordsService.allWords()) {
        let hasAllLetters = true
        for (const letter of letters) {
          if (word.indexOf(letter) == -1) {
            hasAllLetters = false
            break
          }
        }
        if (hasAllLetters) {
          validWords.push(word)
        }
      }
      if (validWords.length > 0) {
        //console.log(`Found ${validWords.length} words at ${i} letters`)
        // We found a word that contains all the letters, now find the word that will eliminate the most words
        break
      }
      validWords.length = 0
    }
    if (validWords.length == 0) return '-----'
    // Pick a random word to try.
    return validWords[Math.floor(Math.random() * validWords.length)]
  }
}
