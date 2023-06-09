<template>
    <h5 class="text-h5">Change Common Word</h5>
    <v-card height="200px" variant="tonal">
      <v-card-text>
        <v-text-field
          placeholder="Word frequency to be changed"
          maxlength="5"
          @input="editText($event.target.value)"
          :messages="swap ? [`Word ${message} common words`] : []"
          :errorMessages="swappingError ? ['Word not found'] : []"
          style="display: flex; flex-direction: column; max-width: 400px"
        />
      </v-card-text>
      <v-card-actions>
        <v-checkbox label="Common Word" @click="isCommon = !isCommon"></v-checkbox>
        <v-btn
          @click="changeToCommon()"
          :disabled="!userInput || !Alphabetical.test(userInput) || userInput.length !== 5"
          >Change</v-btn
        >
      </v-card-actions>
    </v-card>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  import axios from 'axios'
  
  const Alphabetical = /^[A-Za-z]+$/
  const swap = ref<boolean>(false)
  const swappingError = ref<boolean>(false)
  const userInput = ref<string>()
  let isCommon = ref<boolean>(false)
  
  let message = ''
  
  const editText = (text: string) => {
    userInput.value = text
  }
  
  const changeToCommon = () => {
    console.log(userInput.value, isCommon.value)
    swappingError.value = false
    swap.value = false
    axios.post(`/Word?newWord=${userInput.value}&isCommon=${isCommon.value}`)
      .then((res) => {
        message = isCommon.value === true ? 'added to' : 'removed from'
        swap.value = true
      })
      .catch((err) => {
        message = isCommon.value === true ? 'added to' : 'removed from'
        swap.value = true
        console.log(err)
      })
  }
  </script>