import type { Player } from './player'

export class DateWord {
  dateWordId: number = -1
  date : Date = new Date()
  totalAttempts: number = -1
  totalSeconds: number = -1
  attempts :number = -1
  seconds :number = -1
  totalGames: number = -1
  previousPlayers: Player[] = []
  playerId : string = ''
}
