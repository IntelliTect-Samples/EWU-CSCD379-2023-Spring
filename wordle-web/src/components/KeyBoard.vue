<template>
  <v-container>
    <v-row class="justify-center" dense v-for="(key, i) in keyboardLetters" :key="i">
      <v-col cols="auto" v-for="(letter, j) in key" :key="j">
        <LetterButton
          height="50px"
          width="40px"
          min-height="1px"
          min-width="1px"
          :elevation="10"
          :letter="letter"
          @click="letterClick(letter)"
        />
      </v-col>
    </v-row>
  </v-container>
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
    ['enter', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'del']
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
}>()

function letterClick(letter: Letter) {
  emits('letterClick', letter)
}
</script>
