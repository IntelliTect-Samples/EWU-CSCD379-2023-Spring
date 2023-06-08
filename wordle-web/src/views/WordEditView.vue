<template>
  <v-card class="ma-5" elevation="5">
    <v-card-title>Word Editor</v-card-title>
    <v-card-text>
      <v-table density="compact">
        <v-list density="compact">
          <v-list-subheader>Word</v-list-subheader>

          <v-list-item
            v-for="(item, i) in list"
            :key="i"
            :value="item"
            active-color="primary"
            disabled
          >
            <template v-slot:prepend>
              <v-icon color="red" @click="deleteWord(list[i].wordId)">mdi-delete</v-icon>
            </template>

            <div class="d-flex space-evenly-between flex-row">
              <h2 class="pr-15 pl-5 pt-5" v-text="item.text"></h2>

              <v-checkbox v-model="item.isCommon" label="Is Word Common"></v-checkbox>
              <v-checkbox v-model="item.isUsed" label="Is Word Used"></v-checkbox>
            </div>
          </v-list-item>
        </v-list>
      </v-table>
      <v-row class="d-flex justify-center">
        <v-col cols="12" md="4">
          <v-text-field v-model="options.text" label="Search" />
        </v-col>
        <v-col cols="12" md="2">
          <v-btn @click="addWord" color="grey">
            <v-icon>mdi-plus</v-icon>
            Add new word
          </v-btn>
        </v-col>
      </v-row>
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

const options = reactive(new WordListOptions())
const list = reactive(new Array<WordListItem>())
const signInService = inject(Services.SignInService) as SignInService

watch(options, () => {
  refreshList()
})

refreshList()

function refreshList() {
  console.log(options.text)
  Axios.get('word/GetWordleList', {
    params: { 
      pageNumber: options.pageNumber,
      pageSize: options.pageSize,
      search: options.text
     }
  })
    .then((response) => {
      console.log(options)
      console.log(response)
      list.length = 0
      response.data.forEach((item: WordListItem) => {
        list.push(item)
      })
    })
    .catch((error) => {
      console.log(error)
    })
}

function deleteWord(id: number) {
  Axios.delete('word', {
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
        options.text = text
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
