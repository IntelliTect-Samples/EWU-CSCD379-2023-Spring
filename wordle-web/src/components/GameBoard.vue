<template>
  <div class="pa-5">
  <v-row class="justify-center" dense v-for="(word, r) in game.guesses" :key="r">
    <v-col cols="auto" v-for="(letter, c) in word.letters" :key="`${r}-${c}`">
      <LetterButton class="key square key-gradient" :letter="letter" @click="letterClick(letter)" />
    </v-col>
  </v-row>
</div>
</template>

<script setup lang="ts">
import LetterButton from '@/components/LetterButton.vue'
import type { Letter } from '@/scripts/letter'
import type { WordleGame } from '@/scripts/wordleGame'

defineProps<{
  game: WordleGame
}>()

const emits = defineEmits<{
  (event: 'letterClick', value: Letter): void
}>()

function letterClick(letter: Letter) {
  emits('letterClick', letter)
  console.log(letter.status)
}

</script>
<style scoped>


.square {
  border-radius: 0 !important;
  border: 3px solid black;
  font-size: 1.5rem;
  height: 40px;
  width: 40px;
}
.key {
  width: 1rem;
  height: 3rem;
  font-size: 1rem;
  font-weight: bolder;
  font-family: Verdana, Geneva, Tahoma, sans-serif;
  border-radius: 5px;

}
.key-gradient {
  background-image: linear-gradient(to top, #6F6F6F6D, #B5B5B5A9);
}

</style>