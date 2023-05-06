<template>
  <v-row class="justify-center" dense v-for="(key, i) in keyboardLetters" :key="i">
    <v-col cols="auto" v-for="(letter, j) in key" :key="j">
      <v-btn
        v-if="letter.char === ' '"
        size="small"
        height="60"
        variant="outlined"
        :rounded="false"
        min-width="30"
        @click="backspace"
      >
        <v-icon>mdi-backspace</v-icon>
      </v-btn>
      <LetterButton
        v-if="letter.char !== ' ' && letter.char !== '_'"
        size="small"
        height="60"
        width="40"
        min-width="30"
        :letter="letter"
        @click="letterClick(letter)"
      />
      <v-btn
        v-if="letter.char === '_'"
        size="small"
        height="60"
        variant="outlined"
        :rounded="false"
        min-width="30"
        @click="checkGuess"
      >
        Enter
      </v-btn>
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
  console.log(props.guessedLetters.length)
  const keyboardLetters: Letter[][] = []

  const keyboardKeys = [
    ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'],
    ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'],
    ['_', 'z', 'x', 'c', 'v', 'b', 'n', 'm', ' ']
  ]

  for (let keyboardKey of keyboardKeys) {
    let keyboardRow: Letter[] = []

    for (let key of keyboardKey) {
      keyboardRow.push(props.guessedLetters.find((l) => l.char === key) ?? new Letter(key))
    }

    keyboardLetters.push(keyboardRow)
  }

  return keyboardLetters
})

const emits = defineEmits<{
  (event: 'letterClick', value: Letter): void
  (event: 'checkGuess'): void
  (event: 'backspace'): void
}>()

function letterClick(letter: Letter) {
  emits('letterClick', letter)
}

function checkGuess() {
  emits('checkGuess')
}

function backspace() {
  emits('backspace')
}
</script>
