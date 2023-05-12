import { LetterUsage } from './letterUsage'
import { LetterUsageSummary, UsageSummary } from './usageSummary'

export class LetterUsages extends Array<LetterUsage> {
  // Allow getting or creating a letter easily.
  getOrAdd(char: string, length: number): LetterUsage {
    let result = this.find((l) => l.char === char)
    if (!result) {
      result = new LetterUsage(char, length!)
      this.push(result)
    }
    return result
  }

  // Allow getting or creating a letter easily.
  get(char: string): LetterUsage {
    const result = this.find((l) => l.char === char)
    if (!result) {
      throw new Error(`Letter ${char} not found`)
    }
    return result
  }

  public clearCurrentCounts() {
    this.forEach((lu) => {
      lu.currentCount = 0
      lu.wasMaxCountFound = false
    })
  }

  public updateOccurrencesFromCurrentCounts() {
    for (const letterUsage of this) {
      if (letterUsage.currentCount !== null) {
        // If we found all the letters set the max
        if (letterUsage.wasMaxCountFound) {
          letterUsage.maximumOccurrences = letterUsage.currentCount
        }
        // Always set the min if we can
        if (
          letterUsage.minimumOccurrences === null ||
          letterUsage.minimumOccurrences < letterUsage.currentCount
        ) {
          letterUsage.minimumOccurrences = letterUsage.currentCount
        }
      }
    }
  }

  public summary() {
    const result = new UsageSummary()
    if (this.length === 0) return result
    const wordLength = this[0].usages.length
    for (let i = 0; i < wordLength; i++) {
      result.correctLetters.push('?')
    }
    for (const letterUsage of this) {
      if (letterUsage.maximumOccurrences === 0) {
        result.wrongLetters.push(letterUsage.char)
      } else {
        const letterUsageSummary = new LetterUsageSummary(letterUsage.char)
        for (const [index, usage] of letterUsage.usages.entries()) {
          if (usage === 'C') {
            result.correctLetters[index] = letterUsage.char
            letterUsageSummary.locations[index] = letterUsage.char
          } else if (usage === 'X') {
            letterUsageSummary.locations[index] = 'X'
          } else {
            letterUsageSummary.locations[index] = '?'
          }
        }
        if (letterUsage.maximumOccurrences !== null) {
          letterUsageSummary.count = letterUsage.maximumOccurrences
          letterUsageSummary.isMaxKnown = true
        } else if (letterUsage.minimumOccurrences !== null) {
          letterUsageSummary.count = letterUsage.minimumOccurrences
        }
        result.misplacedLetters.push(letterUsageSummary)
      }
    }

    return result
  }
}
