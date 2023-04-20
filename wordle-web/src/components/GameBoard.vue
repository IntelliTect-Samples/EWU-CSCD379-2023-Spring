<template>
    <v-row dense v-for="word in game.guesses" :key="word.text">
      <v-col cols="auto" v-for="letter in word.letters" :key="letter.char">
        <LetterButton :letter="letter"></LetterButton>
      </v-col>
    </v-row>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame';
import LetterButton from '@/components/LetterButton.vue';

defineProps({
    game: WordleGame
})

</script>