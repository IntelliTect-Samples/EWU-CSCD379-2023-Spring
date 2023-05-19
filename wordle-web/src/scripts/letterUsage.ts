export class LetterUsage {
  public char: string
  public usages: string[] = []
  public minimumOccurrences: number | null = null
  public maximumOccurrences: number | null = null
  // This field is used during the calculation to hold the number of letters found in the word for this guess
  public currentCount: number | null = null
  // If we hit an wrong letter, we know the max count.
  public wasMaxCountFound: boolean = false

  public constructor(char: string, lengthOrArray: number | string[]) {
    this.char = char
    if (typeof lengthOrArray === 'number') {
      for (let i = 0; i < lengthOrArray; i++) {
        this.usages.push('?')
      }
    } else {
      this.usages = lengthOrArray
    }
  }

  matchWord(word: string) {
    // Iterate over each place in the letter map and compare it to the word.
    // check if all entries are 'X'
    if (this.maximumOccurrences === 0) {
      // If all the entries are 'X', the word must not contain the letter.
      return !word.includes(this.char)
    }
    // The letter must appear at least once in the word.
    if (!word.includes(this.char)) return false
    for (const [index, status] of this.usages.entries()) {
      if (status == 'X') {
        // If the letter map is an 'X' and the word letter is the same as the letter, fail
        if (word[index] == this.char) return false
      } else if (status == 'C') {
        // If the letter map is a 'C' and the word letter is not the same as the letter, fail.
        if (word[index] != this.char) return false
      }
      // The ? case is unnecessary because it is the default state.
    }
    // Check min and max counts
    let count = 0
    for (const letter of word) {
      if (letter === this.char) {
        count++
      }
    }
    if (this.minimumOccurrences !== null) {
      if (count < this.minimumOccurrences) {
        return false
      }
    }
    if (this.maximumOccurrences !== null) {
      if (count > this.maximumOccurrences) {
        return false
      }
    }

    return true
  }
}
