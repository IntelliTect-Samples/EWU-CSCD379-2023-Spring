<template>
  <v-row
    class="justify-center"
    v-for="(keyboardRow, rowIndex) in keyboardLetters"
    :key="rowIndex"
    dense
  >
    <v-col v-for="key in keyboardRow" :key="key.char" cols="auto">
      <LetterButton :letter="key" @click="letterClick(key)" />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import { Letter } from '@/scripts/letter'
import LetterButton from '@/components/LetterButton.vue'
import { computed } from 'vue'

const props = defineProps<{
  guessedLetters: Letter[]
}>()

const keyboardLetters = computed(() => {
  const keyboardLetters: Letter[][] = []

  const keyboardKeys = [
    ['Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P'],
    ['A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L'],
    ['Z', 'X', 'C', 'V', 'B', 'N', 'M']
  ]

  for (let keyboardKey of keyboardKeys) {
    let keyboardRow: Letter[] = []
    for (let key of keyboardKey) {
      //console.log(props.guessedLetters.find((l) => l.char.toLowerCase() === key.toLowerCase()))
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
  (e: 'letterClick', value: Letter): void
}>()

function letterClick(letter: Letter) {
  emit('letterClick', letter)
}
</script>
