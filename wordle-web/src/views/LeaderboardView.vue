<template>
  <h1>LeaderBoard</h1>
  <v-card>
  <div>
    <v-carousel class="h-auto w-auto pb-13" show-arrows="hover">
      <v-carousel-item>
          <Leaderboard/>
      </v-carousel-item>

      <v-carousel-item>
          <PersonalStats/>
      </v-carousel-item>
    </v-carousel>
  </div>
  </v-card>
</template>

<script setup lang="ts">
import PersonalStats from '@/components/LeaderBoard/PersonalStatsCard.vue'
import Leaderboard from '@/components/LeaderBoard/LeaderboardCard.vue'
</script>

<style>
.v-card {
  height: 100%;
}
</style>
