export class Player {
  name!: string
  average!: number

  constructor(char: string, avg: number) {
    this.name = char
    this.average = avg
  }

  getPlayerName() {
    return this.name
  }

  getPlaverAvg() {
    return this.average
  }
}
