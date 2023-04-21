<template>
  <v-btn color="primary">
    {{ game?.validWordList.length }}

    <v-menu activator="parent">
      <v-list>
        <v-list-item v-for="word in game?.validWordList" :key="word">
          <v-btn block @click="submitWord(word)"> {{ word }}</v-btn>
        </v-list-item>
      </v-list>
    </v-menu>
  </v-btn>
</template>

<script setup lang="ts">
import type { WordleGame } from '@/scripts/wordleGame'

export interface Props {
  game?: WordleGame
}

const props = defineProps<Props>()

function submitWord(word: string) {
  props.game?.selectGuess(word)
}
</script>
