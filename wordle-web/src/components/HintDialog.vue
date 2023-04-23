<template>
<div>
    <v-dialog width="auto">
      <template v-slot:activator="{ props }">
        <v-btn color="primary" v-bind="props">
          {{ game.list.length }}
        </v-btn>
      </template>

      <v-card>
        <v-row v-for="word in game.list" :key="word">
          <v-btn @click="enterWord" color="primary">
            {{ word }}
          </v-btn>
        </v-row>
      </v-card>
    </v-dialog>
</div>
</template>

<script setup lang="ts">
import type { WordleGame } from '@/scripts/wordleGame'

defineProps<{
  game: WordleGame
}>()

function enterWord() {
}

</script>