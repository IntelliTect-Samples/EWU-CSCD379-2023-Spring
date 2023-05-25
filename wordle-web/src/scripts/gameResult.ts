export class GameResult {
  playerId: string = ''
  attempts: number = 0
  durationInSeconds: number = 0
  wasGameWon: boolean = false
  wordPlayed: string = ''
  wasWordOfTheDay: boolean = false
  wordDate: Date = new Date()
}
