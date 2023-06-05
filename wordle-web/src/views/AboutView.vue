<!-- <template>
  <v-sheet color="blue" height="170px" class="pt-10 my-5">
    <v-card color="indigo-darken-3" class="ma-5" elevation="5" rounded="xl">
      <v-card-title>About Wordle</v-card-title>
      <v-card-actions>
        <v-overlay :model-value="overlay" class="align-center justify-center" persistent>
          <v-progress-circular color="primary" indeterminate size="64" />
        </v-overlay>
        <v-btn @click="addWord()" variant="tonal">Test Add Word</v-btn>
      </v-card-actions>
    </v-card>
  </v-sheet>
</template>

<script setup lang="ts">
import Axios from 'axios'
import { ref } from 'vue'

let overlay = ref(false)

function addWord() {
  overlay.value = true
  Axios.post('word/AddWordFromBody', {
    text: 'tests',
    isCommon: true,
    isUsed: false
  })
    .then((response) => {
      overlay.value = false
      console.log(response.data)
    })
    .catch((error) => {
      console.log(error)
    })
}
</script> -->
<template>
  <h1>Word Editor</h1>
  <v-card>
    <UpdateWordList />
    <WordList />
    <WordFlag />
  </v-card>
</template>

<script setup lang="ts">
import UpdateWordList from '../components/UpdateWordList.vue'
import WordList from '../components/WordList.vue'
import WordFlag from '../components/WordFlag.vue'
</script>
