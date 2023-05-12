import Axios from 'axios'
import type { AxiosResponse } from 'axios'
import type { Player } from '@/scripts/player' // Assuming you have a Player type defined

export class LeaderboardService {
  static async GetLeaderboard(count?: number): Promise<Player[]> {
    try {
      const url = 'Leaderboard/'
      const _count = count || 0
      const response: AxiosResponse = await Axios.get(`${url}${_count}`)
      let Leaderboard: Player[] = response.data

      // Sort the leaderboard by score in descending order
      Leaderboard = Leaderboard.sort((a: Player, b: Player) => b.score - a.score)

      return Leaderboard
    } catch (error) {
      console.error(error)
      return []
    }
  }
}
