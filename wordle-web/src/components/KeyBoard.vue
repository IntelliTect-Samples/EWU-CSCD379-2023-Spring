<template>
  <v-row class="justify-center" dense v-for="(row, i) in keyboardLetters" :key="i">
    <v-col cols="auto" v-for="(key, j) in row" :key="j">
      <LetterButton
        size="small"
        height="60"
        min-width="30"
        :letter="key"
        @click="letterClick(key)"
        :elevation="20"
      />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { Letter } from '@/scripts/letter'

const keyboardLetters = [
  ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'],
  ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'],
  ['z', 'x', 'c', 'v', 'b', 'n', 'm']
].map((array) => array.map((key) => new Letter(key)))

const emits = defineEmits<{
  (event: 'letterClick', value: Letter): void
}>()
function letterClick(letter: Letter) {
  emits('letterClick', letter)
}
</script>
