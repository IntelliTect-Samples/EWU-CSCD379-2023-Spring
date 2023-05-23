<template>
  <div style="display: flex; justify-content: center; align-items: center; height: 100vh">
    <v-card class="mx-auto" max-width="344" variant="outlined">
      <v-card-item>
        <div>
          <div class="text-overline mb-1">Wordle</div>
          <div class="text-h6 mb-1">How To Play</div>
          <div class="text-caption">
            Wordle is a fun, mindbending game in which a user has 6 attempts to determine what a 5
            letter word is. At each attempt, they are able to guess a five letter word. The letters
            they choose will change colors depending on if they are "Correct", "Not in the Word", or
            "Misplaced." If a letter is correctly placed, that means that it is in the secret word
            at that location and will glow green. If a letter is misplaced, it means that letter
            will show up in the final word, just not at that location, and will glow yellow. If the
            letter is incorrect, it means that letter is not in the final word and will glow red. To
            obtain a spot on a leaderboard, play as many games as you can minimizing your number of
            guesses and the amount of time it takes to figure out a word. Good luck!
          </div>
        </div>
      </v-card-item>

      <v-card-actions>
        <v-btn density="compact" variant="outlined" @click="goBack"> Back </v-btn>
      </v-card-actions>
    </v-card>
  </div>

  <div></div>
</template>

<script setup lang="ts">
import $router from '../router/index'

function goBack() {
  $router.go(-1)
}
</script>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
