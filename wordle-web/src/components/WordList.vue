<template>
  <v-btn prominent color="primary">
    Valid Word Count: {{ game?.validWordList.length }}
    <v-dialog width="300px" height="200px" v-model="dialog" activator="parent">
      <v-card width="100%" height="100%">
        <v-list>
          <v-list-item v-for="word in game?.validWordList" :key="word">
            <v-btn color="primary" block @click="submitWord(word)">{{ word }}</v-btn>
          </v-list-item>
        </v-list>
      </v-card>
    </v-dialog>
  </v-btn>
</template>
<script setup lang="ts">
import type { WordleGame } from '@/scripts/wordleGame'
import { ref } from 'vue'
export interface Props {
  game?: WordleGame
}
const props = defineProps<Props>()
let dialog = ref(false)
function submitWord(word: string) {
  props.game?.selectGuess(word)
}
</script>
