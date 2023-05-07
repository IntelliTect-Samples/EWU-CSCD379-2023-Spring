<template>
  <main>
    <LeaderBoard :playerName="game.topPlayers" />
  </main>
</template>

<script setup lang="ts">
import LeaderBoard from '@/components/LeaderBoard.vue'
import { WordleGame } from '@/scripts/wordleGame'
import { reactive } from 'vue'
import { onMounted } from 'vue'

let game = reactive(new WordleGame())

onMounted(() => {
  game.getTopPlayers()
})
</script>
