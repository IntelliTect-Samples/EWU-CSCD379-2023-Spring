<script lang="ts">
  export default {
    data () {
      return {
        dialog: false,
      }
    },
  }
    
  import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <nav>
    <v-btn prepend-icon="mdi-castle" variant="plain" to="/"> Wordle </v-btn>
    
    <v-btn icon="mdi-menu" variant="plain" to="/game" class="right"></v-btn>
    
    <v-dialog
      v-model="dialog"
      width="auto"
    >
      <template v-slot:activator="{ props }">
        <v-btn icon="mdi-cog" variant="plain" class="right" v-bind="props"></v-btn>
      </template>

      <v-card id="sett">
        <v-card-text>
          <h1>Settings</h1>
          <hr style="margin-bottom: 1rem;">
          <h2>Theme/Appearance</h2>
          <p>Dark/Light Mode</p>
          <p>Color Scheme</p>
          <br>
          <h2>Gameplay</h2>
          <p>No. of Guesses</p>
        </v-card-text>
        <v-card-actions>
          <v-btn block @click="dialog = false">Close Dialog</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </nav>

  <RouterView />
</template>


<style scoped>
  button {
    color: orangered;
  }
  #sett {
    background-color: rgb(50, 50, 50);
    border: 1px solid black;
    color: antiquewhite;
  }
    nav {
      position: fixed;
      top: 0;
      left: 9%;
      width: 82%;
      border-bottom: 1px solid white;
      padding-top: 1rem;
      padding-bottom: .25rem;
      color: orangered;
    }
    nav a {
      font-size: 1.5rem;
    }
    nav a:hover, button:hover {
      background-color: rgb(20, 20, 20);
    }
    .right{
      float: right;
    }
</style>
