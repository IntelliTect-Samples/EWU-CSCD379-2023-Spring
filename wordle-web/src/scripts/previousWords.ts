import Axios from 'axios'
import { gameData } from '@/scripts/gameData'

let previousWords: Array<gameData>

Axios.get('Word/GetPreviousGames')
  .then((response) => {
    previousWords = response.data
    console.log(previousWords)
  })
  .catch((error) => {
    console.log(error)
  })

export { previousWords }
