<!--
---- The area of the screen where the user can enter their guesses.
---->

<template>
  <v-row
    class="justify-center"
    v-for="(keyboardRow, rowIndex) in keyboardLetters"
    :key="rowIndex"
    dense
  >
    <v-col cols="auto" v-if="rowIndex === keyboardLetters.length - 1">
      <v-btn
        @click="emitEnterClick"
        class="elevation-10"
        style="background-image: var(--btn-gradient)"
        :height="display.xs ? '30' : display.sm ? '40' : '50'"
        :size="display.xs ? 'x-small' : display.sm ? 'small' : 'large'"
        :class="display.xs ? 'letter-small' : ''"
      >
        Check
      </v-btn>
    </v-col>
    <v-col
      v-for="key in keyboardRow"
      :key="key.char"
      cols="auto"
      :class="{ 'ml-1 px-0': display.xs }"
    >
      <LetterButton :letter="key" @click="emitLetterClick(key)" />
    </v-col>
    <v-col
      cols="auto"
      v-if="rowIndex === keyboardLetters.length - 1"
      :class="{ 'ml-1 px-0': display.xs }"
    >
      <v-btn
        @click="emitBackspaceClick"
        class="elevation-10"
        style="background-image: var(--btn-gradient)"
        :height="display.xs ? '30' : display.sm ? '40' : '50'"
        :class="display.xs ? 'letter-small' : ''"
      >
        <v-icon color="white">mdi-backspace</v-icon>
      </v-btn>
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import { Letter } from '@/scripts/letter'
import LetterButton from '@/components/WordlePage/LetterButton.vue'
import { computed, inject, reactive } from 'vue'
import { useDisplay } from 'vuetify'
import { Services } from '@/scripts/services/services'

const props = defineProps<{
  guessedLetters: Letter[]
}>()

// Add this to make testing work because useDisplay() throws an error when testing
// Wrap useDisplay in a function so that it doesn't get called during testing.
const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>

const keyboardLetters = computed(() => {
  const keyboardLetters: Letter[][] = []
  const keyboardKeys = [
    ['Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P'],
    ['A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L'],
    ['Z', 'X', 'C', 'V', 'B', 'N', 'M', '?']
  ]

  // console.log(props.guessedLetters.length)

  for (let keyboardKey of keyboardKeys) {
    let keyboardRow: Letter[] = []
    for (let key of keyboardKey) {
      // console.log(props.guessedLetters.find((l) => l.char.toLowerCase() === key.toLowerCase()))
      keyboardRow.push(
        props.guessedLetters.find((l) => l.char.toLowerCase() === key.toLowerCase()) ??
          new Letter(key)
      )
    }
    keyboardLetters.push(keyboardRow)
  }

  return keyboardLetters
})

const emit = defineEmits<{
  (event: 'letterClick', value: Letter): void
  (event: 'enterClick'): void
  (event: 'backspaceClick'): void
}>()

function emitLetterClick(letter: Letter) {
  emit('letterClick', letter)
}

function emitEnterClick() {
  emit('enterClick')
}

function emitBackspaceClick() {
  emit('backspaceClick')
}
</script>
