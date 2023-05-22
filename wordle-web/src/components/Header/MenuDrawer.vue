<!--
---- Component to 'HeaderAppBar.vue', responsible for the menu drawer UI.
--->

<template>
  <v-navigation-drawer location="right" temporary>
    <v-card rounded="lg" class="mt-6" elevation="0">
      <v-card-title id="card-title" elevation="6"> <v-icon>mdi-menu</v-icon> Menu </v-card-title>

      <v-list density="compact">
        <br />

        <v-list-item>
          <v-btn to="/" elevation="24">Home</v-btn>
        </v-list-item>

        <v-list-item>
          <v-btn to="/about" elevation="24">About</v-btn>
        </v-list-item>

        <v-list-item>
          <v-btn to="/wordle" elevation="24">Play Game</v-btn>
        </v-list-item>

        <v-list-item>
          <v-btn to="/leaderboard" elevation="24">Leaderboard</v-btn>
        </v-list-item>

        <v-list-item>
          <v-btn to="/instructions" elevation="24">How To Play</v-btn>
        </v-list-item>
      </v-list>
    </v-card>
  </v-navigation-drawer>
</template>
