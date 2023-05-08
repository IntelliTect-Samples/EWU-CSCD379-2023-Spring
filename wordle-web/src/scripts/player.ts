import Axios  from "axios";

export class Player {
    playerId: number;
    name: string;
    score: number;
    gameCount: number;
    averageAttempts: number;
  
    constructor(playerId: number, name: string, score: number, gameCount: number, averageAttempts: number) {
      this.playerId = playerId;
      this.name = name;
      this.score = score;
      this.gameCount = gameCount;
      this.averageAttempts = averageAttempts;
    }

    static async AddNewPlayer(name: string) {
      await Axios.post("/Player/CreateNewPlayer", {
        name: name
      })
      .then((response) => {
        console.log(response.data)
      })
      .catch((error) => {
        console.log(error)
      })
    }
}
  
// function addWord() {
//   overlay.value = true
//   Axios.post('word/AddWordFromBody', {
//     text: 'strin',
//     isCommon: true,
//     isUsed: false
//   })
//     .then((response) => {
//       overlay.value = false
//       console.log(response.data)
//     })
//     .catch((error) => {
//       console.log(error)
//     })
// }