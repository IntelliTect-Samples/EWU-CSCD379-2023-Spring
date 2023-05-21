<template>
  <v-row class="justify-center" dense>
    <v-col v-for="(letter, colIndex) in letters" :key="`col-${colIndex}`" cols="auto">
      <LetterResult :char="letter.char" :color="letter.color" :status="letter.status" />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import LetterResult from '@/components/LetterResult.vue'
import type { LetterStatus } from '@/scripts/letter'
import type { Word } from '@/scripts/word'
import { onMounted } from 'vue'
import { reactive, watch } from 'vue'

const props = defineProps<{
  word: Word
}>()

class DelayedLetter {
  constructor(public char: string, public color: string, public status: LetterStatus) {}
}

const letters = reactive(new Array<DelayedLetter>())

onMounted(() => {
  for (const letter of props.word.letters) {
    letters.push(new DelayedLetter(letter.char, letter.color, letter.status))
  }
  console.log('Mounted')
})

watch(
  () => props.word.isScored,
  () => {
    console.log('Watch')
    props.word.letters.forEach((letter, index) => {
      setTimeout(() => {
        letters[index].char = letter.char
        letters[index].color = letter.color
        letters[index].status = letter.status
      }, index * 100)
    })
  }
)
watch(props.word.letters, () => {
  console.log('List changed')
  props.word.letters.forEach((letter, index) => {
    letters[index].char = letter.char
  })
})
</script>
