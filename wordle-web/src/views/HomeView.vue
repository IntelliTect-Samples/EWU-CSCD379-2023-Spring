<script setup lang="ts">
</script>

<template>
  <main>
    <v-card title="Home Page" subtitle="Welcome Home...">
      <v-card-text>The HomeView is just a card.</v-card-text>
      <v-card-actions>
        <v-spacer/>
        <RouterLink to="/game">
        <v-btn variant="elevated" color="primary">To Game</v-btn>
      </RouterLink>
      </v-card-actions>
    </v-card>
  </main>
</template>
