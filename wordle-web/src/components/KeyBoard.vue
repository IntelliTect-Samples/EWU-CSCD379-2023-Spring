<template>
  <v-row rows="auto" class="justify-center" dense v-for="(key, i) in keyboardLetters" :key="i">
    <v-col cols="auto" v-if="i === keyboardLetters.length - 1">
      <v-btn
        @click="emitEnterClick"
        class="elevation-10"
        style="background-image: var(--btn-gradient)"
      >
        Check
      </v-btn>
    </v-col>
    <v-col cols="auto" v-for="(letter, j) in key" :key="j">
      <LetterButton :letter="letter" @click="emitLetterClick(letter)" />
    </v-col>
    <v-col cols="auto" v-if="i === keyboardLetters.length - 1">
      <v-btn
        @click="emitBackspaceClick"
        class="elevation-10"
        style="background-image: var(--btn-gradient)"
      >
        <v-icon color="white">mdi-backspace</v-icon>
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
  const keyboardLetters: Letter[][] = []
  const keyboardKeys = [
    ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'],
    ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'],
    ['z', 'x', 'c', 'v', 'b', 'n', 'm']
  ]

  console.log(props.guessedLetters.length)

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
  (event: 'enterClick'): void
  (event: 'backspaceClick'): void
}>()

function emitLetterClick(letter: Letter) {
  emits('letterClick', letter)
}

function emitEnterClick() {
  emits('enterClick')
}

function emitBackspaceClick() {
  emits('backspaceClick')
}
</script>
