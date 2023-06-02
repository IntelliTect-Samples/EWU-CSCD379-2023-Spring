<template>
  <v-row v-for="word in words" :key="word" class="border my-3">
    <v-col cols="6" class="text-end">{{ word.text }}</v-col>
    <v-col cols="6" class="text-end"><v-checkbox v-bind="word.isCommon" /></v-col>
  </v-row>
</template>

<script>
import listWord from '@/scripts/wordlist'

words: listWord[] = [new listWord("alpha", true), new listWord("bravo", false), new listWord('charlie', true), new listWord('delta', true)];
/*axios.get('GetManyWords', {
  params: {
    Count: 45
  }
}).then((result) => {
  console.log(result.data)
  words = result.data as listWord[]
})*/
</script>
