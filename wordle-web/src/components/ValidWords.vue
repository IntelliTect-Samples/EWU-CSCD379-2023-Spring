<template>
    <v-layout @click="drawer = false">
      <v-navigation-drawer v-model="drawer" location="bottom" temporary>
        <v-list>
          <v-list-item v-for="word in game?.validWordList" :key="word">
            <v-btn color="black" block @click="submitWord(word)">{{ word }}</v-btn>
          </v-list-item>
        </v-list>
      </v-navigation-drawer>
      <v-btn prominent color="black" @click.stop="drawer = !drawer">
        Valid Word Count: {{ game?.validWordList.length }}
      </v-btn>
    </v-layout>
  </template>
  <script setup lang="ts">
  import type { WordleGame } from '@/scripts/wordleGame'
  import { ref } from 'vue'
  export interface Props {
    game?: WordleGame
  }
  const props = defineProps<Props>()
  let drawer = ref(false)
  function submitWord(word: string) {
    props.game?.selectGuess(word)
  }
  </script>