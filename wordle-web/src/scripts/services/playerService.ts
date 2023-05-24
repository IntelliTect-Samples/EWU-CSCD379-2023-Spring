import Axios from 'axios'
import { Player } from '../player'
import { reactive, ref } from 'vue'

export class PlayerService {
  // This is a reactive type, don't assign, update properties.
  readonly player: Player
  isLoaded: boolean = false
  isOnline = ref(false)

  constructor() {
    this.player = reactive(new Player())
    this.player.playerId = localStorage.getItem('userId') ?? ''
    this.player.playerName = localStorage.getItem('userName') ?? 'Guest'
  }

  setupPlayerAsync = async () => {
    if (!this.player.playerId) {
      try {
        const response = await Axios.post('/Player/CreatePlayer', this.player.playerName, {
          headers: { 'Content-Type': 'application/json' }
        })
        this.player.playerId = response.data.playerId
        localStorage.setItem('userId', this.player.playerId)
        localStorage.setItem('userName', this.player.playerName)
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
      this.player.playerName = response.data.playerName
      this.player.gameCount = response.data.gameCount
      this.player.averageAttempts = response.data.averageAttempts
      this.player.averageSecondsPerGame = response.data.averageSecondsPerGame
      localStorage.setItem('userName', this.player.playerName)
    } catch (error) {
      this.isOnline.value = false
    }
  }

  ChangeNameAsync = async (playerName: string) => {
    if (!this.isOnline) return
    this.player.playerName = playerName
    localStorage.setItem('userName', playerName ?? 'Guest')
    return Axios.post(`/Player/RenamePlayer`, this.player)
  }
}
