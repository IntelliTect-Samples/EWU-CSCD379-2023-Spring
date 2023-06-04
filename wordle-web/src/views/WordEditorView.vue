<template>
  <v-table>
    <thead>
      <tr class="align-center">
        <th class="text-left" colspan="2">
          <v-text-field
            v-model="searchField"
            variant="outlined"
            label="Search"
            density="compact"
            hide-details
          ></v-text-field>
        </th>
        <th>
          <v-text-field
            v-model="newWord"
            variant="outlined"
            label="New Word"
            density="compact"
            hide-details
          ></v-text-field>
        </th>
        <th><v-btn @click="addWord(newWord)"> Add Word </v-btn></th>
      </tr>
    </thead>
    <thead>
      <tr class="align-center">
        <th class="text-center">Index</th>
        <th class="text-center">Word</th>
        <th class="text-center">Well Known?</th>
        <th class="text-center">Delete</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(word, index) in wordList" :key="word.wordId">
        <td class="text-center">{{ index + 1 }}</td>
        <td class="text-center">{{ word.text }}</td>
        <td class="align-center">
          <!-- Toggle disable vs not disabled once the policy is implemented. -->
          <v-checkbox
            v-model="word.isCommon"
            @click="changeFlag(word.wordId, word.isCommon)"
          ></v-checkbox>
        </td>
        <!-- Toggle the ability to change the flag and delete words once claims are implemented -->
        <td class="align-center">
          <v-btn variant="outlined" @click="deleteWord(word)"> Delete </v-btn>
        </td>
      </tr>
      <tr>
        <td class="text-left">Words Per Page</td>
        <td class="text-center" colspan="1">
          <v-select
            density="compact"
            hide-details
            variant="outlined"
            v-model="entriesPerPage"
            :items="[10, 25, 50, 100]"
          ></v-select>
        </td>
        <td><v-btn variant="outlined" @click="decreasePageNumber()"> Prev </v-btn></td>
        <td><v-btn variant="outlined" @click="increasePageNumber()"> Next </v-btn></td>
      </tr>
    </tbody>
  </v-table>
</template>

<!-- How can I make content centered? -->
<!-- 
 <td style="display: flex; justify-content: center; align-items: center">
          <v-btn variant="outlined"> Save </v-btn>
        </td> -->

<!-- class="d-flex  text-center align-center justify-center " -->

<script lang="ts" setup>
import Axios from 'axios'
import { ref } from 'vue'
import type { WordEntry } from '../scripts/wordEntry'
import { watch } from 'vue'

const wordList = ref<WordEntry[]>([])
let searchField = ref('')
let pageNumber = ref(1)
let entriesPerPage = ref(10)
let newWord = ref('')

watch(searchField, getWords)
watch(entriesPerPage, getWords)

function increasePageNumber() {
  pageNumber.value++
  getWords()
}

function decreasePageNumber() {
  if (pageNumber.value == 1) return
  pageNumber.value--
  getWords()
}

function deleteWord(word: WordEntry) {
  Axios.delete(`/Word/DeleteWord?wordId=${word.wordId}`).then(() => {
    getWords()
  })
}

getWords()

function getWords() {
  Axios.get(
    `/Word/SearchForWord?search=${searchField.value}&pageNumber=${pageNumber.value}&entriesPerPage=${entriesPerPage.value}`
  ).then((result) => {
    wordList.value = result.data as WordEntry[]
  })
}
// Need to guard this endpoint with a policy.
function addWord(word: string) {
  Axios.post(`/Word/?newWord=${word}&isCommon=true`).then(() => {
    newWord.value = ''
    getWords()
  })
}

function changeFlag(wordId: number, isCommon: boolean) {
  Axios.put(`/Word/ChangeFlag?wordId=${wordId}&isCommon=${!isCommon}`).then(() => {
    getWords()
  })
}
</script>
