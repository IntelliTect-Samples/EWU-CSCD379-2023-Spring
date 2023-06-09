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
})

watch(props.word, () => {
  setupWatches()
})

function setupWatches() {
  // When the word is scored, set the colors of the letters for delayed display
  watch(
    () => props.word.isScored,
    () => {
      //console.log('Is Scored Changed')
      props.word.letters.forEach((letter, index) => {
        setTimeout(() => {
          letters[index].char = letter.char
          letters[index].color = letter.color
          letters[index].status = letter.status
        }, index * 100)
      })
    }
  )

  // When the letters change make sure we update them
  watch(props.word.letters, () => {
    //console.log('List changed')
    props.word.letters.forEach((letter, index) => {
      letters[index].char = letter.char
    })
  })
}

setupWatches()
</script>
