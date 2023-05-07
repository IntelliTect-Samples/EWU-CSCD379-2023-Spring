<template>
  <h1 align="center">Top 10 Wordle Scores</h1>
  <v-row class="justify-center" dense v-for="i in 10" :key="i">
    <v-col cols="auto">Score {{ i }}</v-col>
  </v-row>
</template>
