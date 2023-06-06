<template>
  <h5 class="text-h5">Add Word</h5>
  <v-card height="200px" variant="outlined" style="margin-bottom: 20px">
    <v-card-text>
      <v-text-field
        @input="editText($event.target.value)"
        placeholder="add a word to the word list..."
        :messages="added ? [`Word added`] : []"
        :errorMessages="addedError ? ['Cannot add word'] : []"
        maxlength="5"
        variant="outlined"
        style="display: flex; flex-direction: column; flex-grow: 1; max-width: 400px"
      />
    </v-card-text>
    <v-card-actions>
      <v-checkbox label="Common Word" @click="isCommon = !isCommon"></v-checkbox>
      <v-spacer />
      <v-btn
        @click="addWord()"
        :disabled="!textInput || !isAlphabetical.test(textInput) || textInput.length !== 5"
        >Add Word</v-btn
      >
    </v-card-actions>
  </v-card>
  <h5 class="text-h5">Delete Word</h5>
  <v-card height="200px" variant="outlined" style="margin-bottom: 20px">
    <v-card-text>
      <v-text-field
        placeholder="enter word to delete from word list..."
        :messages="deleted ? [`Word has been deleted`] : []"
        :errorMessages="deleteError ? ['Error deleting word'] : []"
        maxlength="5"
        @input="editText($event.target.value)"
        variant="outlined"
        style="display: flex; flex-direction: column; flex-grow: 1; max-width: 500px"
      />
    </v-card-text>
    <v-card-actions>
      <v-spacer />
      <v-btn
        @click="deleteWord()"
        :disabled="!textInput || !isAlphabetical.test(textInput) || textInput.length !== 5"
        >Delete Word</v-btn
      >
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
import Axios from 'axios'
import { ref } from 'vue'

const isAlphabetical = /^[A-Za-z]+$/
const added = ref<boolean>(false)
const addedError = ref<boolean>(false)
const textInput = ref<string>()
let isCommon = false

const editText = (text: string) => {
  textInput.value = text
}

const addWord = () => {
  addedError.value = false
  added.value = false
  Axios.post(`/Word?newWord=${textInput.value}&isCommon=${isCommon}`)
    .then((res) => {
      added.value = true
    })
    .catch((err) => {
      addedError.value = true
      console.log(err)
    })
}

const deleted = ref<boolean>(false)
const deleteError = ref<boolean>(false)

const deleteWord = () => {
  deleteError.value = false
  deleted.value = false
  Axios
    .delete(`/Word/Delete?word=${textInput.value}`)
    .then((res) => {
      deleted.value = true
    })
    .catch((err) => {
      deleteError.value = true
      console.log(err)
    })
}
</script>
