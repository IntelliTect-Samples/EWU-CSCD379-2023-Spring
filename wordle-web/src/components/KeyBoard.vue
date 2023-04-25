<template>
  <v-row class="justify-center" dense v-for="(key, i) in keyboardLetters" :key="i">
    <v-col cols="auto" v-for="(char, j) in key" :key="j">
      <LetterButton
        size="small"
        height="60"
        min-width="30"
        :letter="new Letter(char)"
        @click="letterClick(new Letter(char))"
        :elevation="20"
      />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { Letter } from '@/scripts/letter'

const keyboardLetters: [string[], string[], string[]] = [
  ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'],
  ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'],
  ['z', 'x', 'c', 'v', 'b', 'n', 'm']
]
const emits = defineEmits<{
  (event: 'letterClick', value: Letter): void
}>()
function letterClick(letter: Letter) {
  emits('letterClick', letter)
}
</script>
