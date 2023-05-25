import Axios from 'axios'

let previousWords: string[]

Axios.get('Word/PreviousWords')
  .then((response) => {
    previousWords = response.data
    console.log(previousWords)
  })
  .catch((error) => {
    console.log(error)
  })

export { previousWords }
