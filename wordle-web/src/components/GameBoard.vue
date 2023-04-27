<template>

  <v-row class="justify-center" dense v-for="(word, r) in game.guesses" :key="r">
    <v-col cols="auto" v-for="(letter, c) in word.letters" :key="`${r}-${c}`">
      <LetterButton  :letter="letter" @click="letterClick(letter)" 

      
      />
    </v-col>
  </v-row>
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
  makeSound()
}
function makeSound(){
    const sound = new Audio('../src/assets/sound.mp3')
    sound.currentTime=0;
    sound.play()
    setInterval(function(){
    if(sound.currentTime> 0.5){
      sound.pause();
    }
    },1);
  }
</script>
