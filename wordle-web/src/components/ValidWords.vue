<template>
  <v-expansion-panels v-model="wordDialog">
    <v-expansion-panel>
      <v-expansion-panel-header
        >Valid Words ({{ possibleWords.length }}) Press Enter to submit guess:
      </v-expansion-panel-header>
      <v-expansion-panel-content>
        <v-table height="500px" class="pa-3" hover>
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

let wordDialog = ref(false)

function getValidWords(currentGuess: Word): Word[] {
  const partialGuess = currentGuess.letters.map((letter) => letter.char).join('')
  return WordsService.validWords(partialGuess)
}

function clickWord(word: Word) {
  wordDialog.value = false

  // Find the first row with an empty letter and update it
  const targetRow = props.game.guesses.findIndex((guess) =>
    guess.letters.some((letter) => !letter.char)
  )

  if (targetRow !== -1) {
    word.letters.forEach((letter, i) => {
      // eslint-disable-next-line vue/no-mutating-props
      props.game.guesses[targetRow].letters[i] = letter
    })
  }
}
</script>

<style scoped>
.v-card-text,
td {
  cursor: pointer;
}
</style>
