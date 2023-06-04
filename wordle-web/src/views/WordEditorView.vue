<template>
  <v-table>
    <thead>
      <tr class="align-center">
        <!-- I want to bind the searchField to the v-text-field -->
        <th class="text-left" colspan="5">
          <v-text-field v-model="searchField" label="Search"></v-text-field>
        </th>
      </tr>
    </thead>
    <thead>
      <tr class="align-center">
        <th class="text-center">Index</th>
        <th class="text-center">Word</th>
        <th class="text-center">Well Known?</th>
        <th class="text-center">Save</th>
        <th class="text-center">Delete</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(word, index) in wordList" :key="word.wordId">
        <td class="text-center">{{ index + 1 }}</td>
        <td class="text-center">{{ word.text }}</td>
        <td class="align-center">
          <!-- Toggle disable vs not disabled once the policy is implemented. -->
          <v-checkbox :model-value="word.isCommon"></v-checkbox>
        </td>
        <!-- Toggle the ability to edit and delete words once claims are implemented -->
        <td><v-btn variant="outlined"> Save </v-btn></td>
        <td class="align-center"><v-btn variant="outlined"> Delete </v-btn></td>
      </tr>
      <tr>
        <td class="text-center" colspan="2">Words per page:</td>
        <td class="text-center" colspan="2">
          <v-select
            v-model="entriesPerPage"
            :items="[10, 25, 50, 100]"
            label="Words per page"
          ></v-select>
        </td>
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
let entriesPerPage = ref(10)
let searchField = ref('')

watch(entriesPerPage, getWords)
watch(searchField, getWords)

getWords()

function getWords() {
  Axios.get(
    `/Word/SearchForWord?search=${searchField.value}&entriesPerPage=${entriesPerPage.value}`
  ).then((result) => {
    wordList.value = result.data as WordEntry[]
  })
}
</script>
