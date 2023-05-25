import Axios from 'axios'

export abstract class LeaderboardService {
  static async getLeaderboardFromApi(): Promise<string[]> {
    const result = await Axios.get('/leaderboard')
    console.log(result.data)
    return result.data
  }
  static async getDailyLeaderboard(): Promise<string[]> {
    const result = await Axios.get('/leaderboard/daily?name=' + localStorage.getItem('name'))
    console.log(result.data)
    return result.data
  }
}
