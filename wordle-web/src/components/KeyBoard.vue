<template>
  <div style="margin-bottom: 50px">
    <v-row class="justify-center" dense v-for="(key, i) in keyboardLetters" :key="i">
      <v-btn 
        @click="keyPress('Enter')" v-if="i === 2"
        :size="xs? 50 : sm? 50 : md? 50 : lg? 60 : xl? 70 : 70"
        >
          enter
        </v-btn>
      <v-col cols="auto" v-for="(letter, j) in key" :key="j">
        <LetterButton 
          :letter="letter" 
          @click="letterClick(letter)" 
          :size="xs? 20 : sm? 35 : md? 50 : lg? 60 : xl? 70 : 70"
        />
      </v-col>
      <v-btn 
        @click="keyPress('Backspace')" v-if="i === 2"
        :size="xs? 50 : sm? 50 : md? 50 : lg? 60 : xl? 70 : 70"
      >
        back
      </v-btn>
    </v-row>
  </div>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { Letter } from '@/scripts/letter'
import { computed } from 'vue'

//-----------------reactivity
import { useDisplay } from 'vuetify'
const { xs, sm, md, lg, xl } = useDisplay()
//-----------------

const props = defineProps<{
  guessedLetters: Letter[]
}>()

const keyboardLetters = computed(() => {
  console.log(props.guessedLetters.length)
  const keyboardLetters: Letter[][] = []

  const keyboardKeys = [
    ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'],
    ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'],
    ['z', 'x', 'c', 'v', 'b', 'n', 'm']
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
  (event: 'keyPress', value: string): void
}>()

function letterClick(letter: Letter) {
  emits('letterClick', letter)
}

function keyPress(event: string) {
  emits('keyPress', event)
}
</script>
