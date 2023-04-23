<template>
  <div>
    <v-row class="justify-center pa-0">
      <v-col cols="auto">
        <v-card flat color="transparent">
          <v-card-title class="text-decoration-underline" align="center">
            Possible Words
          </v-card-title>
          <v-card-text
            align="center"
            class="font-weight-bold cursor-pointer text-h4"
            @click="wordDialog = !wordDialog"
          >
            {{ possibleWords.length }}
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </div>
  <!------------------------ DIALOG -------------------------------->
  <v-dialog v-model="wordDialog" max-width="290">
    <v-card class="pa-3">
      <v-table height="500px" class="pa-3" hover>
        <tbody>
          <tr v-for="(word, i) in possibleWords" :key="i">
            <td @click="clickWord(word)">
              {{ word.text }}
            </td>
          </tr>
        </tbody>
      </v-table>
      <v-btn color="secondary" text @click="wordDialog = false">Close</v-btn>
    </v-card>
  </v-dialog>
  <!---------------------------------------------------------------->
</template>

<script setup lang="ts">
import type { Word } from '@/scripts/word'
import type { WordleGame } from '@/scripts/wordleGame'
import { WordsService } from '@/scripts/wordsService'
import { computed, ref } from 'vue'

const possibleWords = computed(() => {
  let possibleWords: Array<Word> = []
  possibleWords = getValidWords(props.game.currentGuess)
  return possibleWords
})

const props = defineProps<{
  game: WordleGame
}>()

let wordDialog = ref(false)

function getValidWords(currentGuess: Word): Word[] {
  const partialGuess = currentGuess.letters.map((letter) => letter.char).join('')
  return WordsService.validWords(partialGuess)
}

function clickWord(word: Word) {
  // eslint-disable-next-line vue/no-mutating-props
  props.game.currentGuess = word
  wordDialog.value = false
}
</script>

<style scoped>
.v-card-text,
td {
  cursor: pointer;
}
</style>
