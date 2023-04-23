<template>
  <div dense v-for="(key, i) in keyboardLetters" :key="i" class="d-flex justify-center my-1">
      <v-btn v-if="i == 2" :width="68" :height="58" class="mr-1 text-overline" @click="enterClick" color="default">
        Enter
      </v-btn>
      <LetterButton 
      v-for="(letter, j) in key" 
      :key="j" 
      :letter="letter" 
      @click="letterClick(letter)"
      small
      class="mx-1"
      :class="textSize"
      :height="58"
      :width="btnWidth"/>
      <v-btn v-if="i == 2" :width="68" :height="58" class="ml-1" @click="deleteClick" color="default"><v-icon size="x-large" icon="mdi-backspace-outline"/></v-btn>
  </div>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import { Letter } from '@/scripts/letter'
import { computed } from 'vue'
import { useDisplay } from 'vuetify/lib/framework.mjs';

const display = useDisplay();

const btnWidth = computed(()=>{
  let baseWidth = 43;

  let scaledWidth = display.width.value / 13;
  return Math.min(baseWidth,scaledWidth)
});

const textSize = computed(()=>{
  return display.width.value < 560 ? 'text-h6' : 'text-h5'
})

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
  (event: 'enter') : void
  (event: 'delete') : void
}>()

function enterClick(){
  emits('enter');
}

function deleteClick(){
  emits('delete');
}

function letterClick(letter: Letter) {
  emits('letterClick', letter)
}
</script>
