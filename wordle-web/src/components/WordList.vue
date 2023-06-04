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
        <v-list-item @click="setDisplayCount(10, textInput)"> 10 </v-list-item>
        <v-list-item @click="setDisplayCount(25, textInput)"> 25 </v-list-item>
        <v-list-item @click="setDisplayCount(50, textInput)"> 50 </v-list-item>
        <v-list-item @click="setDisplayCount(100, textInput)"> 100 </v-list-item>
      </v-list>
    </v-menu>
  </div>
  <v-card variant="outlined" style="margin-bottom: 20px">
    <v-text-field
      placeholder="search..."
      maxlength="5"
      @input="setDisplayCount(wordDisplayCount, $event.target.value)"
    />
    <v-list v-for="word in words" :key="word.id"
      ><v-list-item>{{ word.text }}</v-list-item></v-list
    >
  </v-card>
</template>

<script setup lang="ts">
import Axios from 'axios'
import { ref } from 'vue'

const words = ref<IWord[]>([])
const wordDisplayCount = ref<number>(10)
const textInput = ref<string>('')

const setDisplayCount = (wordsPerPage: number, text: string) => {
  wordDisplayCount.value = wordsPerPage
  textInput.value = text
  Axios.get(
    `/Word/GetManyWords?count=${wordDisplayCount.value}&wordSegment=${textInput.value}`
  ).then((result) => {
    words.value = result.data as IWord[]
    console.log(result)
  })
}
setDisplayCount(wordDisplayCount.value, textInput.value)

interface IWord {
  id?: number
  text: string
  isCommon: string
}
</script>
