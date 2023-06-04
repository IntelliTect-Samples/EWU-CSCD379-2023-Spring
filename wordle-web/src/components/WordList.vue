<template>
  <h5 class="text-h5">Change Common Flag Of Word</h5>
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
  <div style="display: flex; justify-content: space-between">
    <h5 class="text-h5">Word List</h5>
    <v-menu>
      <template v-slot:activator="{ props }">
        <div>
          Words Per Page:
          <v-btn v-bind="props">{{ wordDisplayCount }}</v-btn>
        </div>
      </template>

      <v-list width="60px">
        <v-list-item @click="setDisplayCount(10, textInput)"> 10 </v-list-item>
        <v-list-item @click="setDisplayCount(25, textInput)"> 25 </v-list-item>
        <v-list-item @click="setDisplayCount(50, textInput)"> 50 </v-list-item>
        <v-list-item @click="setDisplayCount(100, textInput)"> 100 </v-list-item>
      </v-list>
    </v-menu>
  </div>
  <v-card variant="outlined" style="margin-bottom: 20px">
    <v-text-field
      placeholder="search..."
      maxlength="5"
      @input="setDisplayCount(wordDisplayCount, $event.target.value)"
    />
    <v-list v-for="word in words" :key="word.id"
      ><v-list-item>{{ word.text }}</v-list-item></v-list
    >
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
const words = ref<IWord[]>([])
const wordDisplayCount = ref<number>(10)

const setDisplayCount = (wordsPerPage: number, text: string) => {
  wordDisplayCount.value = wordsPerPage
  textInput.value = text
  Axios.get(
    `/Word/GetManyWords?count=${wordDisplayCount.value}&wordSegment=${textInput.value}`
  ).then((result) => {
    words.value = result.data as IWord[]
    console.log(result)
  })
}
setDisplayCount(wordDisplayCount.value, textInput.value)

interface IWord {
  id?: number
  text: string
  isCommon: string
}
</script>
