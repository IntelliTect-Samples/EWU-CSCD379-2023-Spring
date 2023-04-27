<template>
  <v-row class="justify-center" dense v-for="(key, i) in keyboardLetters" :key="i">
    <v-col cols="auto" dense v-for="(letter, j) in key" :key="j">
      <div v-if="letter.char != 'Backspace'">
        <LetterButton
          :style="{ filter: 'drop-shadow(2px 2px 1px #808080)' }"
          :letter="letter"
          @click="letterClick(letter)"
        />
      </div>
      <div v-else>
        <BackspaceButton
          :style="{ filter: 'drop-shadow(2px 2px 1px #808080)' }"
          :letter="letter"
          @click="letterClick(letter)"
        />
      </div>
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import BackspaceButton from '@/components/BackspaceButton.vue'
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
    ['Enter', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Backspace']
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
