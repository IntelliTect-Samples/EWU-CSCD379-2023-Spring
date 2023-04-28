<template>
  <v-expansion-panels v-model="drawer" color="black">
    <v-expansion-panel>
      <v-expansion-panel-header>
        Words Available = {{ possibleWords.length }}. Press Enter to submit a valid word as a guess.
      </v-expansion-panel-header>
      <v-expansion-panel-content>
        <v-table height="250px" hover>
          <tbody>
            <tr v-for="(word, i) in possibleWords" :key="i">
              <td @click="clickWord(word)">
                {{ word.text }}
              </td>
            </tr>
          </tbody>
        </v-table>
      </v-expansion-panel-content>
    </v-expansion-panel>
  </v-expansion-panels>
</template>
<script setup lang="ts">
import type { Word } from '@/scripts/word'
import type { WordleGame } from '@/scripts/wordleGame'
import { WordsService } from '@/scripts/wordsService'
import { ref, watch } from 'vue'

const props = defineProps<{
  game: WordleGame
}>()
const possibleWords = ref<Array<Word>>([])
watch(
  () => props.game.guess,
  () => {
    possibleWords.value = getValidWords(props.game.guess)
  },
  { deep: true }
)
let drawer = ref(false)
function getValidWords(currentGuess: Word): Word[] {
  const partialGuess = currentGuess.letters.map((letter) => letter.char).join('')
  return WordsService.validWords(partialGuess)
}
function clickWord(word: Word) {
  drawer.value = false
  const targetRow = props.game.guesses.findIndex((guess) =>
    guess.letters.some((letter) => !letter.char)
  )
  if (targetRow !== -1) {
    word.letters.forEach((letter, i) => {
      props.game.guesses[targetRow].letters[i] = letter
    })
  }
}
</script>