<template>
  <div>
        <v-card flat color="transparent">
          <v-card-title align="center">
            Possible Words From Word List That Are Avalible (Click on Number)
          </v-card-title>
          <v-card-text
            align="center"
            class="text-h4"
            @click="wordDialog = !wordDialog" >
            {{ possibleWords.length }}
          </v-card-text>
        </v-card>
  </div>
  <v-dialog v-model="wordDialog" max-width="350">
    <v-card >
      <v-table height="350px" hover>
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
