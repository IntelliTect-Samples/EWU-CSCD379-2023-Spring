<template>
  <h1>LeaderBoard</h1>
  <div>
    <v-carousel class="h-auto w-auto pb-13">
      <v-carousel-item>
        <v-card class="px-16 text-center">
          <Leaderboard />
        </v-card>
      </v-carousel-item>
      <v-carousel-item>
        <v-card class="px-16 text-center">
          <PersonalStats />
        </v-card>
      </v-carousel-item>
    </v-carousel>
  </div>
</template>

<script setup lang="ts">
import PersonalStats from '@/components/DisplayBoards/PersonalStatsCard.vue'
import Leaderboard from '@/components/DisplayBoards/LeaderboardCard.vue'
</script>

<style>
.v-card {
  height: 100%;
}
</style>
