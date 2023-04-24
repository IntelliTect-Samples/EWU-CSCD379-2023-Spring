<template>
  <v-menu :close-on-content-click="false" v-model:model-value="showMenu">
    <template v-slot:activator="{ props }">
      <v-btn :class="`${useDarkText ? 'text-black' : ''}`" text v-bind="props">
        Available Words: {{ availableWords.length }}
      </v-btn>
    </template>
    <v-card>
      <v-card-title> Available Words </v-card-title>
      <v-card-text>
        <v-list height="600px">
          <v-list-item
            v-for="word in doPagination"
            :key="word"
            class="text-h5"
            @click="setGuess(word)"
          >
            {{ word }}
          </v-list-item>
        </v-list>
      </v-card-text>
      <v-card-actions>
        <v-btn text @click="currentPage--">Prev</v-btn>
        <v-spacer />
        <v-btn text @click="currentPage++">Next</v-btn>
      </v-card-actions>
    </v-card>
  </v-menu>
</template>

<script setup lang="ts">
import type { WordleGame } from '@/scripts/wordleGame'
import { WordsService } from '@/scripts/wordsService'
import { computed, ref } from 'vue'
import { useTheme } from 'vuetify'

export interface Props {
  wordleGame: WordleGame
}

const props = defineProps<Props>()

const emits = defineEmits<{
  (event: 'guessChanged', value: string): void
}>()

const { name: themeName } = useTheme()

const showMenu = ref(false)

const wordsPerPage = 12
const currentPage = ref(0)

const availableWords = computed(() => {
  return WordsService.validWords(props.wordleGame)
})

const doPagination = computed(() => {
  let page = currentPage.value
  let shownWords = getPageWords(page)
  if (shownWords.length == 0) {
    page = 0
    shownWords = getPageWords(page)
  }
  return shownWords
})

const useDarkText = computed(() => {
  return themeName.value !== 'dark'
})

function getPageWords(page: number) {
  const start = page * wordsPerPage
  const end = start + wordsPerPage
  return availableWords.value.slice(start, end)
}

function setGuess(word: string) {
  emits('guessChanged', word)
  showMenu.value = false
}
</script>
