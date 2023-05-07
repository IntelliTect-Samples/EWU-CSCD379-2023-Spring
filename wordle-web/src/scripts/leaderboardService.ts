import Axios from 'axios'

export abstract class LeaderboardService {
  static leaderboardUrl = 'https://wordleweb.azurewebsites.net/leaderboard'

  static async getLeaderboardFromApi(): Promise<string[]> {
    const result = await Axios.get(this.leaderboardUrl)
    console.log(result.data)
    return result.data
  }
}
