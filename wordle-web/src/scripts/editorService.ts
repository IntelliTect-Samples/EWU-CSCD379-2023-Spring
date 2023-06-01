import Axios from 'axios'

export abstract class EditorService {
  static async getAllWords(): Promise<string[]> {
    const result = await Axios.get('/Word/AllWords')
    console.log(result.data)
    return result.data
  }
  static async getAllIsCommon(): Promise<string[]> {
    const result = await Axios.get('/Word/AllIsCommon')
    console.log(result.data)
    return result.data
  }
}
