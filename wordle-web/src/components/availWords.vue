<template>
  <v-expansion-panels v-model="wordDialog">
    <v-expansion-panel>
      <v-expansion-panel-header>
        Words available ({{ possibleWords.length }}) Start typing to reveal the words
      </v-expansion-panel-header>
      <v-expansion-panel-content>
        <v-table height="500px" class="pa-3" hover>
          <tbody>
            <tr v-for="(word, i) in possibleWords" :key="i" @click="wordClicked(word)">
              <td>
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

const possibleWords = ref<Word[]>([])

watch(
  () => props.game.guess,
  () => {
    possibleWords.value = getValidWords(props.game.guess)
  },
  { deep: true }
)

const wordDialog = ref(false)

function getValidWords(currentGuess: Word): Word[] {
  const partialGuess = currentGuess.letters.map((letter) => letter.char).join('')
  return WordsService.currentG(partialGuess)
}

function wordClicked(word: Word) {
  wordDialog.value = false
  const emptyLetterIndex = props.game.guesses.findIndex((guess) =>
    guess.letters.some((letter) => !letter.char)
  )
  if (emptyLetterIndex !== -1) {
    const emptyLetterGuess = props.game.guesses[emptyLetterIndex]
    word.letters.forEach((letter, i) => {
      emptyLetterGuess.letters[i] = letter
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
