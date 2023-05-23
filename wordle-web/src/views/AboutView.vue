<template>
  <div style="display: flex; justify-content: center; align-items: center; height: 100vh">
    <v-card class="mx-auto" max-width="344" variant="outlined">
      <v-card-item>
        <div>
          <div class="text-overline mb-1">Wordle</div>
          <div class="text-h6 mb-1">About</div>
          <div class="text-caption">
            This is website designed to allow you to play the hit game Wordle. Wordle is a game in
            which you are provided 6 guesses to figure out what a 5 letter word is. It will tell you
            which letters were misplaced, which letters are incorrect and which letters are
            correctly placeed. Wordle is a great game, but not as great as Meg is!
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
