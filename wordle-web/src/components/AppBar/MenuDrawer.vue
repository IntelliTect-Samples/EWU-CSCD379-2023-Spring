<template>
  <v-navigation-drawer location="right" temporary>
    <v-card rounded="lg" class="mt-6" elevation="0">
      <v-card-title id="card-title" elevation="6"> <v-icon>mdi-menu</v-icon> Menu </v-card-title>

      <v-list density="compact">
        <br />

        <v-list-item>
          <v-btn to="/">Home</v-btn>
        </v-list-item>

        <v-list-item>
          <v-btn to="/about">About</v-btn>
        </v-list-item>

        <v-list-item>
          <v-btn to="/wordle">Play Game</v-btn>
        </v-list-item>

        <v-list-item>
          <v-btn to="/leaderboard">Leaderboard</v-btn>
        </v-list-item>
      </v-list>
    </v-card>
  </v-navigation-drawer>
</template>
