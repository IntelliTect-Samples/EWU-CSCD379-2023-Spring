<template>
  <v-card height="200px">
    <v-card-text>
      Delete Word:
      <v-text-field
        :messages="deleted ? [`Word: ${input} has been deleted`] : []"
        :errorMessages="deleteError ? ['Error deleting word'] : []"
        @input="editText($event.target.value)"
        variant="outlined"
        style="display: flex; flex-direction: column; flex-grow: 1; width: 500px"
      />
    </v-card-text>
    <v-card-actions>
      <v-spacer />
      <v-btn @click="deleteWord()">Delete Word</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
import axios from 'axios'
import { ref } from 'vue'

const input = ref<string>()
const deleted = ref<boolean>(false)
const deleteError = ref<boolean>(false)

const editText = (text: string) => {
  input.value = text
}

const deleteWord = () => {
  deleteError.value = false
  axios
    .delete(`/Word/Delete?word=${input.value}`)
    .then((res) => {
      deleted.value = true
    })
    .catch((err) => {
      deleteError.value = true
      console.log(err)
    })
}
</script>
