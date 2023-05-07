<!-- TODO: Update/fix about page layout... -->
<template>
  <v-sheet
    location="center"
    color="#9E9E9E"
    height="auto"
    max-width="800px"
    class="pt-10 my-5"
    rounded="lg"
  >
    <v-card color="cyan-darken-3" class="ma-5" elevation="5" rounded="xl">
      <v-card-title>About Us</v-card-title>
      <v-card-text>
        Hello! Our names are Nolan Posey and Hunter Thompson. This web app is a project we are
        working on for our CSCD 379 .NET Web Applications class at Eastern Washington University.
        The goal of this project is to emulate the game Wordle and to apply our own custom flair to
        the game in order to really make it our own. The name of our game is called "The Good Word"
        and we hope you enjoy playing it as much as we enjoying making it!
      </v-card-text>
    </v-card>

    <v-card color="cyan-darken-3" class="ma-5" elevation="5" rounded="xl">
      <v-card-title>Our Teacher Meg</v-card-title>
      <v-card-text>
        Meg has been teaching us CSharp and Vuetify since Winter quarter of the 2022-2023 school
        year. Her ability and passion to teach has helped us hone the necessary skills we as
        programmers need in order to be successful in our careers. Meg is over-worked and
        under-paid, but since we have no money... and no influence over her bosses Mark and Grant...
        we have decided to gift her with this cute image Nolan's cat Nala.
      </v-card-text>
    </v-card>

    <img alt="nala" src="@/assets/nala.jpg" width="350" height="400" />
    <br />
    <v-btn to="/wordle" location="center" style="top: 1rem">Return To Game</v-btn>
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

img {
  display: flex;
  margin-left: auto;
  margin-right: auto;
}
</style>
