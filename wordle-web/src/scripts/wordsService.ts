import Axios from 'axios'

export abstract class WordsService {
  static getRandomWord(): string {
    //return this.#words[Math.floor(Math.random() * this.#words.length)]
    return 'fails'
  }

  static wordUrl = 'word'

  static async getWordFromApi(): Promise<string> {
    // Make axios call to get the word from
    const response = await Axios.get(this.wordUrl)

    console.log(response.data)
    return response.data
  }

  static isValidWord(word: string): boolean {
    return this.#words.includes(word)
  }

  static validWords(): Array<string> {
    //Todo
    return new Array<string>()
  }

  // From: https://github.com/kashapov/react-testing-projects/blob/master/random-word-server/five-letter-words.json
  static readonly #words: string[] = []
}
