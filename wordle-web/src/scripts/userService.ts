import { computed, ref } from 'vue'
import Axios from 'axios'

const Id = ref<string | null>(localStorage.getItem('userId'))
const Name = ref<string>(localStorage.getItem('userName') ?? 'Guest')

const createPlayer = async () => {
  const response = await Axios.post('/player')
  const { playerId, name } = response.data
  Id.value = playerId
  Name.value = name
  localStorage.setItem('userId', playerId)
  localStorage.setItem('userName', name)
}

const getPlayer = async () => {
  Axios.get(`/player?id=${Id.value}`)
    .then((response) => {
      Name.value = response.data.name
      localStorage.setItem('userName', response.data.name ?? 'Guest')
    })
    .catch(() => {
      createPlayer()
    })
}

const ChangeNameAsync = async (name: string) => {
  Name.value = name
  localStorage.setItem('userName', name ?? 'Guest')
  return Axios.put(`/player`, { playerId: Id.value, name: name })
}

export const SetupAsync = async () => {
  if (!Id.value) {
    await createPlayer()
  } else {
    await getPlayer()
  }
}

export const Player = {
  Id: computed(() => Id.value),
  Name: computed(() => Name.value),
  SetupAsync,
  ChangeNameAsync,
  TypingName: ref(false)
}
