export class GameResult {
  playerId: string = ''
  attempts: number = 0
  durationInSeconds: number = 0
  wasGameWon: boolean = false
  wordPlayed: string = ''
  wordOfTheDayDate: Date | null = new Date()
}
