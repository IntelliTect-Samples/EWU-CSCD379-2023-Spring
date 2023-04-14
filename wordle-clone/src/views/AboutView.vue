<template>
  <v-card>
        <v-card-title>
            About Page Example
        </v-card-title>
        <v-card-item>
            <div class="text-caption"> Just an about page, not much about it. </div>
        </v-card-item>
        <v-card-actions>
            <v-btn variant="outlined" to="/">
                Home
            </v-btn>
            <v-btn variant="outlined" to="/game">
                Game
            </v-btn>
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
