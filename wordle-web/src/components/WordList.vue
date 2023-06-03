<template>
  <h5 class="text-h5">Word List</h5>
  <v-card variant="outlined" style="margin-bottom: 20px">
    <v-list v-for="word in words" :key="word.id"
      ><v-list-item>{{ word.text }}</v-list-item></v-list
    >
  </v-card>
</template>

<script setup lang="ts">
import Axios from 'axios'
import { ref } from 'vue'

const words = ref<IWord[]>([])

export interface IWord {
  id?: number
  text: string
  isCommon: string
}

Axios.get('/Word/GetManyWords').then((result) => {
  words.value = result.data as IWord[]
})
</script>
