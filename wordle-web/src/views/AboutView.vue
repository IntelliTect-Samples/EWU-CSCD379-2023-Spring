<template>
  <v-sheet color="#263238" height="170px" class="pt-10 my-5">
    <v-card color="#546E7A" class="ma-5" elevation="5">
      <v-card-title>About</v-card-title>
      <v-card-text>
        These are a few words about meg. A few is two, right? But yeah, she's awesome.
      </v-card-text>
      <v-btn to="/wordle">Return Home</v-btn>
    </v-card>
  </v-sheet>
</template>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
