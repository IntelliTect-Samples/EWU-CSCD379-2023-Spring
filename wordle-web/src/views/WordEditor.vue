<template>
  <v-sheet>
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
            <tr v-for="item in list" :key="item.wordId">
              <td>{{ item.text }}</td>
              <td>{{ item.isCommon }}</td>
              <td>{{ item.isUsed }}</td>
              <td>
                <v-btn @click="deleteWord(item.wordId)" icon>
                  <v-icon color="red">mdi-delete</v-icon>
                </v-btn>
              </td>
            </tr>
          </tbody>
        </v-table>
      </v-card-text>
      <v-card-actions>
        <!-- <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
          <v-progress-circular color="primary" indeterminate size="64" />
        </v-overlay> -->
        <!-- <v-btn @click="addWord()" variant="tonal">Test Add Word</v-btn> -->
      </v-card-actions>
    </v-card>
  </v-sheet>
</template>

<script setup lang="ts">
import Axios from 'axios'
import { reactive } from 'vue'
import { WordListOptions, WordListItem } from '@/scripts/wordEdit'
import { watch } from 'vue'

const options = reactive(new WordListOptions())
const list = reactive(new Array<WordListItem>())

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
      response.data.forEach((item: WordListItem) => {
        list.push(item)
      })
    })
    .catch((error) => {
      console.log(error)
    })
}

function deleteWord(id: number) {
  Axios.delete('word/DeleteWord', {
    params: {
      id: id
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

function addWord() {
  Axios.post('word/AddWordFromBody', {
    text: 'tests',
    isCommon: true,
    isUsed: false
  })
    .then((response) => {
      console.log(response.data)
      refreshList()
    })
    .catch((error) => {
      console.log(error)
    })
}
</script>
