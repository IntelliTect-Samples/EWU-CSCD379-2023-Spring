<template>
<<<<<<< HEAD
    <v-row dense v-for="(key, i) in keyboardLetters" :key="i">
        <v-col cols="auto" v-for="(char, j) in key" :key="j">
            <LetterButton :letter="new Letter(char)" @click="letterClick(new Letter(char))" />
        </v-col>
    </v-row>
</template>

<script setup lang="ts">
import { Letter } from '@/scripts/letter';
import { computed } from 'vue';

const props = defineProps<{
    guessedLetters: Letter[]
}>()

const keyboardLetters = computed(() => {
    const keyboardLetters: Letter[][] = [];

    const keyboardChars = [
        ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'],
        ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'],
        ['z', 'x', 'c', 'v', 'b', 'n', 'm'],
    ];
    
    for (const row of keyboardChars) {
        const letters: Letter[] = [];
        for (const key of row) {
            letters.push(new Letter(key));
            row.push(props.guessedLetters.find(l) => l.char === key ?? new Letter(key))
        }
        keyboardLetters.push(letters);
    }
    return keyboardLetters;
=======
  <v-row class="justify-center" dense v-for="(key, i) in keyboardLetters" :key="i">
    <v-col v-for="(letter, j) in key" :key="j">
      <LetterButton :letter="letter" @click="letterClick(letter)" />
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
>>>>>>> upstream/main
})

const emits = defineEmits<{
    (event: 'letterClick', value: Letter): void
}>()

function letterClick(letter: Letter) {
    emits('letterClick', letter)
}

</script>
