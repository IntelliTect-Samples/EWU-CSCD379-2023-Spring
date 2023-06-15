import Axios from 'axios'

export abstract class LeaderboardService {
  static async getTopUsers(): Promise<string[]> {
    const result = await Axios.get('/User/TopUsers')
    console.log(result.data)
    return result.data
  }
  static async getTopClips(): Promise<string[]> {
    const result = await Axios.get('/Clip/TopClips')
    console.log(result.data)
    return result.data
  }
}
