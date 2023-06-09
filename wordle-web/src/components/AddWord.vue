<template>
    <h6 class="text-h6">Add Word</h6>
    <v-card height="200px" variant="tonal">
      <v-card-text>
        <v-text-field
         placeholder="Word to be added"
         maxlength="5"
         @input="editText($event.target.value)"
         :messages="added ? ['Added Word'] : []"
         :errorMessages="addingError ? ['Word cant be added'] : []"
         style="display: flex; flex-direction: column; max-width: 400px"
        />
      </v-card-text>
      <v-card-actions>
        <v-checkbox label="Common Word" @click="isCommon = !isCommon"></v-checkbox>
        <v-btn
          @click="addWord()"
          :disabled="!userInput || !Alphabet.test(userInput) || userInput.length !== 5"
          >Add Word</v-btn
        >
      </v-card-actions>
    </v-card>
  </template>
  
  <script setup lang="ts">
  import Axios from 'axios'
  import { ref } from 'vue'
  
  const Alphabet = /^[A-Za-z]+$/
  const added = ref<boolean>(false)
  const addingError = ref<boolean>(false)
  const userInput = ref<string>()
  let isCommon = false
  
  const editText = (text: string) => {
    userInput.value = text
  }
  
  const addWord = () => {
    addingError.value = false
    added.value = false
    Axios.post(`/Word?newWord=${userInput.value}&isCommon=${isCommon}`)
      .then((res) => {
        added.value = true
      })
      .catch((err) => {
        addingError.value = true
        console.log(err)
      })
  }
  </script>