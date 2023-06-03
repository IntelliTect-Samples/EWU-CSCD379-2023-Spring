<template>
  <h5 class="text-h5">Delete Word</h5>
  <v-card height="200px" variant="outlined" style="margin-bottom: 20px">
    <v-card-text>
      <v-text-field
        :messages="deleted ? [`Word has been deleted`] : []"
        :errorMessages="deleteError ? ['Error deleting word'] : []"
        @input="editText($event.target.value)"
        variant="outlined"
        style="display: flex; flex-direction: column; flex-grow: 1; max-width: 500px"
      />
    </v-card-text>
    <v-card-actions>
      <v-spacer />
      <v-btn @click="deleteWord()" :disabled="textInput === undefined">Delete Word</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
import axios from 'axios'
import { ref } from 'vue'

const deleted = ref<boolean>(false)
const deleteError = ref<boolean>(false)
const textInput = ref<string>()

const editText = (text: string) => {
  textInput.value = text
}

const deleteWord = () => {
  deleteError.value = false
  deleted.value = false
  axios
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
