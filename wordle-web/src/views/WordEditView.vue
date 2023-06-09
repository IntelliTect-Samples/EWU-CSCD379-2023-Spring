<template>
  <v-card class="ma-5" elevation="5">
    <v-card-title>Word Editor</v-card-title>
    <v-card-text>
      <v-table density="compact">
        <v-list density="compact">
          <v-list-subheader>Word</v-list-subheader>

          <v-card-item v-for="(item, i) in list" :key="i" :value="item" active-color="primary">
            <template v-slot:prepend>
              <v-icon color="red" @click="deleteWord(list[i].wordId)">mdi-delete</v-icon>
            </template>

            <div class="d-flex space-evenly-between flex-row" v-if="!signInService.isSignedIn">
              <h2 class="pr-15 pl-5 pt-5" v-text="item.text"></h2>
              <v-checkbox
                v-model="item.isCommon"
                @click="updateWord(item)"
                label="Is Word Common"
                disabled
              ></v-checkbox>
              <v-checkbox
                v-model="item.isUsed"
                @click="updateWord(item)"
                label="Is Word Used"
                disabled
              ></v-checkbox>
            </div>
            <div class="d-flex space-evenly-between flex-row" v-if="signInService.isSignedIn">
              <h2 class="pr-15 pl-5 pt-5" v-text="item.text"></h2>
              <v-checkbox
                v-model="item.isCommon"
                @click="updateWord(item)"
                label="Is Word Common"
              ></v-checkbox>
              <v-checkbox
                v-model="item.isUsed"
                @click="updateWord(item)"
                label="Is Word Used"
              ></v-checkbox>
            </div>
          </v-card-item>
        </v-list>
      </v-table>
      <v-row class="d-flex justify-center">
        <v-col cols="12" md="4">
          <v-text-field v-model="options.text" label="Search" />
        </v-col>
      </v-row>
      <v-row class="d-flex justify-center">
        <v-col cols="12" md="2">
          <v-btn @click="addWord" color="grey">
            <v-icon>mdi-plus</v-icon>
            Add new word
          </v-btn>
        </v-col>
      </v-row>
    </v-card-text>

    <v-card-item class="d-flex justify-center">
      <v-btn
        color="primary"
        class="ma-5"
        @click="options.pageNumber > 1 ? options.pageNumber-- : (options.pageNumber = 1)"
      >
        <v-icon>mdi-arrow-left</v-icon>
      </v-btn>
      <v-btn color="primary" class="ma-5" disabled>
        {{ options.pageNumber }}
      </v-btn>
      <v-btn color="primary" class="ma-5" @click="options.pageNumber++">
        <v-icon>mdi-arrow-right</v-icon>
      </v-btn>
    </v-card-item>
    <v-card-item>
      <v-card-title color="black"> Page Size - </v-card-title>
      <v-btn-toggle variant="outlined" v-model="options.pageSize">
        <v-btn icon="mdi-format-align-left" value="10">10</v-btn>
        <v-btn icon="mdi-format-align-center" value="20">20</v-btn>
        <v-btn icon="mdi-format-align-right" value="50">50</v-btn>
        <v-btn icon="mdi-format-align-justify" value="100">100</v-btn>
      </v-btn-toggle>
    </v-card-item>
  </v-card>
</template>

<script setup lang="ts">
import Axios from 'axios'
import { inject, reactive, ref } from 'vue'
// import { reactive } from 'vue'
import { WordListOptions, WordListItem } from '@/scripts/wordEdit'
import { watch } from 'vue'
import type { SignInService } from '@/scripts/signInService'
import { Services } from '@/scripts/services'

const errorInfo = ref('')
const options = reactive(new WordListOptions())
const list = reactive(new Array<WordListItem>())
const signInService = inject(Services.SignInService) as SignInService
var oldString = ''

watch(options, () => {
  refreshList()
})

refreshList()

function refreshList() {
  if (options.text != oldString) options.pageNumber = 1
  oldString = options.text
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
      errorInfo.value = error
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
      errorInfo.value = error
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
      errorInfo.value = error
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
      errorInfo.value = error
      console.log(error)
      alert('Could not add word. An error occurred.')
    })
}
</script>
