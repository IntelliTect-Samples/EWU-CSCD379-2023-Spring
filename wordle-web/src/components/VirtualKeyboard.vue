<template>
  <div class="">
    
    <v-card color="secondary" class="justify-center pa-0">
      <v-card-item >
        <v-row class="justify-center">
          <v-col v-for="(key, index) in keyboardLetters[0]" :key="index" cols="auto" class="px-1">
            <LetterButton class="key key-gradient" :letter="key" @click="letterClick(key)" />
          </v-col>
        </v-row>
        <v-row class="justify-center">
          <v-col v-for="(key, index) in keyboardLetters[1]" :key="index" cols="auto" class="px-1">
            <LetterButton class="key key-gradient" :letter="key" @click="letterClick(key)" />
          </v-col>
        </v-row>
        <v-row class="justify-center">
          <v-col cols="auto" class="px-1">
            <v-btn size="small" class="key special-key key-gradient" @click=backspaceClick()>Delete</v-btn>
          </v-col>
          <v-col v-for="(key, index) in keyboardLetters[2]" :key="index" cols="auto" class="px-1">
            <LetterButton class="key key-gradient" :letter="key" @click="letterClick(key)" />
          </v-col>
          <v-col cols="auto" class="px-1">
            <v-btn size="small" class="key special-key key-gradient" @click=enterClick()>Enter</v-btn>
          </v-col>
        </v-row>
        <v-row>
          <v-divider></v-divider>
        </v-row>
      </v-card-item>
    </v-card>
  
  </div>
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
})


const emits = defineEmits<{
  (event: 'letterClick', value: Letter): void
  (event: 'backspaceClick'): void
  (event: 'enterClick'): void
}>()
function letterClick(letter: Letter) {
  emits('letterClick', letter)
}
function backspaceClick() {
  emits('backspaceClick')
}
function enterClick() {
  emits('enterClick')
}

</script>

<style scoped>
.key {
  width: 1rem;
  height: 2rem;
  font-size: 1rem;
  font-weight: bolder;
  font-family: Verdana, Geneva, Tahoma, sans-serif;
  border-radius: 5px; 
}

.key-gradient {
  background-image: linear-gradient(to top, #6F6F6F6D, #B5B5B5A9);
}
.special-key {
  border: 1px solid #ccc;
  width: 5rem;
  height: 2rem;
}
</style>
