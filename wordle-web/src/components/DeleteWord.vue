<template>
  <v-card height="200px">
    <v-card-text>
      Delete Word:
      <v-text-field
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
import { ref } from 'vue'

const textInput = ref<string>()

const editText = (text: string) => {
  textInput.value = text
}

const deleteWord = () => {
  console.log(textInput.value)
}
</script>
