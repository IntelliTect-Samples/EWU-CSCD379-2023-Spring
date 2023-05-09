export class UsageSummary {
  correctLetters: string[] = []
  wrongLetters: string[] = []
  misplacedLetters: LetterUsageSummary[] = []
}

export class LetterUsageSummary {
  char: string
  locations: string[] = []
  count: number = 0
  isMaxKnown: boolean = false

  constructor(char: string) {
    this.char = char
  }
}
