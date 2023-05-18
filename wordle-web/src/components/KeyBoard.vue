<template>
  <v-row class="justify-center" dense v-for="(key, i) in keyboardLetters" :key="i" :class="{ 'ml-1 px-0': display.xs }">
    <v-col cols="auto" v-if="i === keyboardLetters.length - 1">
      <v-btn
        @click="emitEnterClick"
        class="elevation-10"
        style="background-image: var(--btn-gradient)"
        :height="display.xs ? '30' : display.sm ? '40' : '50'"
        :size="display.xs ? 'x-small' : display.sm ? 'small' : undefined"
        :class="display.xs ? 'letter-small' : ''"
      >
        Check
      </v-btn>
    </v-col>
    <v-col cols="auto" v-for="(letter, j) in key" :key="j" :class="{ 'ml-1 px-0': display.xs }">
      <LetterButton :letter="letter" @click="emitLetterClick(letter)" />
    </v-col>
    <v-col cols="auto" v-if="i === keyboardLetters.length - 1" :class="{ 'ml-1 px-0': display.xs }">
      <v-btn
        @click="emitBackspaceClick"
        class="elevation-10"
        style="background-image: var(--btn-gradient)"
        :height="display.xs ? '30' : display.sm ? '40' : '50'"
        :size="display.xs ? 'x-small' : display.sm ? 'small' : undefined"
        :class="display.xs ? 'letter-small' : ''"
      >
        <v-icon color="white">mdi-backspace</v-icon>
      </v-btn>
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { Letter } from '@/scripts/letter'
import { Services } from '@/scripts/services'
import { computed, inject, reactive } from 'vue'
import { useDisplay } from 'vuetify/lib/framework.mjs'

const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>

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

<style scoped>
.v-btn {
  font-size: 12pt;
}

.letter-small {
  min-width: 20px;
  padding: 0;
}
</style>