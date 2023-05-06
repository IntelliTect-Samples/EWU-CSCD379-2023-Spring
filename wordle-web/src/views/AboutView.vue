<template>
  <v-card class="mx-auto" max-width="344" variant="outlined">
    <v-card-item>
      <div>
        <div class="text-h6 mb-1">About this wordle app!</div>
        <div class="text-caption pa-2">
          This the about page for the CSCD 379 .net class website. This app will allow you to test
          and play with the wordle app we will be building in class. The game will be based off of
          the wordle game found at
          <a href="https://www.nytimes.com/games/wordle/index.html"
            >nytimes.com/games/wordle/index.html</a
          >.
        </div>

        <div class="text-caption pa-2">
          The class is taught by Meg and Grant who have both done a fantastic job at already
          teaching us a lot about .net and web development. I am very excited to learn more about
          the frameworks used in web development and I hope you are too!
        </div>
      </div>
    </v-card-item>

    <v-card-actions>
      <v-btn variant="outlined" to="/"> Back to home </v-btn>
    </v-card-actions>
  </v-card>
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
