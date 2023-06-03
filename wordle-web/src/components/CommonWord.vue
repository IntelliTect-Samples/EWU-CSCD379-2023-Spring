<template>
  <v-card height="200px">
    <v-card-text>
      Change Common Word:
      <v-text-field
        @input="editText($event.target.value)"
        variant="outlined"
        style="display: flex; flex-direction: column; flex-grow: 1; max-width: 500px"
      />
    </v-card-text>
    <v-card-actions>
      <v-checkbox label="Common Word" @click="isCommon = !isCommon"></v-checkbox>
      <v-spacer />
      <v-btn @click="changeToCommon()" :disabled="!textInput">Change Common Word</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'

const textInput = ref<string>()
let isCommon = false

const editText = (text: string) => {
  textInput.value = text
}

const changeToCommon = () => {
  console.log(textInput.value, isCommon)
  const postArgs = {
    newWord: textInput.value,
    isCommon: isCommon
  }
  console.log(postArgs)
  Axios.post('/Word', postArgs)
}
</script>
