<template>
  <v-parallax height="650" src="https://source.unsplash.com/zeInZepl_Hw">
    <div class="d-flex flex-column fill-height justify-center align-center">
      <v-card class="pa-8">
        <v-row><h1>Word Editor</h1></v-row>

        <v-row>
          <v-col cols="12" lg="6">
            <v-text-field v-model="options.search" label="Search"></v-text-field>
          </v-col>
          <v-col cols="12" lg="3">
            <v-select
              v-model="options.pageSize"
              label="Page Size"
              :items="[10, 25, 50, 100]"
              variant="outlined"
            ></v-select
          ></v-col>
          <v-col cols="12" lg="3"
            ><v-text-field
              v-model="options.pageNumber"
              label="Page No."
              type="number"
            ></v-text-field
          ></v-col>
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
            <tr v-for="word in words" :key="word.wordId">
              <td>{{ word.text }}</td>
              <td>
                <v-checkbox v-model="word.isCommon" />
                <v-icon v-if="word.isCommon" color="green">mdi-check</v-icon>
                <v-icon v-if="!word.isCommon">mdi-alpha-x</v-icon>
              </td>
              <td>
                <v-icon color="red">mdi-delete</v-icon>
                <!-- @click="deleteWord(word.wordId)" -->
              </td>
            </tr>
          </tbody>
        </v-table>
      </v-card>
    </div>
  </v-parallax>
</template>
<script lang="ts">
import Axios from 'axios'
import { WordListOptions, WordListItem } from '@/scripts/wordEditorStuff'
import { reactive } from 'vue'

export default {
  data() {
    return {
      words: new Array<WordListItem>(),
      options: reactive(new WordListOptions())
    }
  },
  watch: {
    options() {
      console.log('something')
      Axios.get('word/GetWordList', {
        params: this.options
      })
        .then((response) => {
          this.words.length = 0
          response.data.list.forEach((item: WordListItem) => {
            this.words.push(item)
          })
          this.options.pageNumber = response.data.pageNumber
        })
        .catch((error) => {
          console.log(error)
        })
    }
  }
}
</script>
