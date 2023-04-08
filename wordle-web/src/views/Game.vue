<template>
  <!-- TODO: Export help menu and leaderboard from nav to componets! -->

  <Navbar></Navbar>

<v-card>
  <!-- Game Board -->
  <v-card-item>
    <v-container>
      <GameBoard></GameBoard>
    </v-container>
  </v-card-item>

  <!-- Keyboard -->
  <v-card-item>
    <v-container>
      <Keyboard></Keyboard>
    </v-container>
  </v-card-item>
</v-card>

</template>


<script lang="ts">
import GameBoard from "@/components/GameBoard.vue";
import Keyboard from "@/components/Keyboard.vue";
import Navbar from "@/components/Navbar.vue";

import { defineComponent } from "vue";

export default defineComponent({
  components: {
    GameBoard,
    Keyboard,
    Navbar
  },
});
</script>
