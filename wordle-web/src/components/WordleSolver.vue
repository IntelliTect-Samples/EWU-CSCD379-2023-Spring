<template>
  <v-card>
    <v-card-title>
      <h3>Wordle Helper</h3>
      <div v-if="solver.getLetterUsages().length > 0">
        <v-btn
          size="small"
          class="mr-2"
          v-for="(letter, index) in solver.getLetterUsages().summary().correctLetters"
          :key="index"
          :color="letter == 'X' ? 'red' : letter !== '?' ? 'green' : 'gray'"
        >
          {{ letter.toUpperCase() }}
        </v-btn>
      </div>
    </v-card-title>
    <v-card-subtitle v-if="solver.getLetterUsages().summary().wrongLetters.length > 0">
      <span> Wrong: </span>
      {{ solver.getLetterUsages().summary().wrongLetters.sort().join(', ').toUpperCase() }}
    </v-card-subtitle>
    <v-list density="compact">
      <v-list-item
        v-for="item in solver.getLetterUsages().summary().misplacedLetters"
        :key="item.char"
      >
        <v-btn color="secondary" size="x-small" class="mr-2" style="font-size: 0.9em">
          {{ item.char.toUpperCase() }}
        </v-btn>
        <v-btn
          size="x-small"
          class="mx-1"
          v-for="(letter, index) in item.locations"
          :key="index"
          :color="letter == 'X' ? 'red' : letter !== '?' ? 'green' : 'gray'"
        >
          {{ letter.toUpperCase() }}
        </v-btn>
        {{ item.count }} {{ item.isMaxKnown ? '' : 'or more' }}
      </v-list-item>
    </v-list>
    <v-card-text>
      <div v-if="game.status === WordleGameStatus.Active">
        valid words: {{ solver.availableWords().length }}
        <span v-if="solver.availableWords().length < 50">
          <v-btn
            size="x-small"
            v-for="word in solver.availableWords()"
            :key="word"
            class="mr-1"
            @click="wordClick(word)"
          >
            {{ word }}
          </v-btn>
        </span>
      </div>
    </v-card-text>

    <v-card-actions v-if="game.status === WordleGameStatus.Active">
      Next Guess:
      <v-btn size="small" class="ml-1" @click="wordClick(solver.bestGuessOfValidWords())">
        {{ solver.bestGuessOfValidWords() }}
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
import { WordleGameStatus, type WordleGame } from '@/scripts/wordleGame'
import { WordleSolver } from '@/scripts/wordleSolver'
import { reactive } from 'vue'

const props = defineProps<{
  game: WordleGame
}>()

const emits = defineEmits<{
  (event: 'wordClick', value: string): void
}>()

function wordClick(letter: string) {
  emits('wordClick', letter)
}

const solver = reactive<WordleSolver>(new WordleSolver(props.game))
</script>
