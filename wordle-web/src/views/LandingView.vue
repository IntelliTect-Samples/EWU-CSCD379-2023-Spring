<template>
  <v-container class="fill-height" fluid>
    <v-row justify="center">
      <v-col cols="12">
        <h1 class="text-h2" style="text-align: center">Let's Play Wordle!</h1>
      </v-col>
      <v-col cols="12" style="display: flex; flex-direction: column; align-items: center">
        <v-btn
          variant="outlined"
          class="text-h6"
          style="min-height: 60px; min-width: 200px; margin-bottom: 10px"
          to="/wordoftheday"
        >
          Daily Wordle
        </v-btn>
        <v-btn
          variant="outlined"
          class="text-h6"
          style="min-height: 60px; min-width: 200px; margin-bottom: 10px"
          to="/wordle"
        >
          Random Wordle
        </v-btn>
        <v-btn
          variant="outlined"
          class="text-h6"
          style="min-height: 60px; min-width: 200px"
          to="/instructions"
        >
          Instructions
        </v-btn>
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
