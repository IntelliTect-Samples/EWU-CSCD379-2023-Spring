<template>
  <v-dialog v-model="delDialog" persistent>
    <v-card class="w-50 v-flex">
      <v-row dense>
        <v-col> Do you want to delete {{ delWord }}? </v-col>
      </v-row>
      <v-row dense>
        <v-col>
          <v-btn color="red" @click="deleteWord">Delete</v-btn>
        </v-col>
        <v-col>
          <v-btn color="grey" @click="delDialog = false">Cancel</v-btn>
        </v-col>
      </v-row>
    </v-card>
  </v-dialog>
  <v-dialog v-model="addDialog" persistent>
    <v-card class="w-50">
      <v-text-field label="Word" v-model="addWordText" />
      <v-checkbox label="Is Common" v-bind="addWordIsCommon" />
      <v-btn color="green" @click="addWord">Add</v-btn>
      <v-btn color="grey" @click="addDialog = false">Cancel</v-btn>
    </v-card>
    <v-dialog v-model="duplicateDialog">
      <v-card class="w-25">
        <v-card-text>{{ addWordText }} already exists</v-card-text>
        <v-btn color="gray" @click="duplicateDialog = false">Ok</v-btn>
      </v-card>
    </v-dialog>
  </v-dialog>
  <v-card class="mx-8 my-auto">
    <v-row class="ma-3">
      <v-col>
        <v-text-field label="Search" v-model="searchPattern" @update:model-value="setViewList" />
      </v-col>
      <v-col>
        <v-select
          :items="pages"
          v-model="currentPage"
          label="Page"
          @update:model-value="setViewList"
        />
      </v-col>
    </v-row>
    <v-row class="border ma-3">
      <v-col class="text-h6">Word</v-col>
      <v-col class="text-h6">Is Common</v-col>
      <v-col>
        <v-btn color="green" :disabled="!motu" @click="addDialog = true">Add Word</v-btn>
      </v-col>
    </v-row>
    <v-row dense v-for="word in viewList" :key="word.text" class="border ma-3">
      <v-col>{{ word.text }}</v-col>
      <v-col><v-checkbox v-model="word.isCommon" @change="commonWord(word)" /></v-col>
      <v-col><v-btn color="red" :disabled="!motu" @click="deleteDialog(word)">Delete</v-btn></v-col>
    </v-row>
  </v-card>
</template>

<script setup lang="ts">
import Axios from 'axios'

import { ListWord } from '@/scripts/listWord'
import { ref } from 'vue'

const motu = ref(true)

const words = ref([
  new ListWord('alpha', true),
  new ListWord('bravo', false),
  new ListWord('charlie', true),
  new ListWord('delta', true)
])

const delWord = ref('')
const delDialog = ref(false)

const addWordText = ref('')
const addWordIsCommon = ref(false)
const addDialog = ref(false)
const duplicateDialog = ref(false)

const pages = ref(Array<number>())
const currentPage = ref(1)
const searchPattern = ref('')
const searchList = ref(Array<ListWord>())
const viewList = ref(Array<ListWord>())

Axios.get('word/GetAllWords').then((result) => {
  console.log(result.data)
  words.value = result.data as ListWord[]
})

setViewList()

function deleteDialog(word: ListWord) {
  delWord.value = word.text
  delDialog.value = true
}

function deleteWord() {
  Axios.post('word/DeleteWord', {
    Text: delWord.value
  })
  for (let i = 0; i < words.value.length; i++) {
    if (words.value[i].text == delWord.value) {
      words.value.splice(i, 1)
      break
    }
  }
  delDialog.value = false
}

function addWord() {
  var contains = false
  for (let i = 0; i < words.value.length; i++) {
    if (words.value[i].text == addWordText.value) {
      contains = true
      break
    }
  }
  if (contains) {
    duplicateDialog.value = true
  } else {
    Axios.post('word/AddWord', {
      Text: addWordText.value,
      IsCommon: addWordIsCommon.value
    })

    var added = false

    for (let i = 0; i < words.value.length; i++) {
      if (words.value[i].text > addWordText.value) {
        words.value.splice(i, 0, new ListWord(addWordText.value, addWordIsCommon.value))
        added = true
        break
      }
    }

    if (!added) {
      words.value.push(new ListWord(addWordText.value, addWordIsCommon.value))
    }

    addWordText.value = ''
    addWordIsCommon.value = false
    addDialog.value = false
  }
}

function commonWord(word: ListWord) {
  Axios.post('word/ChangeIsCommon', {
    Text: word.text
  })
}

function setViewList() {
  searchList.value = Array<ListWord>()
  for (let i = 0; i < words.value.length; i++) {
    if (words.value[i].text.includes(searchPattern.value)) {
      searchList.value.push(words.value[i])
    }
  }
  pages.value = Array<number>(Math.ceil(searchList.value.length / 100))
    .fill(0)
    .map((i) => i + 1)
  viewList.value = searchList.value.slice((currentPage.value - 1) * 100, currentPage.value * 100)
}
</script>
