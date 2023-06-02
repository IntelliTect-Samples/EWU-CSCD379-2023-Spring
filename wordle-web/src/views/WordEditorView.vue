<template>
  <v-card class="w-75">
    <v-row class="border my-3">
      <v-col>Word</v-col>
      <v-col>Is Common</v-col>
    </v-row>
    <v-row v-for="word in words" :key="word.text" class="border my-3">
      <v-col >{{ word.text }}</v-col>
      <v-col><v-checkbox v-model="word.isCommon"/></v-col>
    </v-row>
  </v-card>
</template>

<script setup lang="ts">
import Axios from 'axios'

import { ListWord } from '@/scripts/listWord'
import { ref } from 'vue'

const words = ref([
  new ListWord('alpha', true),
  new ListWord('bravo', false),
  new ListWord('charlie', true),
  new ListWord('delta', true)
])

Axios.get('GetManyWords', {
  params: {
    Count: 45
  }
}).then((result) => {
  console.log(result.data)
  words.value = result.data as ListWord[]
})
</script>
