import Axios  from "axios";
import { Player } from "./player";


export abstract class PlayerService {

  // takes name -> returns new Player Object
  static async AddNewPlayer(name: string){
      const response = await Axios.post<Player>(`Player/CreateNewPlayer?name=${name}`);
      {
        return new Player(
          response.data.playerId, 
          response.data.name, 
          response.data.score, 
          response.data.gameCount, 
          response.data.averageAttempts);
      }
  }

  // takes playerId -> returns Player Object
  static async GetPlayerById(playerId: number){
    const response = await Axios.get<Player>(`Player/GetPlayer?playerId=${playerId}`);
    {
      return new Player(
        response.data.playerId, 
        response.data.name, 
        response.data.score, 
        response.data.gameCount, 
        response.data.averageAttempts);
    }
  }

  // takes playerId and newName -> returns Player Object
  static async UpdatePlayerName(Name: string, Id: number){ // This is broke :()

    const updateNameDto = { Id: Id, newName: Name  };
    const response = await Axios.put<Player>(`Player/UpdatePlayer`, updateNameDto);
    {
    return new Player(
      response.data.playerId, 
      response.data.name, 
      response.data.score, 
      response.data.gameCount, 
      response.data.averageAttempts);
    }
  }

  // takes playerId and score -> returns Player Object
  static async AddOrUpdatePlayerScore(user: Player) { // Broken :()
    try {
      const playerDto = {
        PlayerId: user.playerId,
        Name: user.name,
        Score: user.score,
        GameCount: user.gameCount,
        AverageAttempts: user.averageAttempts
      };
      const response = await Axios.post<Player>(`Player/AddOrUpdatePlayerScore`, playerDto);
      return new Player(
        response.data.playerId,
        response.data.name,
        response.data.score,
        response.data.gameCount,
        response.data.averageAttempts);
    } catch (error) {
      console.error("Error in AddOrUpdatePlayerScore:", error);
      throw error;
    }
  }
}