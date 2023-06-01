<template>
  <v-container class="fill-height" fluid>
    <v-row justify="center">
      <v-col cols="12" style="display: flex; justify-content: center">
        <div style="display: flex; align-items: center; justify-content: center; flex-wrap: wrap">
          <v-icon icon="mdi-alpha-w-box-outline" :size="130"></v-icon>
          <h1 class="text-h1">Wordle</h1>
        </div>
      </v-col>
      <v-col cols="12" style="display: flex; flex-direction: column; max-width: 16em; gap: 6px">
        <v-btn variant="elevated" class="text-h6 button" to="/wordoftheday"> Daily Wordle </v-btn>
        <v-btn variant="elevated" class="text-h6 button" to="/wordle"> Wordle Mind Bender </v-btn>
        <v-btn variant="elevated" class="text-h6 button" to="/leaderboard"> Leaderboard </v-btn>
        <v-btn variant="elevated" class="text-h6 button" to="/instructions"> Instructions </v-btn>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { Services } from '@/scripts/services'
import { inject, reactive } from 'vue'
import { useDisplay } from 'vuetify/lib/framework.mjs'
const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>
</script>

<style scoped>
.button {
  min-width: 140px;
  min-height: 60px;
}
</style>
