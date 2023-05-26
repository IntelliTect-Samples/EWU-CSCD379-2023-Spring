<template>
  <v-col>
    <v-card
      class="align-center text-center mx-auto"
      max-height="100%"
      max-width="90%"
      min-height="90%"
      min-width="25%"
      rounded
    >
      <v-card-title class="titleText">Word Of The Day Games!</v-card-title>
      <v-card-subtitle class="subText"
        >Red means you've already played, Green means you haven't</v-card-subtitle
      >
      <v-card-text>
        <v-row justify="center">
          <v-col v-for="stats in gameStats" :key="dateToLocaleDateString(stats.date)" class="ma-2">
            <v-btn
              @click="goTo(createNewDate(stats.date))"
              height="100%"
              outlined
              :color="hasPlayerPlayed(playerGuid, stats) ? 'green' : 'red'"
            >
              <span class="bodyText"
                >{{ createNewDate(stats.date) }}
                <div class="stats">
                  <div>Avg Guesses: {{ stats.totalAttempts / stats.totalGames }}</div>
                  <div>Avg Seconds per Game: {{ stats.totalSeconds / stats.totalGames }}</div>
                  <div>Total Games: {{ stats.totalGames }}</div>
                </div>
              </span>
            </v-btn>
          </v-col>
        </v-row>
      </v-card-text>
    </v-card>
  </v-col>
</template>

<script lang="ts">
import Axios from 'axios'
import type { PlayerService } from '@/scripts/playerService'
import { Services } from '@/scripts/services'
import { inject, onMounted, ref } from 'vue'
import type { DateWord } from '@/scripts/dateWord'
import router from '@/router'

export default {
  setup() {
    const playerService = inject(Services.PlayerService) as PlayerService
    const gameStats = ref<DateWord[]>([])
    const playerGuid: string = playerService.player.playerId

    onMounted(() => {
      Axios.get('/dateword/getlasttenwords').then((response) => {
        gameStats.value = response.data as DateWord[]
        console.log(response)
      })
    })

    function hasPlayerPlayed(playerGuid: string, gamestat: DateWord): boolean {
      const playerList = gamestat.previousPlayers
      for (let i = 0; i < playerList.length; i++) {
        if (playerGuid == playerList[i].playerId) {
          return false
        }
      }
      return true
    }

    function createNewDate(date: Date) {
      return new Date(date + `Z`).toLocaleDateString()
    }

    function dateToLocaleDateString(date: Date) {
      return new Date(date).toLocaleDateString()
    }

    function goTo(date: string) {
      router.push({ name: 'wordoftheday', query: { date: date } })
    }

    return {
      gameStats,
      playerGuid,
      hasPlayerPlayed,
      goTo,
      createNewDate,
      dateToLocaleDateString
    }
  }
}
</script>

<style scoped>
@media (max-width: 400px) {
  .bodyText {
    font-size: 12px;
  }
  .subText {
    font-size: 10px;
  }
  .stats {
    font-size: 8px;
    font-style: italic;
  }
  .titleText {
    font-size: 20px;
  }
}

@media (min-width: 401px) {
  .bodyText {
    font-size: 16px;
  }
  .subText {
    font-size: 14px;
  }
  .stats {
    font-size: 12px;
    font-style: italic;
  }
  .titleText {
    font-size: 28px;
  }
}

@media (min-width: 800px) {
  .bodyText {
    font-size: 20px;
  }
  .subText {
    font-size: 18px;
  }
  .stats {
    font-size: 16px;
    font-style: italic;
  }
  .titleText {
    font-size: 36px;
  }
}
</style>
