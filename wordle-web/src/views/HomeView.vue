<template>
  <v-container class="fill-height" style="width: max-content;" >
    <v-row class="text-center" style="">
      <v-col >
        <h1>Wordle Mind Bender</h1>
        <v-col>
          <v-btn color="primary" to="/wordle">Start Game</v-btn>
        </v-col>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { defineComponent } from "vue";


export default defineComponent({
  components: {}});
</script>
