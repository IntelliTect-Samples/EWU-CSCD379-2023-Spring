import Axios from 'axios'

let previousWords: string[]

Axios.get("https://localhost:7060/Word/PreviousWords")
    .then((response) => {
        previousWords = response.data
        console.log(previousWords)
    })
    .catch((error) => {
        console.log(error)
    })

export { previousWords }