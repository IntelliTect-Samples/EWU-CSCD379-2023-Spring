<template>
  <v-card color="indigo-darken-3" class="ma-5" elevation="5">
    <v-card-title>Word Editor</v-card-title>
    <v-card-text>
      <!-- provide inputs for search, page number, and page size -->
      <v-row>
        <v-col cols="12" md="4">
          <v-text-field v-model="options.search" label="Search" />
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field v-model="options.pageNumber" label="Page Number" type="number" />
        </v-col>
        <v-col cols="12" md="2">
          <v-select
            v-model="options.pageSize"
            label="Page Size"
            :items="[10, 20, 50, 100]"
          ></v-select>
        </v-col>
        <v-col cols="12" md="2">
          <v-btn @click="addWord" color="primary">
            <v-icon>mdi-plus</v-icon>
          </v-btn>
        </v-col>
      </v-row>

      <v-table density="compact">
        <thead>
          <tr>
            <th class="text-left">Word</th>
            <th class="text-left">Is Common</th>
            <th class="text-left">Is Used</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="word in list" :key="word.wordId">
            <td>{{ word.text }}</td>
            <td>
              <v-checkbox
                v-model="word.isCommon"
                v-if="signInService.isSignedIn"
                @change="updateWord(word)"
              />
              <v-icon v-if="!signInService.isSignedIn && word.isCommon" color="green"
                >mdi-check</v-icon
              >
              <v-icon v-if="!signInService.isSignedIn && !word.isCommon">mdi-alpha-x</v-icon>
            </td>
            <td>
              <v-checkbox
                v-model="word.isUsed"
                v-if="signInService.isSignedIn"
                @change="updateWord(word)"
              />
              <v-icon v-if="!signInService.isSignedIn && word.isUsed">mdi-check</v-icon>
              <v-icon v-if="!signInService.isSignedIn && !word.isUsed">mdi-alpha-x</v-icon>
            </td>
            <td>
              <v-icon color="red" @click="deleteWord(word.wordId)">mdi-delete</v-icon>
            </td>
          </tr>
        </tbody>
      </v-table>
    </v-card-text>
  </v-card>
</template>

<script setup lang="ts">
import Axios from 'axios'
import { inject, reactive } from 'vue'
import { WordListOptions, WordListItem } from '@/scripts/wordEdit'
import { watch } from 'vue'
import type { SignInService } from '@/scripts/signInService'
import { Services } from '@/scripts/services'
import type { Word } from '@/scripts/word'

const options = reactive(new WordListOptions())
const list = reactive(new Array<WordListItem>())
const signInService = inject(Services.SignInService) as SignInService

watch(options, () => {
  refreshList()
})

refreshList()

function refreshList() {
  Axios.get('word/GetWordList', {
    params: options
  })
    .then((response) => {
      list.length = 0
      response.data.list.forEach((item: WordListItem) => {
        list.push(item)
      })
      options.pageNumber = response.data.pageNumber
    })
    .catch((error) => {
      console.log(error)
    })
}

function deleteWord(id: number) {
  Axios.delete('word/DeleteWord', {
    params: {
      wordId: id
    }
  })
    .then((response) => {
      console.log(response.data)
      refreshList()
    })
    .catch((error) => {
      console.log(error)
    })
}

function updateWord(word: WordListItem) {
  console.log(word)
  Axios.post('word/UpdateWord', word)
    .then((response) => {
      console.log(response.data)
      refreshList()
    })
    .catch((error) => {
      console.log(error)
    })
}

function addWord() {
  // User types in the word in a dialog box
  const text = prompt('Enter the word to add')
  if (!text) {
    return
  }
  Axios.post('word/AddWordFromBody', {
    text: text,
    isCommon: true,
    isUsed: false
  })
    .then((response) => {
      console.log(response.data)
      if (response.data.wasSuccessful) {
        options.search = text
        options.pageNumber = 1
        refreshList()
      } else {
        alert('Could not add word. ' + response.data.message)
      }
    })
    .catch((error) => {
      console.log(error)
      alert('Could not add word. An error occurred.')
    })
}
</script>
