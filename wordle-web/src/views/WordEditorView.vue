<template>
  <v-card>
    <v-card-item>
      <v-table>
        <thead>
          <tr>
            <th class="text-center">Word</th>
            <th class="text-center">Is Common</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="word in words" :key="word.wordID">
            <td class="text-center">{{ word.text }}</td>
            <td class="text-center">{{ word.isCommon ? 'Yes' : 'No' }}</td>
            <td><v-btn>Add</v-btn></td>
            <td><v-btn>Remove</v-btn></td>
            <td><v-btn>Edit Is Common</v-btn></td>
          </tr>
        </tbody>
      </v-table>
    </v-card-item>

    <v-card-item>
      <v-text-field v-model="searchWord" label="Search" @update:model-value="updateSearch()" />
    </v-card-item>

    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn @click="previousPage()" variant="outlined">Prev</v-btn>
      <v-btn @click="nextPage()" variant="outlined">Next</v-btn>
      <v-spacer></v-spacer>
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
import type { WordHelper } from '@/scripts/wordHelper'
import Axios from 'axios'
import { ref } from 'vue'

const words = ref<WordHelper[]>([])
let page = 0
let searchWord = ref<string>('')

Axios.get('word/wordlist?pageNumber=0').then((response) => {
  words.value = response.data as WordHelper[]
})

function nextPage() {
  page++
  if (searchWord.value === '') {
    Axios.get('word/wordlist?pageNumber=' + page).then((response) => {
      words.value = response.data as WordHelper[]
    })
  } else {
    Axios.get('word/wordlist?pageNumber=' + page + '&searchWord=' + searchWord.value).then(
      (response) => {
        words.value = response.data as WordHelper[]
      }
    )
  }
}

function previousPage() {
  if (page > 0) {
    page--
    if (searchWord.value === '') {
      Axios.get('word/wordlist?pageNumber=' + page).then((response) => {
        words.value = response.data as WordHelper[]
      })
    } else {
      Axios.get('word/wordlist?pageNumber=' + page + '&searchWord=' + searchWord.value).then(
        (response) => {
          words.value = response.data as WordHelper[]
        }
      )
    }
  }
}

function updateSearch() {
  console.log(searchWord.value)
  page = 0
  Axios.get('word/wordlist?pageNumber=' + page + '&searchWord=' + searchWord.value).then(
    (response) => {
      words.value = response.data as WordHelper[]
    }
  )
}
</script>
