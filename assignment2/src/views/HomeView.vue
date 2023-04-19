<script setup lang="ts">
import Para from '../components/MainPara.vue'
</script>

<template>
    <Para title="Welcome!" body="Hello and welcome to our bootleg Wordle game!! Unlike the much more successful counterpart, here you can easily play as many games as you want! No more being limited to one a day." />
    <hr>
    <Para title="How to Play" body="Enter a 5-letter word. Letters will change color depending on if it's a match to the desired word. _____ means it's the right letter in the appropriate place, _____ means it's the right letter for the word but in the wrong place, and _____ means it's not present in the word at all." />
    <hr>
    <v-btn to="/game" prepend-icon="mdi-chevron-left" append-icon="mdi-chevron-right" block size="x-large" elevation="12" id="game" variant="outlined"> Start Game </v-btn>
</template>

<style scoped>
hr {
  border: 2px dashed grey;
  margin: 3rem 0rem;
}
#game {
  color: orangered;
}
</style>
