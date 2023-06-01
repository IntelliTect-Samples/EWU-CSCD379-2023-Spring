<template>
  <v-card>
    <main>Dictionary</main>
  </v-card>
  <v-table>
    <thead>
      <v-text-field v-model="input" label="Label" @keyup="getInput()" variant="solo"></v-text-field>
      <!--change color of feild, add clear button-->
      <tr>
        <th class="text-left">ID</th>
        <th class="text-left">Word</th>
        <th class="text-left">IsCommon</th>
        <th class="text-left">Remove</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="word in Words.value" :key="word.WordId">
        <td>{{ word.WordId }}</td>
        <td>{{ word.Text }}</td>
        <td>{{ word.IsCommon }}</td>
        <td>Remove Button</td>
      </tr>
    </tbody>
  </v-table>
  <div class="text-center">
    <v-container>
      <v-row justify="center">
        <v-col cols="8">
          <v-container class="max-width">
            <v-pagination
              v-model="currentPage"
              class="my-4"
              :length="totalPages"
              @input="fetchWords"
            ></v-pagination>
          </v-container>
        </v-col>
      </v-row>
    </v-container>
  </div>

  <v-btn density="compact" @click="goBack">Back</v-btn>
</template>

<script setup lang="ts">
import Axios from 'axios'
import { ref, watch, reactive } from 'vue'
import $router from '../router/index'

const input = ref("")

// We have a word interface 
interface Word {
  WordId: string
  Text: string
  IsCommon: string
}


let overlay = true


let Words = reactive<{ value: Word[] }>({ value: [] })
let currentPage = ref(1)
let totalPages = ref(15)

function goBack() {
  // Your goBack logic here
  $router.go(-1)

}

function getInput(){
  fetchWords(1)

}

function fetchWords(page: number) {
  console.log('Fetch Words: ' + page)
  Axios.get(`/Word/GetPageOfWords?page=${page}&filter=${input.value}`)
    .then((response) => {
      Words.value = response.data.map((word: any) => ({
        WordId: word.WordId,
        Text: word.Text,
        IsCommon: word.IsCommon
      }))
      console.log(Words)

    })
    .catch((error) => {
      console.log(error)
    })
}
watch(currentPage, (newVal) => {
  fetchWords(newVal)
})

fetchWords(1)
</script>
