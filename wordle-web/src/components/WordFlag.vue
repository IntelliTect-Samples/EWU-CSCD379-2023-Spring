<template>
    <h5 class="text-h5">Change Common Word</h5>
    <v-card height="200px" variant="outlined" style="margin-bottom: 20px">
      <v-card-text>
        <v-text-field
          @input="editText($event.target.value)"
          placeholder="enter word to change frequency in word list..."
          :messages="swapped ? [`Word ${message} common`] : []"
          :errorMessages="swappedError ? [`Could not be ${message} common`] : []"
          maxlength="5"
          variant="outlined"
          style="display: flex; flex-direction: column; flex-grow: 1; max-width: 500px"
        />
      </v-card-text>
      <v-card-actions>
        <v-checkbox label="Common Word" @click="isCommon = !isCommon"></v-checkbox>
        <v-spacer />
        <v-btn
          @click="changeToCommon()"
          :disabled="!textInput || !isAlphabetical.test(textInput) || textInput.length !== 5"
          >Change</v-btn
        >
      </v-card-actions>
    </v-card>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  import Axios from 'axios'
  
  const isAlphabetical = /^[A-Za-z]+$/
  const swapped = ref<boolean>(false)
  const swappedError = ref<boolean>(false)
  const textInput = ref<string>()
  let isCommon = ref<boolean>(false)
  
  let message = ''
  
  const editText = (text: string) => {
    textInput.value = text
  }
  
  const changeToCommon = () => {
    console.log(textInput.value, isCommon.value)
    swappedError.value = false
    swapped.value = false
    Axios.post(`/Word?newWord=${textInput.value}&isCommon=${isCommon.value}`)
      .then((res) => {
        message = isCommon.value === true ? 'added to' : 'removed from'
        swapped.value = true
      })
      .catch((err) => {
        message = isCommon.value === true ? 'added to' : 'removed from'
        swappedError.value = true
        console.log(err)
      })
  }
  </script>