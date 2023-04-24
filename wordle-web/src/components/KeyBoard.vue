<template>
  <v-row class="justify-center" dense v-for="(key, i) in keyboardLetters" :key="i">
    <v-col cols="auto" v-for="(letter, j) in key" :key="j">
      <LetterButton
        v-if="letter.char.length === 1"
        :letter="letter"
        @click="letterClick(letter)"
        class="rounded"
        height="58px"
        min-width="43px"
        :elevation="10"
      />
      <LetterButton
        v-if="letter.char === 'ENTER'"
        :letter="letter"
        @click="enterClick()"
        class="rounded"
        height="58px"
        min-width="65px"
        :elevation="10"
      />
      <LetterButton
        v-if="letter.char === '<='"
        :letter="letter"
        @click="backspaceClick()"
        class="rounded"
        height="58px"
        max-width="65px"
        :elevation="10"
      />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { Letter } from '@/scripts/letter'
import type { WordleGame } from '@/scripts/wordleGame'
import { computed } from 'vue'

const props = defineProps<{
  guessedLetters: Letter[]
  game: WordleGame
}>()

const keyboardLetters = computed(() => {
  const keyboardLetters: Letter[][] = []
  const keyboardChars = [
    ['Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P'],
    ['A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L'],
    ['ENTER', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '<=']
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
  (event: 'enterClick'): void
}>()

function letterClick(letter: Letter) {
  emits('letterClick', letter)
  const audio = new Audio()
  audio.src = 'src/assets/click2.wav'
  audio.play()
}
function enterClick() {
  props.game.submitGuess()
  const audio = new Audio()
  audio.src = 'src/assets/click2.wav'
  audio.play()
}
function backspaceClick() {
  // eslint-disable-next-line vue/no-mutating-props
  props.game.currentGuess.pop()
  const audio = new Audio()
  audio.src = 'src/assets/click2.wav'
  audio.play()
}
</script>
