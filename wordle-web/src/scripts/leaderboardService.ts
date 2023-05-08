import Axios from 'axios';


export class LeaderboardService {
  static async GetLeaderboard() {
    try {
      const response = await Axios.get('/Leaderboard/0');
      const Leaderboard = response.data;

      return Leaderboard.map((player: any) => {
        return {
          playerId: player.playerId,
          name: player.name,
          score: player.score,
          gameCount: player.gameCount,
          averageAttempts: player.averageAttempts,
          // averageTime: player.averageTime,
        };
      });
    } catch (error) {
      console.log(error);
    }
  }
}
