<template>
  <h6 class="text-h6">Delete Words</h6>
  <v-card height="150px" variant="tonal">
    <v-card-text>
      <v-text-field
        placeholder="Word to be deleted"
        maxlength="5"
        @input="textEdit($event.target.value)"
        :messages="deleted ? ['Word deleted'] : []"
        :errorMessages="deletetionError ? ['Word not found'] : []"
        style="display: flex; flex-direction: column; max-width: 400px"
      />
    </v-card-text>
    <v-card-actions>
      <v-btn
        @click="deleteWord()"
        :disabled="!userInput || !Alphabet.test(userInput) || userInput.length !== 5"
        >Delete Word</v-btn
      >
    </v-card-actions>
  </v-card>
</template>
<script setup lang="ts">
import axios from 'axios'
import { ref } from 'vue'

const Alphabet = /^[A-Za-z]+$/
const deleted = ref<boolean>(false)
const deletetionError = ref<boolean>(false)
const userInput = ref<string>()

const textEdit = (text: string) => {
  userInput.value = text
}
const deleteWord = () => {
  deletetionError.value = false
  deleted.value = false
  axios
    .delete(`/Word/Delete?word=${userInput.value}`)
    .then((res) => {
      deleted.value = true
    })
    .catch((err) => {
      deletetionError.value = true
      console.log(err)
    })
}
</script>
