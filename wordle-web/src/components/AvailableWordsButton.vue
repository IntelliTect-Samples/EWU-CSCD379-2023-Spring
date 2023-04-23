<template>
  <v-menu :close-on-content-click="false" v-model:model-value="showMenu">
    <template v-slot:activator="{ props }" >
    <v-btn 
    text
          v-bind="props"
          >
          Available Words: {{ availableWords.length }}
        </v-btn>
    </template>
      <v-card>
        <v-card-title>
          Available Words
        </v-card-title>
        <v-card-text >
          <v-list height="600px">
            <v-list-item v-for="word in doPagination" :key="word" class="text-h5" @click="addGuess(word)">
              {{ word }}
            </v-list-item>
          </v-list>
        </v-card-text>
          <v-card-actions>
            <v-btn text @click="currentPage--">Prev</v-btn>
            <v-spacer />
            <v-btn text @click="currentPage++">Next</v-btn>
          </v-card-actions>
      </v-card>
  </v-menu>
</template>

<script setup lang="ts">
import type { WordleGame } from '@/scripts/wordleGame';
import { WordsService } from '@/scripts/wordsService';
import { computed, ref } from 'vue'

export interface Props{
  wordleGame: WordleGame
}

const props = defineProps<Props>();

const emits = defineEmits<{
  (event: 'guessChanged', value: string): void
}>()

const showMenu = ref(false)

const wordsPerPage = 12
const currentPage = ref(0)

const availableWords = computed(()=>{
  return WordsService.validWords(props.wordleGame.guessedLetters);
})

const doPagination = computed(() => {
  var shownWords = getPageWords(currentPage.value)
  if(shownWords.length  == 0){
    currentPage.value = 0;
    shownWords = getPageWords(currentPage.value)
  }
  return shownWords
})

function getPageWords(page:number){
  const start = page * wordsPerPage
  const end = start + wordsPerPage
  return availableWords.value.slice(start, end)
}

function addGuess(word: string){
  props.wordleGame.guess.clear();
  for(let i = 0; i < word.length; i++){
    props.wordleGame.guess.push(word.charAt(i));
  }
  emits('guessChanged', word);
  showMenu.value = false;
}
</script>
