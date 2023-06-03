<template>
  <v-card height="200px">
    <v-card-text>
      Change Common Word:
      <v-text-field
        @input="editText($event.target.value)"
        :messages="swapped ? [`Word ${message} common`] : []"
        :errorMessages="swapped ? [`Could not be ${message} common`] : []"
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

const swapped = ref<boolean>(false)
const swappedError = ref<boolean>(false)
const textInput = ref<string>()
let isCommon = false

const message = isCommon ? 'removed from' : 'added to'

const editText = (text: string) => {
  textInput.value = text
}

const changeToCommon = () => {
  swappedError.value = false
  swapped.value = false
  Axios.post(`/Word?newWord=${textInput.value}&isCommon=${isCommon}`)
    .then((res) => {
      swapped.value = true
    })
    .catch((err) => {
      swappedError.value = true
      console.log(err)
    })
}
</script>
