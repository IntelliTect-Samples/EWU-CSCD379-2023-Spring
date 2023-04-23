<template>
  <v-container>
    <v-row justify="center" dense v-for="(key, i) in keyboardLetters" :key="i">
      <v-btn
        v-if="i == 2"
        class="mx-2 my-1"
        :size="size"
        elevation="10"
        color="grey-darken-4"
        theme="dark"
        @click="emits('checkGuess')"
        @keyup.enter="emits('checkGuess')"
      >
        Check
      </v-btn>
      <LetterButton
        :size="size"
        :class="size == 'small' || 'x-small' ? 'mx-1 my-1' : 'mx-2 my-1'"
        v-for="(letter, j) in key"
        :key="j"
        :letter="letter"
        @click="letterClick(letter)"
      />
      <v-btn
        v-if="i == 2"
                :size="size"
        class="mx-2 my-1"
        elevation="10"
        color="gray"
        theme="dark"
        @click="emits('backspace')"
        @keyup.backspace="emits('backspace')"
      >
        <v-icon icon="mdi-backspace" />
      </v-btn>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { Letter } from '@/scripts/letter'
import type { WordleGame } from '@/scripts/wordleGame'
import { withCtx } from 'vue'
import { watch } from 'vue'
import { computed, onMounted, onUnmounted } from 'vue'
import { useDisplay } from 'vuetify'

export interface Props {
  guessedLetters: Letter[]
  game: WordleGame
}
const props = defineProps<Props>()

const emits = defineEmits<{
  (event: 'letterClick', value: Letter): void
  (event: 'checkGuess'): void
  (event: 'backspace'): void
}>()

const { name, width } = useDisplay();

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

function letterClick(letter: Letter) {
  emits('letterClick', letter)
}

onMounted(() => {
  console.log("mount");
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

function keyPress(event: KeyboardEvent) {
  console.log("Press", props.guessedLetters.find((l) => l.char === event.key.toLowerCase()))
  if (event.key === 'Enter') {
    emits('checkGuess')
  } else if (event.key === 'Backspace') {
    emits('backspace')
  } else if (event.key.length === 1 && event.key !== ' ') {
    emits('letterClick', new Letter(event.key.toLowerCase()))
  }
}

const size = computed(() => {
  const size = {xs:'x-small',sm:'x-small',md:'default',lg:'default',xl:'default',xxl:'default'}[name.value];
  if(width.value < 515){
    return '';
  }
  return size;
})
</script>