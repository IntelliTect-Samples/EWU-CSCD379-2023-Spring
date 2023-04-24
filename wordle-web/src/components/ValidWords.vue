<template>
  <v-menu :close-on-content-click="false" v-model:model-value="showMenu">
    <template v-slot:activator="{ props }">
      <v-btn text v-bind="props"> Word Count: {{ wordList.length }} </v-btn>
    </template>
    <v-card>
      <v-card-title> Valid Words </v-card-title>
      <v-card-text>
        <v-list height="720px">
          <v-list-item v-for="word in paginate" :key="word" class="text-h7" @click="setWord(word)">
            {{ word }}
          </v-list-item>
        </v-list>
      </v-card-text>
      <v-card-actions>
        <v-btn text @click="curPage--">Prev</v-btn>
        <v-spacer />
        <v-btn text @click="curPage++">Next</v-btn>
      </v-card-actions>
    </v-card>
  </v-menu>
</template>

<script setup lang="ts">
import { computed, ref } from 'vue'

export interface Props {
  list: string[]
}
const props = defineProps<Props>()
const emits = defineEmits<{
  (event: 'setWord', value: string): void
}>()
const showMenu = ref(false)
const wordsPerPage = 50
const curPage = ref(0)
const wordList = computed(() => {
  return props.list
})
const paginate = computed(() => {
  let page = curPage.value
  let shownWords = getPWords(page)
  if (shownWords.length == 0) {
    page = 0
    shownWords = getPWords(page)
  }
  return shownWords
})

function getPWords(page: number) {
  const start = wordsPerPage * page
  const end = wordsPerPage + start
  return wordList.value.slice(start, end)
}
function setWord(word: string) {
  emits('setWord', word)
  showMenu.value = false
}
</script>
