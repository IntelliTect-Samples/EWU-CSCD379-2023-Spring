<template>
  <v-card class="mx-8 my-auto">
    <v-row class="ma-3">
      <v-col>
        <v-text-field label="Search" />
      </v-col>
    </v-row>
    <v-row class="border ma-3">
      <v-col class="text-h6">Word</v-col>
      <v-col class="text-h6">Is Common</v-col>
      <v-col>
        <v-btn color="green">Add Word</v-btn>
      </v-col>
    </v-row>
    <v-row dense v-for="word in words" :key="word.text" class="border ma-3">
      <v-col>{{ word.text }}</v-col>
      <v-col><v-checkbox v-model="word.isCommon" /></v-col>
      <v-col><v-btn color="red">Delete</v-btn></v-col>
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
