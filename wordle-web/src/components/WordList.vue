<template>
  <div style="display: flex; justify-content: space-between">
    <h5 class="text-h5">Word List</h5>
    <v-menu>
      <template v-slot:activator="{ props }">
        <div>
          Words Per Page:
          <v-btn v-bind="props">{{ wordDisplayCount }}</v-btn>
        </div>
      </template>

      <v-list width="60px">
        <v-list-item @click="setDisplayCount(10, textInput, pageNumber)"> 10 </v-list-item>
        <v-list-item @click="setDisplayCount(25, textInput, pageNumber)"> 25 </v-list-item>
        <v-list-item @click="setDisplayCount(50, textInput, pageNumber)"> 50 </v-list-item>
        <v-list-item @click="setDisplayCount(100, textInput, pageNumber)"> 100 </v-list-item>
      </v-list>
    </v-menu>
  </div>
  <v-divider />
  <v-pagination
    @prev="setDisplayCount(wordDisplayCount, textInput, (pageNumber -= 1))"
    @next="setDisplayCount(wordDisplayCount, textInput, (pageNumber += 1))"
    :length="pageCount"
  />
  <v-card variant="outlined" style="margin-bottom: 20px">
    <v-text-field
      placeholder="search..."
      maxlength="5"
      @input="setDisplayCount(wordDisplayCount, $event.target.value, pageNumber)"
    />
    <v-list v-for="word in words" :key="word.id"
      ><v-list-item>{{ word.text }}</v-list-item></v-list
    >
  </v-card>
</template>

<script setup lang="ts">
import axios from 'axios'
import { ref } from 'vue'

const words = ref<Word[]>([])
const wordDisplayCount = ref<number>(10)
const textInput = ref<string>('')
const pageNumber = ref<number>(1)
const pageCount = ref<number>()

const setDisplayCount = (wordsPerPage: number, text: string, page: number) => {
  wordDisplayCount.value = wordsPerPage
  textInput.value = text
  pageNumber.value = page
  axios.get(
    `/Word/GetManyWords?count=${wordDisplayCount.value}&wordSegment=${textInput.value}&pageNumber=${pageNumber.value}`
  ).then((result) => {
    const data = result.data as WordDto
    words.value = data.words
    pageCount.value = data.pageCount
    console.log(result)
  })
}
setDisplayCount(wordDisplayCount.value, textInput.value, pageNumber.value)

type WordDto = {
  pageCount: number
  words: Word[]
}

type Word = {
  id?: number
  text: string
  isCommon: string
}
</script>
