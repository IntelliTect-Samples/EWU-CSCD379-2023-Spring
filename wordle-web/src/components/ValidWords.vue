<template>
  <v-row justify="center">
    <v-dialog scrollable width="auto">
      <template v-slot:activator="{ props }">
        <v-btn color="primary" v-bind="props">
          {{ WordsService.validWords(game.guess.text).length }}
        </v-btn>
      </template>
      <v-card>
        <v-card-title>Valid Words</v-card-title>
        <v-divider></v-divider>
        <v-list>
          <v-list-item
            v-for="(item, i) in WordsService.validWords(props.game.guess.text)"
            :key="i"
            :value="item"
            active-color="primary"
            variant="plain"
            :title="item"
            @click="fillGuess(item)"
          />
        </v-list>
        <v-card-text style="height: 300px"> </v-card-text>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script setup lang="ts">
import type { WordleGame } from '@/scripts/wordleGame'
import { WordsService } from '@/scripts/wordsService'
const props = defineProps<{
  game: WordleGame
}>()
const emits = defineEmits<{
  (event: 'fillGuess', value: string): void
}>()

function fillGuess(guess: string) {
  emits('fillGuess', guess)
}
</script>
