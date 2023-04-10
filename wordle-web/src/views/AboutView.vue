<template>
  <div class="about">
    <v-card class="mx-auto" max-width="400">
      <v-card-title>Word Scramble game</v-card-title>
      <v-card-text>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce tincidunt odio eget tellus euismod efficitur.</p>
      </v-card-text>
      <v-card-actions>
        <v-btn @click="$router.push('/')">Go back to Home</v-btn>
      </v-card-actions>
    </v-card>
  </div>
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
