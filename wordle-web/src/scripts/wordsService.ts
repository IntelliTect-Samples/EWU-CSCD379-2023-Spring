import Axios from 'axios'

export abstract class WordsService {
  private static words: string[] = []
  private static wordUrl: string = 'https://wordleweb2023.azurewebsites.net/word'

  static async getWordFromApi(): Promise<string> {
    const response = await Axios.get(this.wordUrl)
    console.log(response.data)
    return response.data
  }

  static async getWordListFromApi() {
    Axios.get('word/GetWordList')
      .then((response) => {
        setTimeout(() => {}, 100)
        this.words = response.data
      })
      .catch((err) => {
        console.log(err)
      })
    console.log(this.words)
  }

  static validWords(word: string): Array<string> {
    const validWords: Array<string> = []

    this.words.forEach((wordObj) => {
      if (wordObj.startsWith(word)) {
        validWords.push(wordObj)
      }
    })

    return validWords
  }
}
