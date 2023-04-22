<template>
  <v-row class="justify-center" dense v-for="(key, i) in keyboardLetters" :key="i">
    <v-col cols="auto" v-for="(letter, j) in key" :key="j">
      <LetterButton
        :letter="letter"
        @click="letterClick(letter)"
        class="rounded"
        height="58px"
        min-width="43px"
      />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { Letter } from '@/scripts/letter'
import { computed } from 'vue'

const props = defineProps<{
  guessedLetters: Letter[]
}>()

const keyboardLetters = computed(() => {
  const keyboardLetters: Letter[][] = []
  const keyboardChars = [
    ['Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P'],
    ['A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L'],
    ['Z', 'X', 'C', 'V', 'B', 'N', 'M']
  ]

  for (let keyboardRowChars of keyboardChars) {
    let keyboardRow: Letter[] = []
    for (let key of keyboardRowChars) {
      keyboardRow.push(
        props.guessedLetters.find((letter) => letter.char === key) ?? new Letter(key)
      )
    }
    keyboardLetters.push(keyboardRow)
  }
  return keyboardLetters
})

const emits = defineEmits<{
  (event: 'letterClick', value: Letter): void
}>()

function letterClick(letter: Letter) {
  emits('letterClick', letter)
}
</script>
