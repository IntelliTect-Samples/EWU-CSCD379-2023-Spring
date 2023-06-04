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
        <v-text-field label="Search" />
      </v-col>
      <v-col>
        <v-select :items="pages" label="Page" />
      </v-col>
    </v-row>
    <v-row class="border ma-3">
      <v-col class="text-h6">Word</v-col>
      <v-col class="text-h6">Is Common</v-col>
      <v-col>
        <v-btn color="green" :disabled="!motu" @click="addDialog = true">Add Word</v-btn>
      </v-col>
    </v-row>
    <v-row dense v-for="word in words" :key="word.text" class="border ma-3">
      <v-col>{{ word.text }}</v-col>
      <v-col><v-checkbox v-model="word.isCommon" /></v-col>
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

Axios.get('word/GetManyWords', {
  params: {
    Count: 45
  }
}).then((result) => {
  console.log(result.data)
  words.value = result.data as ListWord[]
})

const pages = Array<number>()

for (let i = 1; i <= 130; i++) {
  pages.push(i)
}

function deleteDialog(word: ListWord) {
  delWord.value = word.text
  delDialog.value = true
}

function deleteWord() {
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
    Axios.post('word', {
      Text: addWordText.value,
      IsCommon: addWordIsCommon.value
    })

    addWordText.value = ''
    addWordIsCommon.value = false
    addDialog.value = false
  }
}
</script>
