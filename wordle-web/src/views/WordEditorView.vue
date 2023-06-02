<template>
  <v-row v-for="word in words" :key="word.text" class="border my-3">
    <v-col cols="6" class="text-end">{{ word.text }}</v-col>
    <v-col cols="6" class="text-end"><v-checkbox v-bind="word.isCommon" /></v-col>
  </v-row>
</template>

<script setup lang="ts">
import Axios from 'axios'

import { ListWord } from '@/scripts/listWord'

const words = [
  new ListWord('alpha', true),
  new ListWord('bravo', false),
  new ListWord('charlie', true),
  new ListWord('delta', true)
]
/*axios.get('GetManyWords', {
  params: {
    Count: 45
  }
}).then((result) => {
  console.log(result.data)
  words = result.data as listWord[]
})*/
</script>
