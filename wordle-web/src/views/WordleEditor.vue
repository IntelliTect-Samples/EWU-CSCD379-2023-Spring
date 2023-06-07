<template>
  <v-container class="d-flex justify-center align-center">
    <v-card style="width: 75%">
      <div class="bg-primary text-h5 pa-3 text-center">Wordle Editor</div>
      <v-text-field label="Wordle" type="text" v-model="value" @input="searchLive" maxlength="5">
      </v-text-field>
      <v-row>
        <v-col class="d-flex flex-left">
          <v-btn
            v-if="
              value.length == 5 &&
              words.length == 0 &&
              signInService.token.masterOfTheUniverse == 'True'
            "
            @click="addWord()"
            >Add Word: {{ value }}</v-btn
          >
          <v-btn v-else-if="signInService.token.masterOfTheUniverse == 'True'" @click="showError()">
            Add Word: {{ value }}
          </v-btn>
        </v-col>
        <v-col class="d-flex flex-right">
          <v-btn @click="changeCount()">Words Shown: {{ count }}</v-btn>
        </v-col>
        <v-col class="d-flex flex-right">
          <v-btn @click="prevPage()">Previous Page</v-btn>
        </v-col>
        <v-col class="d-flex flex-right">
          <div>Page: {{ page }}</div>
        </v-col>
        <v-col class="d-flex flex-right">
          <v-btn @click="nextPage()">Next Page</v-btn>
        </v-col>
      </v-row>
      <v-card-text>
        <div v-for="(word, index) in words" :key="index" class="border my-3">
          <v-card-text class="d-flex flex-column">
            <v-row dense>
              <v-col cols="3">{{ word.text }}</v-col>
              <v-col cols="3">Common Word:</v-col>
              <v-col v-if="!signInService.isSignedIn" cols="3">{{ word.isCommon }}</v-col>
              <v-col v-else col="3">
                <v-btn @click="setCommon(word.text, !word.isCommon)">{{ word.isCommon }}</v-btn>
              </v-col>
              <v-col v-if="signInService.token.masterOfTheUniverse == 'True'" cols="3">
                <v-btn @click="deleteWord(word.text)">Delete</v-btn>
              </v-col>
            </v-row>
          </v-card-text>
        </div>
      </v-card-text>
    </v-card>
  </v-container>
  <v-dialog :model-value="displayError" @update:model-value="close" persistent>
    <v-card>
      <v-card-title> Error: </v-card-title>
      <v-card-text>
        {{ err }}
      </v-card-text>
      <v-btn @click="close">OK</v-btn>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import Axios from 'axios'
import { inject, ref } from 'vue'
import type { WordDto } from '@/scripts/wordDto'
import { Services } from '@/scripts/services'
import type { SignInService } from '@/scripts/signInService'

const signInService = inject(Services.SignInService) as SignInService
const words = ref<WordDto[]>([])
const value = ref('')
const count = ref(10) //default return 10 words
const page = ref(1)
const err = ref('')
const displayError = ref(false)

search()

function close() {
  displayError.value = false
}

function showError() {
  if (value.value.length != 5) {
    err.value = `Word is ${value.value.length} letters long, it must be 5 letters long.`
  } else {
    err.value = `The word ${value.value} already exists, adding it will do nothing.`
  }
  displayError.value = true
}

async function search() {
  console.log(value.value)
  console.log(page.value)
  let apiPath = `word/paginatedWords?page=${page.value}&count=${count.value}&start=${value.value}`
  Axios.get(apiPath).then((result) => {
    console.log(result.data)
    if (result.data.length != 0) {
      words.value = result.data as WordDto[]
    } else {
      page.value = page.value - 1
    }
  })
}

async function searchLive() {
  page.value = 1
  search()
}

async function nextPage() {
  page.value = page.value + 1
  search()
}

async function prevPage() {
  page.value = page.value - 1
  if (page.value <= 0) {
    page.value = 1
  }
  search()
}

function changeCount() {
  if (count.value == 10) {
    count.value = 25
  } else if (count.value == 25) {
    count.value = 50
  } else if (count.value == 50) {
    count.value = 100
  } else {
    count.value = 10
  }

  page.value = 1

  search()
}

async function setCommon(wordText: string, wordCommon: boolean) {
  Axios.post('Word/SetIsCommon', {
    text: wordText,
    isCommon: wordCommon
  })
    .then(() => {
      let apiPath = `word/paginatedWords?start=${value.value}`
      Axios.get(apiPath).then((result) => {
        console.log(result.data)
        words.value = result.data as WordDto[]
      })
    })
    .catch((error) => {
      console.log(error)
    })
}

async function addWord() {
  console.log(value.value)
  Axios.post('Word/addWordFromBody', {
    text: value.value,
    isCommon: false
  })
    .then(() => {
      let apiPath = `word/paginatedWords?start=${value.value}`
      Axios.get(apiPath).then((result) => {
        console.log(result.data)
        words.value = result.data as WordDto[]
      })
    })
    .catch((error) => {
      console.log(error)
    })
}

async function deleteWord(wordText: string) {
  Axios.post('Word/DeleteWordFromBody', {
    text: wordText
  })
    .then(() => {
      let apiPath = `word/paginatedWords?start=${value.value}`
      Axios.get(apiPath).then((result) => {
        console.log(result.data)
        words.value = result.data as WordDto[]
      })
    })
    .catch((error) => {
      console.log(error)
    })
}
</script>
