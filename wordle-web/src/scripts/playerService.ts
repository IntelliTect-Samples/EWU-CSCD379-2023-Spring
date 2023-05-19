import Axios from 'axios'
import { Player } from './player'
import { reactive, ref } from 'vue'

export class PlayerService {
  // This is a reactive type, don't assign, update properties
  readonly player: Player
  isLoaded: boolean = false
  isOnline = ref(false)

  constructor() {
    this.player = reactive(new Player())
    this.player.playerId = localStorage.getItem('userId') ?? ''
    this.player.name = localStorage.getItem('userName') ?? 'Guest'
  }

  setupPlayerAsync = async () => {
    if (!this.player.playerId) {
      try {
        const response = await Axios.post('/Player/CreatePlayer', this.player.name, {
          headers: { 'Content-Type': 'application/json' }
        })
        this.player.playerId = response.data.playerId
        localStorage.setItem('userId', this.player.playerId)
        localStorage.setItem('userName', this.player.name)
        this.isOnline.value = true
      } catch (error) {
        this.isOnline.value = false
      }
    } else if (!this.isLoaded) {
      await this.refreshPlayerFromServerAsync()
    }
  }

  refreshPlayerFromServerAsync = async () => {
    try {
      const response = await Axios.get(`/Player?playerId=${this.player.playerId}`)
      this.player.name = response.data.name
      this.player.gameCount = response.data.gameCount
      this.player.averageAttempts = response.data.averageAttempts
      this.player.averageSecondsPerGame = response.data.averageSecondsPerGame
      localStorage.setItem('userName', this.player.name)
    } catch (error) {
      this.isOnline.value = false
    }
  }

  ChangeNameAsync = async (name: string) => {
    if (!this.isOnline) return
    this.player.name = name
    localStorage.setItem('userName', name ?? 'Guest')
    return Axios.post(`/Player/RenamePlayer`, this.player)
  }
}
