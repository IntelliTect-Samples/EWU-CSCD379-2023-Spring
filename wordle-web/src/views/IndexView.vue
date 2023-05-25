<template>
  <v-card class="d-flex align-center justify-center" max-width="100%" min-height="100%">
    <div>
      <v-row>
        <v-card-title>Welcome to a Play on wordle!</v-card-title>
      </v-row>
      <v-row>
        <v-btn color="correct" class="button"
          ><RouterLink to="/game" style="color: white">Play Game</RouterLink></v-btn
        ><br />
      </v-row>
      <v-row>
        <v-btn color="misplaced" class="button"
          ><RouterLink to="/dailywordle" style="color: black">Daily Game</RouterLink></v-btn
        ><br />
      </v-row>
      <v-row>
        <v-btn color="wrong" class="button"
          ><RouterLink to="/instructions" style="color: white">How to Play</RouterLink></v-btn
        ><br />
      </v-row>
      <v-row>
        <v-btn color="grey" class="button"
          ><RouterLink to="/leaderboard" style="color: white">Leaderboard</RouterLink></v-btn
        ><br />
      </v-row>
    </div>
  </v-card>
</template>

<style scoped>
button {
  margin: 10px;
}
</style>
