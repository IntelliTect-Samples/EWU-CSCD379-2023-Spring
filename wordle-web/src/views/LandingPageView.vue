<template>
  <v-container class="fill-height" fluid>
    <v-row justify="center">
      <v-col cols="12" style="display: flex; justify-content: center">
        <div style="display: flex; align-items: center; justify-content: center; flex-wrap: wrap">
          <h1 class="text-h2">Lets Play Wordle!</h1>
        </div>
      </v-col>
      <v-col cols="12" style="display: flex; flex-direction: column; max-width: 16em; gap: 10px">
        <v-btn
          variant="outlined"
          class="text-h6"
          style="min-height: 60px; min-width: 140px"
          to="/wordoftheday"
          >Daily Wordle</v-btn
        >
        <v-btn
          variant="outlined"
          class="text-h6"
          style="min-height: 60px; min-width: 140px"
          to="/wordle"
          >Random Wordle</v-btn
        >
        <v-btn
          variant="outlined"
          class="text-h6"
          style="min-height: 60px; min-width: 140px"
          to="/instructions"
          >Instructions</v-btn
        >
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
